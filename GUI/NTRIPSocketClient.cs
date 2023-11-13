using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;

namespace UM980PositioningGUI
{
    public class NTRIPSocketClient
    {
        #region "Types"

        public enum ConnectionState
        {
            Iddle,
            OpeningConnection,
            DownloadingDataSource,
            WaitingValidPosition,
            ReceivingCorrectionData,
            Error
        }

        public enum ConfigurationMode
        {
            Unknown,
            ConnectToNearest,
            ConnectToSelected
        }

        #endregion

        #region "Members"

        /// <summary>
        /// Background worker enabling background operations
        /// </summary>
        private BackgroundWorker worker;

        /// <summary>
        /// Stream enabling to extract correction packet
        /// </summary>
        private NTRIPStream ntripStream = new NTRIPStream();

        private string address;
        private int port;
        private string login;
        private string password;

        private double latitude = double.NaN;
        private double longitude = double.NaN;

        private ConnectionState connectionState = ConnectionState.Iddle;

        private List<CorrectionStation> stations;

        private object sync = new object();

        private int actionRequested = ActionUndefined;

        private ConfigurationMode configurationMode = ConfigurationMode.Unknown;
        private string selectedMountPoint;


        #endregion

        #region "Constants"

        private const int MsgError = 1;
        private const int MsgRTCMPacket = 2;
        private const int MsgStationList = 3;
        private const int MsgNewConnectionState = 4;
        private const int MsgConnectToStation = 5;

        private const int ActionUndefined = 0;
        private const int ActionRequestSourceTable = 1;
        private const int ActionRequestCorrectionValues = 2;

        private const int SocketConnectTimeoutMs = 2500;

        #endregion

        #region "Events"
        public delegate void OnErrorEventHandler(object sender, string errorMsg);
        /// <summary>
        /// Event to signal an error
        /// </summary>
        public event OnErrorEventHandler OnError;

        public delegate void OnNewConnectionStateEventHandler(object sender, ConnectionState state);
        /// <summary>
        /// Event to signal a new connection state
        /// </summary>
        public event OnNewConnectionStateEventHandler OnNewConnectionState;

        public delegate void OnRTCMPacketEventHandler(object sender, byte [] packet);
        /// <summary>
        /// Event to signal a RTCM packet
        /// </summary>
        public event OnRTCMPacketEventHandler OnRTCMPacket;

        public delegate void OnNewCorrectionStationsEventHandler(object sender, List<CorrectionStation> stations);
        /// <summary>
        /// Event to signal new stations
        /// </summary>
        public event OnNewCorrectionStationsEventHandler OnNewCorrectionStations;

        public delegate void OnNewStationConnectionAttemptEventHandler(object sender, CorrectionStation station);
        /// <summary>
        /// Event to signala connection attempt to a mount point
        /// </summary>
        public event OnNewStationConnectionAttemptEventHandler OnNewStationConnectionAttempt;

        #endregion

        /// <summary>
        /// Get the list of the available correction stations
        /// </summary>
        /// <returns></returns>
        public List<CorrectionStation> GetCorrectionStations()
        {
            return stations;
        }

        /// <summary>
        /// Change the connection state
        /// </summary>
        /// <param name="state"></param>
        private void ChangeConnectionState(ConnectionState state)
        {
            connectionState = state;
            OnNewConnectionState?.Invoke(this, connectionState);
        }

        /// <summary>
        /// Request the source table
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public void RequestSourceTable(string address, int port, string login, string password)
        {
            this.address = address;
            this.port = port;
            this.login = login;
            this.password = password;
            actionRequested = ActionRequestSourceTable;
            CreateAndStartBackgroundWorker();
            ChangeConnectionState(ConnectionState.OpeningConnection);
        }

        /// <summary>
        /// Request the correction values (first need to get the source table)
        /// </summary>
        /// <param name="configurationMode"></param>
        /// <param name="selectedMountPoint"></param>
        public void RequestCorrectionValues(ConfigurationMode configurationMode, string selectedMountPoint)
        {
            if ((stations == null) || (stations.Count == 0)) return;
            this.selectedMountPoint = selectedMountPoint;
            this.configurationMode = configurationMode;
            actionRequested = ActionRequestCorrectionValues;
            CreateAndStartBackgroundWorker();
            ChangeConnectionState(ConnectionState.OpeningConnection);
        }

        /// <summary>
        /// Stop the connection
        /// </summary>
        public void Disconnect()
        {
            if (worker != null)
            {
                worker.CancelAsync();
                return;
            }
        }

