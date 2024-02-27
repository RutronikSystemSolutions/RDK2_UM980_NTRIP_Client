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

        private Track track = new Track(TrackStyle.Default);

        private DataRecorder positionRecorder = new DataRecorder();

        private bool firstValidPosition = true;
        private bool centerOnPosition = true;

        private Statistics distanceToRefPointStats = new Statistics();

        private GeoCoordinate referencePoint = null;
        private GeoCoordinate lastLocalisation = null;


        public MainForm()
        {
            InitializeComponent();
        }

        private void Um980_OnNMEAPacket(object sender, byte[] packet)
        {
            NMEAPacket nmeaPacket = new NMEAPacket(packet);
            blinkingPanel.Trigger();
            rawGGAMSgTextBox.Text = nmeaPacket.GetRawString();

            if (nmeaPacket.IsPositioningPacket())
            {
                GGAPacket ggaPacket = new GGAPacket(Encoding.ASCII.GetString(packet));

                string toDisp = string.Format("Timestamp: {6}\nLon: {0}°\nLat : {1}°\nQuality: {2}\nSat count: {3}\nCorrection age: {4} sec.\nHDOP: {5}", 
                    ggaPacket.GetLongitude(), 
                    ggaPacket.GetLatitude(), 
                    ggaPacket.quality, 
                    ggaPacket.satellites_in_use, 
                    ggaPacket.correction_age,
                    ggaPacket.hdop,
                    ggaPacket.GetTimestampAsString());
                lastPacketLabel.Text = toDisp;

                if (positionRecorder.IsStarted())
                {
                    string toStore = ggaPacket.GetAsStringForCSV();
                    positionRecorder.Store(ASCIIEncoding.ASCII.GetBytes(toStore));
                }

                latitudeTextBox.Text = ggaPacket.GetLatitude().ToString();
                longitudeTextBox.Text = ggaPacket.GetLongitude().ToString();
                qualityTextBox.Text = ggaPacket.quality.ToString();
                satCountTextBox.Text = ggaPacket.satellites_in_use.ToString();
                hdopTextBox.Text = ggaPacket.hdop.ToString();
                hdopPanel.SetValue(ggaPacket.hdop);

                if ((ggaPacket.GetLatitude() != 0) && (ggaPacket.GetLongitude() != 0))
                {
                    if (lastLocalisation == null) lastLocalisation = new GeoCoordinate();
                    lastLocalisation.latitude = ggaPacket.GetLatitude();
                    lastLocalisation.longitude = ggaPacket.GetLongitude();

                    if (referencePoint != null)
                    {
                        double distance = GeoCoordinate.GetDistance(
                            lastLocalisation.longitude, lastLocalisation.latitude,
                            referencePoint.longitude, referencePoint.latitude);

                        distanceToRefPointStats.pushData(distance);

                        distanceToRefPointTextBox.Text = String.Format("{0:F3}m \t Average: {1:F3} \t Std dev: {2:F3}", distance, distanceToRefPointStats.Average(), distanceToRefPointStats.StandardDeviation());
                    }

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

                    ntripClient.SetCoordinates(ggaPacket.GetLatitude(), ggaPacket.GetLongitude());

                    var point = new GeoPoint((float)ggaPacket.GetLongitude(), (float)ggaPacket.GetLatitude());

                    // Recenter if needed
                    if (centerOnPosition)
                    {
                        mapControl.Center = point;
                    }

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
                    disconnectUM980Button.Enabled = true;
                    portsComboBox.Enabled = false;
                    connectButton.BackColor = Color.Green;
                    break;
                case UM980.ConnectionState.Error:
                    connectButton.Enabled = true;
                    disconnectUM980Button.Enabled = false;
                    portsComboBox.Enabled = true;
                    connectButton.BackColor = Color.Red;
                    break;
                case UM980.ConnectionState.Iddle:
                    connectButton.Enabled = true;
                    disconnectUM980Button.Enabled = false;
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
            if (packet == null) return;
            lastRTCMTypeLabel.Text = "Last type: " + RTCMPacket.GetRTCMType(packet).ToString();
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
            //mapControl.TileServer = new OpenTopoMapServer();

            //mapControl.TileServer = new BingMapsAerialTileServer();
            //mapControl.TileServer = new BingMapsHybridTileServer();
            //mapControl.TileServer = new BingMapsRoadsTileServer();
            mapControl.TileServer = new OpenStreetMapTileServer("RutronikUM980PositioningGUIv1.0");

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

        private void disconnectUM980Button_Click(object sender, EventArgs e)
        {
            um980.Disconnect();
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

        private void centerOnPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            centerOnPosition = centerOnPositionToolStripMenuItem.Checked;
        }

        private void setAsReferencePointButton_Click(object sender, EventArgs e)
        {
            if (lastLocalisation == null) return;
            referencePoint = new GeoCoordinate();
            referencePoint.latitude = lastLocalisation.latitude;
            referencePoint.longitude = lastLocalisation.longitude;
            distanceToRefPointStats.clear();
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // Parse file and track to the map
            MeasurementFile file = new MeasurementFile(ofd.FileName);
            if (file.coordinates.Count == 0) return;

            Pen pen = new Pen(Color.Red);
            pen.Width = 20;

            Track fileTrack = new Track(new TrackStyle(pen));
            for (int i = 0; i < file.coordinates.Count; ++i)
            {
                fileTrack.Add(new GeoPoint((float)file.coordinates[i].longitude, (float)file.coordinates[i].latitude));
            }
            mapControl.Tracks.Add(fileTrack);
            mapControl.Invalidate();
        }
    }
}
