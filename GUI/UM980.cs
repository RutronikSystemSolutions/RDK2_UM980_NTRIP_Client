using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    public class UM980
    {
        public enum ConnectionState
        {
            Iddle,
            Connected,
            Error
        }

        #region "Events"
        public delegate void OnNewConnectionStateEventHandler(object sender, ConnectionState state);
        /// <summary>
        /// Event to signal a new connection state (serial communication)
        /// </summary>
        public event OnNewConnectionStateEventHandler OnNewConnectionState;

        public delegate void OnNMEAPacketEventHandler(object sender, byte[] packet);
        /// <summary>
        /// Event to signal a RTCM packet
        /// </summary>
        public event OnNMEAPacketEventHandler OnNMEAPacket;

        #endregion

        #region "Members"

        /// <summary>
        /// Serial port used for the communication
        /// </summary>
        private SerialPort port = null;

        /// <summary>
        /// Background worker enabling background operations
        /// </summary>
        private BackgroundWorker worker;

        /// <summary>
        /// Object used for synchronization purpose
        /// </summary>
        private object sync = new object();

        /// <summary>
        /// Contains chunk of data to be send
        /// </summary>
        private List<byte[]> toSend = new List<byte[]>();

        private ConnectionState state = ConnectionState.Iddle;

        #endregion

        #region "Constants"

        private const int MsgError = 1;
        private const int MsgNMEAPacket = 2;

        #endregion

        /// <summary>
        /// Set the serial port name
        /// </summary>
        /// <param name="portName"></param>
        public void SetPortName(string portName)
        {
            try
            {
                port = new SerialPort
                {
                    BaudRate = 921600,
                    DataBits = 8,
                    Handshake = Handshake.None,
                    Parity = Parity.None,
                    PortName = portName,
                    StopBits = StopBits.One,
                    ReadTimeout = 500,
                    WriteTimeout = 2000
                };
                port.Open();
            }
            catch (Exception)
            {
                state = ConnectionState.Error;
                OnNewConnectionState?.Invoke(this, ConnectionState.Error);
                return;
            }

            state = ConnectionState.Connected;
            OnNewConnectionState?.Invoke(this, ConnectionState.Connected);
            CreateBackgroundWorker();
            worker.RunWorkerAsync();
        }

        public void PushData(byte [] packet)
        {
            if (state != ConnectionState.Connected) return;

            lock(sync)
            {
                toSend.Add(packet);
            }
        }

        public void Disconnect()
        {
            if (worker == null) return;
            worker.CancelAsync();
        }

        private void CreateBackgroundWorker()
        {
            if (this.worker != null)
            {
                this.worker.CancelAsync();
            }

            this.worker = new BackgroundWorker();
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += Worker_DoWork;
            this.worker.ProgressChanged += Worker_ProgressChanged;
            this.worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            UM980Stream stream = new UM980Stream();

            for(; ;)
            {
                byte[] buffer = null;

                if (worker.CancellationPending) return;

                lock(sync)
                {
                    if (toSend.Count > 0)
                    {
                        buffer = toSend[0];
                        toSend.RemoveAt(0);
                    }
                }

                if (buffer != null)
                {
                    try
                    {
                        port.Write(buffer, 0, buffer.Length);
                    }
                    catch(Exception)
                    {
                        return;
                    }
                }

                // Something to read?
                if (port.BytesToRead > 0)
                {
                    byte[] readBuffer = new byte[port.BytesToRead];
                    int readBytes = 0;
                    try
                    {
                        readBytes = port.Read(readBuffer, 0, readBuffer.Length);
                    }
                    catch(Exception)
                    {
                        return;
                    }

                    stream.push(readBuffer, readBytes);

                    // Console.WriteLine(ASCIIEncoding.ASCII.GetString(readBuffer));
                    for(; ;)
                    {
                        if (worker.CancellationPending) return;

                        byte[] packet = stream.readNMEAPacket();
                        if (packet == null) break;
                        else
                        {
                            worker.ReportProgress(MsgNMEAPacket, packet);
                        }
                    }

                }
                
                System.Threading.Thread.Sleep(10);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch(e.ProgressPercentage)
            {
                case MsgNMEAPacket:
                    byte[] packet = (byte[])e.UserState;
                    OnNMEAPacket?.Invoke(this, packet);
                    break;
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                port.Close();
            }
            catch (Exception) { }
            OnNewConnectionState?.Invoke(this, ConnectionState.Iddle);
            state = ConnectionState.Iddle;
            worker = null;
        }
    }
}
