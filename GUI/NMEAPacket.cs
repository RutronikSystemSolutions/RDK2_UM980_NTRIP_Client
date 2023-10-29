using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    public class NMEAPacket
    {
        private byte[] packet;

        public NMEAPacket(byte [] packet)
        {
            if (packet != null)
            {
                this.packet = new byte[packet.Length];
                for(int i = 0; i < packet.Length; ++i)
                {
                    this.packet[i] = packet[i];
                }
            }
        }

        public string GetRawString()
        {
            return ASCIIEncoding.ASCII.GetString(packet);
        }

        public bool IsPositioningPacket()
        {
            string str = GetRawString();
            if (str.Contains("$GNGGA")) return true;
            if (str.Contains("$GPGGA")) return true;
            if (str.Contains("$GBGGA")) return true;
            if (str.Contains("$GLGGA")) return true;
            if (str.Contains("$GAGGA")) return true;
            if (str.Contains("$GQGGA")) return true;

            return false;
        }


        public void ExtractPosition(out double lon, out double lat,  out int quality, out int satCount)
        {
            // $GNGGA,074511.00,4845.77729544,N,00758.32489181,E,1,19,0.6,125.7309,M,48.3746,M,,*79
            // Init
            lon = 0;
            lat = 0;
            quality = 0;
            satCount = 0;

            string[] segments = GetRawString().Split(',');
            if (segments.Length != 15) return;

            // Latitude 3137.36664 becomes 31 degrees and 37.26664 seconds = 31 + 37.36664/60 = 31.6227773
            // Extract 2 first chars
            if (segments[2].Length > 4)
            {
                string latDegreesStr = segments[2].Remove(2, segments[2].Length - 2);
                string latSecondsStr = segments[2].Remove(0, 2);

                lat = Convert.ToDouble(latDegreesStr) + double.Parse(latSecondsStr, CultureInfo.InvariantCulture) / 60;
            }

            // Longitude 00212.21149 becomes 2 degrees and 12.21149 seconds = 2 + 12.21149/60 = 2.20352483
            // Extract 3 first chars
            if (segments[4].Length > 4)
            {
                string lonDegreesStr = segments[4].Remove(3, segments[4].Length - 3);
                string lonSecondsStr = segments[4].Remove(0, 3);

                lon = Convert.ToDouble(lonDegreesStr) + double.Parse(lonSecondsStr, CultureInfo.InvariantCulture) / 60;
            }

            // TODO extract N/S and E/W to correct lon and lat and make it work every where

            string qualityStr = segments[6];
            quality = Convert.ToInt32(qualityStr);

            string satCountStr = segments[7];
            try
            {
                satCount = Convert.ToInt32(satCountStr);
            }
            catch(Exception)
            {
                satCount = 0;
            }
        }
    }
}

