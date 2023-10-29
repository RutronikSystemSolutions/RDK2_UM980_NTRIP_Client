using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    public class StreamStatistics
    {
        #region "Events"

        public delegate void OnNewStatEventHandler(object sender, long size, double speed);
        /// <summary>
        /// Event to signal new statistics
        /// </summary>
        public event OnNewStatEventHandler OnNewStat;

        #endregion

        private long dataSize = 0;

        private long lastTime = 0;
        private long lastSize = 0;

        public void push(byte[] packet)
        {
            long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            dataSize += packet.Length;

            if (lastTime == 0) lastTime = milliseconds;
            if (milliseconds < lastTime) lastTime = milliseconds;

            long diff = milliseconds - lastTime;
            if (diff > 1000)
            {
                // Update every 1 second
                double dataSpeed = (dataSize - lastSize) / ((double)diff / 1000.0);

                lastTime = milliseconds;
                lastSize = dataSize;

                OnNewStat?.Invoke(this, dataSize, dataSpeed);
            }
        }

    }
}
