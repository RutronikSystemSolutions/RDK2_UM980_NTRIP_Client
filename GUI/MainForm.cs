using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace UM980PositioningGUI
{
    public partial class MainForm : Form
    {
        private NTRIPSocketClient ntripClient;
        private StreamStatistics streamStatistics;
        private UM980 um980 = new UM980();

        private Marker currentPos = null;

        // Initializing collection of points,
        // filling points with data omitted
        private List<GeoPoint> posPoints = new List<GeoPoint>();
        private Track track = new Track(TrackStyle.Default);

        private DataRecorder positionRecorder = new DataRecorder();

        private bool firstValidPosition = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Um980_OnNMEAPacket(object sender, byte[] packet)
        {
            NMEAPacket nmeaPacket = new NMEAPacket(packet);
            Console.WriteLine(nmeaPacket.GetRawString());

            if (nmeaPacket.IsPositioningPacket())
            {
                nmeaPacket.ExtractPosition(out double lon, out double lat, out int quality, out int satCount, out int correctionAge);

                string toDisp = string.Format("Lon: {0}° Lat : {1}° Quality: {2} Sat count: {3} Correction age: {4} sec.", lon, lat, quality, satCount, correctionAge);
                lastPacketLabel.Text = toDisp;

                if (positionRecorder.IsStarted())
                {
                    string toStore = string.Format("{0};{1};{2};{3};{4}", lon, lat, quality, satCount, correctionAge) + Environment.NewLine;
                    positionRecorder.Store(ASCIIEncoding.ASCII.GetBytes(toStore));
                }

                latitudeTextBox.Text = lat.ToString();
                longitudeTextBox.Text = lon.ToString();
                qualityTextBox.Text = quality.ToString();
                satCountTextBox.Text = satCount.ToString();

                if ((lat != 0) && (lon != 0))
                {
                    if (firstValidPosition == true)
                    {
                        firstValidPosition = false;
                        mapControl.ZoomLevel = 10;

                        // Define custom track style
                        var style = new TrackStyle(new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash, Width = 3 });

                        // Assign style to the track
                        track = new Track(style);

                        // Add track to the map
                        mapControl.Tracks.Add(track);
                    }

                    ntripClient.SetCoordinates(lat, lon);

                    // Recenter always
                    var point = new GeoPoint((float)lon, (float)lat);
                    mapControl.Center = point;

                    track.Add(point);
                    if (track.Count > 100) track.RemoveAt(0);

                    if (currentPos == null)
                    {
                        var style = new MarkerStyle(30, Brushes.Red, Pens.Red, Brushes.Black, SystemFonts.DefaultFont, StringFormat.GenericDefault);

                        // Create marker instance: specify location on the map, drawing style, and label
                        currentPos = new Marker(point, style, "Position");
                    }
                    else
                    {
                        currentPos.Point = point;
                    }

                    if (mapControl.Markers.Contains(currentPos) == false)
                    {
                        // Add marker to the map if needed
                        mapControl.Markers.Add(currentPos);
                    }

                    mapControl.Refresh();
                }
            }
            else
            {
                lastPacketLabel.Text = nmeaPacket.GetRawString();
            }
        }

        private void Um980_OnNewConnectionState(object sender, UM980.ConnectionState state)
        {
            switch (state)
            {
                case UM980.ConnectionState.Connected:
                    connectButton.Enabled = false;
                    portsComboBox.Enabled = false;
                    connectButton.BackColor = Color.Green;
                    break;
                case UM980.ConnectionState.Error:
                    connectButton.Enabled = true;
                    portsComboBox.Enabled = true;
                    connectButton.BackColor = Color.Red;
                    break;
                case UM980.ConnectionState.Iddle:
                    connectButton.Enabled = true;
                    portsComboBox.Enabled = true;
                    connectButton.BackColor = SystemColors.Control;
                    break;
            }
        }

        private void StreamStatistics_OnNewStat(object sender, long size, double speed)
        {
            bytesReceivedLabel.Text = string.Format("{0} bytes", size);
            receptionSpeedLabel.Text = string.Format("{0} bytes/s", (int)speed);
        }

        private void NtripClient_OnRTCMPacket(object sender, byte[] packet)
        {
            // Console.WriteLine("Send packet:  " + packet.Length + " First : " + packet[0]);

            // RTCMPacket rtcmppacket = new RTCMPacket(packet);
            streamStatistics.push(packet);
            um980.PushData(packet);
        }

        private void NtripClient_OnError(object sender, string errorMsg)
        {
            logBox.AddLog(errorMsg);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // If tile server supports file system caching, 
            // you should specify path to the cache folder.
            // Web-based tile servers strongly require file system caching
            // to prevent highload of the server.
            mapControl.CacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MapControl");

            // Use tiles from OpenTopoMap (https://opentopomap.org/)
            mapControl.TileServer = new OpenTopoMapServer();

            string[] serialPorts = SerialPort.GetPortNames();
            portsComboBox.DataSource = serialPorts;

            ntripClient = new NTRIPSocketClient();
            ntripClient.OnError += NtripClient_OnError;
            ntripClient.OnRTCMPacket += NtripClient_OnRTCMPacket;
            ntripClient.OnNewCorrectionStations += NtripClient_OnNewCorrectionStations;
            ntripClient.OnNewConnectionState += NtripClient_OnNewConnectionState;
            ntripClient.OnNewStationConnectionAttempt += NtripClient_OnNewStationConnectionAttempt;

            streamStatistics = new StreamStatistics();
            streamStatistics.OnNewStat += StreamStatistics_OnNewStat;

            um980.OnNewConnectionState += Um980_OnNewConnectionState;
            um980.OnNMEAPacket += Um980_OnNMEAPacket;
        }

        private void NtripClient_OnNewStationConnectionAttempt(object sender, CorrectionStation station)
        {
            logBox.AddLog("Connect to station: " + station.name);

            mapControl.Markers.Clear();
            List<CorrectionStation> stations = ntripClient.GetCorrectionStations();
            for (int i = 0; i < stations.Count; ++i)
            {
                // Create marker's location point
                var point = new GeoPoint((float)stations[i].lon, (float)stations[i].lat);
                var style = new MarkerStyle(30, Brushes.Blue, Pens.Black, Brushes.Black, SystemFonts.DefaultFont, StringFormat.GenericDefault);
                if (stations[i] == station)
                {
                    style = new MarkerStyle(30, Brushes.Green, Pens.Black, Brushes.Black, SystemFonts.DefaultFont, StringFormat.GenericDefault);
                }
                var marker = new Marker(point, style, stations[i].name);
                mapControl.Markers.Add(marker);
            }
            mapControl.Refresh();
        }

        private void NtripClient_OnNewConnectionState(object sender, NTRIPSocketClient.ConnectionState state)
        {
            logBox.AddLog(state.ToString());

            if ((state == NTRIPSocketClient.ConnectionState.Iddle) || (state == NTRIPSocketClient.ConnectionState.Error))
            {
                disconnectButton.Enabled = false;
                configureNtripStreamButton.Enabled = true;
            }
            else
            {
                disconnectButton.Enabled = true;
                configureNtripStreamButton.Enabled = false;
            }
        }

        private void NtripClient_OnNewCorrectionStations(object sender, List<CorrectionStation> stations)
        {
            for(int i = 0; i < stations.Count; ++i)
            {
                // Create marker's location point
                var point = new GeoPoint((float)stations[i].lon, (float)stations[i].lat);
                var style = new MarkerStyle(30, Brushes.Blue, Pens.Black, Brushes.Black, SystemFonts.DefaultFont, StringFormat.GenericDefault);
                var marker = new Marker(point, style, stations[i].name);
                mapControl.Markers.Add(marker);
            }
            mapControl.Refresh();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if ((portsComboBox.SelectedIndex < 0) || (portsComboBox.SelectedIndex >= portsComboBox.Items.Count)) return;
            um980.SetPortName(portsComboBox.Items[portsComboBox.SelectedIndex].ToString());
        }

        private void storePositionToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoreToFileForm form = new StoreToFileForm(positionRecorder);
            form.ShowDialog();
        }

        private void configureNtripStreamButton_Click(object sender, EventArgs e)
        {
            NTRIPCasterConfigurationForm form = new NTRIPCasterConfigurationForm(ntripClient);
            form.ShowDialog();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            streamStatistics.clear();
            ntripClient.Disconnect();
        }
    }
}
