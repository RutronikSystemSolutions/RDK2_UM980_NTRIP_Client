using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    public class DataRecorder
    {
        #region "Events"

        public delegate void OnNewStateEventHandler(object sender);
        /// <summary>
        /// Event to signal a new state
        /// </summary>
        public event OnNewStateEventHandler OnNewState;

        #endregion

        private BackgroundWorker worker;
        private object sync = new object();
        private List<byte[]> toWrite = new List<byte[]>();
        private string path;
        
        public bool IsStarted()
        {
            if (worker == null) return false;
            return true;
        }

        public string Path
        {
            get { return path; }
        }

        public void Start(string path)
        {
            this.path = path;
            CreateAndStartBackgroundWorker();
        }

        public void Stop()
        {
            if (worker != null)
            {
                worker.CancelAsync();
            }
        }

        public void Store(byte [] buffer)
        {
            if (buffer == null) return;
            lock (sync)
            {
                toWrite.Add(buffer);
            }
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

            OnNewState?.Invoke(this);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            BinaryWriter writer;
            try
            {
                writer = new BinaryWriter(File.OpenWrite(this.path));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
                return;
            }

            for(; ;)
            {
                byte[] buffer = null;
                
                if (worker.CancellationPending)
                {
                    writer.Close();
                    return;
                }

                lock(sync)
                {
                    if (toWrite.Count > 0)
                    {
                        buffer = new byte[toWrite[0].Length];
                        for(int i = 0; i < buffer.Length; ++i)
                        {
                            buffer[i] = toWrite[0][i];
                        }
                        toWrite.RemoveAt(0);
                    }
                }

                if (buffer != null)
                {
                    try
                    {
                        writer.Write(buffer);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Exception occured while writing: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(10);
                }
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.worker = null;
            OnNewState?.Invoke(this);
        }
    }
}