        /// <summary>
        /// Generate the get request enabling to get the correction data
        /// </summary>
        /// <returns></returns>
        private string GenerateMountPointGetRequest(string mountPoint, string userName, string password)
        {
            string retval = "GET /" + mountPoint + " HTTP/1.0" + "\r\n";
            retval += "User-Agent: NTRIP RutronikClient/20231025" + "\r\n";
            retval += "Accept: */*" + "\r\n" + "Connection: close" + "\r\n";
            if ((userName != null) && (userName.Length > 0))
            {
                string auth = Base64Encode(userName + ":" + password);
                retval += "Authorization: Basic " + auth + "\r\n";
            }
            retval += "\r\n";

            return retval;
        }

        // To use for connection
        private string Base64Encode(string text)
        {
            var textBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }

        /// <summary>
        /// Get request used to read the source table of the caster
        /// The source table contains the list of correction sender (with coordiates)
        /// </summary>
        /// <returns></returns>
        private string GenerateSourceTableGetRequest(string userName, string password)
        {
            string retval = "GET / HTTP/1.0" + "\r\n";
            retval += "User-Agent: NTRIP RutronikClient/20231025" + "\r\n";
            retval += "Accept: */*" + "\r\n" + "Connection: close" + "\r\n";
            if ((userName != null) && (userName.Length > 0))
            {
                string auth = Base64Encode(userName + ":" + password);
                retval += "Authorization: Basic " + auth + "\r\n";
            }
            retval += "\r\n";
            return retval;
        }

        /// <summary>
        /// Create the background worker (used for background operation) and start it
        /// </summary>
        private void CreateAndStartBackgroundWorker()
        {
            if (this.worker != null)
            {
                this.worker.CancelAsync();
                return;
            }

            this.worker = new BackgroundWorker();
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += Worker_DoWork;
            this.worker.ProgressChanged += Worker_ProgressChanged;
            this.worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.worker.RunWorkerAsync();
        }

        /// <summary>
        /// Read the source table
        /// </summary>
        /// <param name="worker">Worker enabling to send messages</param>
        /// <returns>0 on success,  != 0 if something wrong happened</returns>
        private int GetSourceTable(BackgroundWorker worker)
        {
            Socket socket;
            try
            {
                // Create a TCP/IP  socket.
                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Asynchronuous connection to detect timeout
                IAsyncResult result = socket.BeginConnect(this.address, this.port, null, null);
                result.AsyncWaitHandle.WaitOne(SocketConnectTimeoutMs, true);

                if (socket.Connected)
                {
                    socket.EndConnect(result);
                }
                else
                {
                    socket.Close();
                    throw new Exception("Timeout during connection");
                }
            }
            catch(Exception ex)
            {
                worker.ReportProgress(MsgError, "Error during connection: " + ex.Message);
                return -1;
            }

            // Create and send get message
            byte[] msg = Encoding.ASCII.GetBytes(GenerateSourceTableGetRequest(login, password));
            try
            {
                socket.Send(msg);
            }
            catch(Exception ex)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                worker.ReportProgress(MsgError, "Error while sending get request: " + ex.Message);
                return -2;
            }

            // Signal new status
            worker.ReportProgress(MsgNewConnectionState, ConnectionState.DownloadingDataSource);

            // Get the answer
            string sourceTableStr = string.Empty;
            byte[] bytes = new byte[1024];
            long lastValidTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for(; ;)
            {
                long timeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                
                long diff = timeStamp - lastValidTimestamp;
                if ((diff < 0) || (diff > 1000))
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                    worker.ReportProgress(MsgError, "Timeout while reading source table");
                    return -2;
                }

                // Receive the response from the remote device.
                int bytesRec = socket.Receive(bytes);
                if (bytesRec > 0)
                {
                    string response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    sourceTableStr += response;

                    lastValidTimestamp = timeStamp;

                    if (response.Contains("ENDSOURCETABLE"))
                    {
                        break;
                    }
                }
                System.Threading.Thread.Sleep(10);
            }

            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception) { }

            // Extract the stations from the string
            stations = SourceTable.GetStations(sourceTableStr);

            Console.WriteLine("Source Table:");
            Console.WriteLine(sourceTableStr);

            return 0;
        }

        /// <summary>
        /// Get the correction data coming from the nearest station
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        private int GetCorrectionData(BackgroundWorker worker, CorrectionStation station)
        {
            Socket socket = null;
            try
            {
                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(this.address, this.port);
            }
            catch (Exception ex)
            {
                worker.ReportProgress(MsgError, "Error during connection: " + ex.Message);
                return -1;
            }

            // Create and send get message
            byte[] msg = Encoding.ASCII.GetBytes(GenerateMountPointGetRequest(station.name,login, password));
            try
            {
                socket.Send(msg);
            }
            catch (Exception ex)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                worker.ReportProgress(MsgError, "Error while sending get request: " + ex.Message);
                return -2;
            }

            // Get the answer and wait until OK
            byte[] bytes = new byte[1024];
            string readBuffer = string.Empty;
            long lastValidTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (; ; )
            {
                long timeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                long diff = timeStamp - lastValidTimestamp;
                if ((diff < 0) || (diff > 5000))
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                    worker.ReportProgress(MsgError, "Timeout when connectiong to correction station");
                    return -2;
                }

                // Receive the response from the remote device.
                int bytesRec = socket.Receive(bytes);
                if (bytesRec > 0)
                {
                    string response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    readBuffer += response;

                    if (response.Contains("ICY 200 OK"))
                    {
                        break;
                    }
                }
                System.Threading.Thread.Sleep(10);
            }

            // needs to send position (because of virtual reference station?)
            if (station.nmeaRequested != 0)
            {
                double latitude = 0;
                double longitude = 0;
                lock (sync)
                {
                    latitude = this.latitude;
                    longitude = this.longitude;
                }

                // $GPGGA,084125,5400.0000,N,02300.0000,E,1,05,1.00,100.0,M,10.000,M,,*7c
                string positionStr = NMEAPacket.GenerateNMEAGGAPacket(latitude, longitude);
                Console.WriteLine("Send : " + positionStr);
                msg = Encoding.ASCII.GetBytes(positionStr + "\r\n");
                try
                {
                    socket.Send(msg);
                }
                catch (Exception ex)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                    worker.ReportProgress(MsgError, "Error while sending position packet: " + ex.Message);
                    return -3;
                }
            }

            worker.ReportProgress(MsgNewConnectionState, ConnectionState.ReceivingCorrectionData);


            lastValidTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            // OK message has been received, continuously receive the correction data now
            for (; ; )
            {
                long timeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                long diff = timeStamp - lastValidTimestamp;
                if ((diff < 0) || (diff > 5000))
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                    worker.ReportProgress(MsgError, "Didn't receive correction data since 5 seconds. Close connection.");
                    return -2;
                }

                if (worker.CancellationPending)
                {
                    try
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                    catch (Exception) { }
                    return 0;
                }

                int bytesRec = socket.Receive(bytes);
                if (bytesRec > 0)
                {
                    ntripStream.push(bytes, bytesRec);

                    // Valid packet inside?
                    for (; ; )
                    {
                        byte[] packet = ntripStream.readRTCMPacket();
                        if (packet == null) break;
                        else
                        {
                            lastValidTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                            worker.ReportProgress(MsgRTCMPacket, packet);
                        }
                    }
                }
            }
        }

        public void SetCoordinates(double latitude, double longitude)
        {
            lock (sync)
            {
                this.latitude = latitude;
                this.longitude = longitude;
            }
        }

        /// <summary>
        /// Main job of the background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            if (actionRequested == ActionRequestSourceTable)
            {
                int retval = GetSourceTable(worker);
                if (retval != 0)
                {
                    worker.ReportProgress(MsgNewConnectionState, ConnectionState.Error);
                    return;
                }

                // Success - report the list of stations
                worker.ReportProgress(MsgStationList);

                return;
            }

            if (actionRequested == ActionRequestCorrectionValues)
            {
                worker.ReportProgress(MsgNewConnectionState, ConnectionState.WaitingValidPosition);
                for (; ; )
                {
                    if (worker.CancellationPending) break;

                    double latitude = double.NaN;
                    double longitude = double.NaN;
                    lock (sync)
                    {
                        latitude = this.latitude;
                        longitude = this.longitude;
                    }

                    if (double.IsNaN(latitude) || double.IsNaN(longitude))
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }

                    CorrectionStation toConnectStation = null;
                    if (configurationMode == ConfigurationMode.ConnectToNearest)
                    {
                        toConnectStation = SourceTable.GetNearest(stations, latitude, longitude);
                    }
                    else
                    {
                        toConnectStation = SourceTable.GetByMountPointName(stations, selectedMountPoint);
                    }
                    worker.ReportProgress(MsgConnectToStation, toConnectStation);

                    int retval = GetCorrectionData(worker, toConnectStation);
                    if (retval != 0)
                    {
                        worker.ReportProgress(MsgNewConnectionState, ConnectionState.Error);
                        return;
                    }
                }
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch(e.ProgressPercentage)
            {
                case MsgError:
                    string errorMsg = (string)e.UserState;
                    OnError?.Invoke(this, errorMsg);
                    break;

                case MsgRTCMPacket:
                    byte[] packet = (byte[])e.UserState;
                    OnRTCMPacket?.Invoke(this, packet);
                    break;

                case MsgStationList:
                    OnNewCorrectionStations?.Invoke(this, stations);
                    break;

                case MsgNewConnectionState:
                    ConnectionState state = (ConnectionState)e.UserState;
                    ChangeConnectionState(state);
                    break;

                case MsgConnectToStation:
                    CorrectionStation station = (CorrectionStation)e.UserState;
                    OnNewStationConnectionAttempt?.Invoke(this, station);
                    break;
            }
        }

        /// <summary>
        /// Worker completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Signal change state
            ChangeConnectionState(ConnectionState.Iddle);
            worker = null;
        }

    }
}
