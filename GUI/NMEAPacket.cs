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

        private static string getChecksum(string sentence)
        {
            //Start with first Item
            int checksum = Convert.ToByte(sentence[sentence.IndexOf('$') + 1]);
            // Loop through all chars to get a checksum
            for (int i = sentence.IndexOf('$') + 2; i < sentence.IndexOf('*'); i++)
            {
                // No. XOR the checksum with this character's value
                checksum ^= Convert.ToByte(sentence[i]);
            }
            // Return the checksum formatted as a two-character hexadecimal
            return checksum.ToString("X2");
        }

        public static string GenerateNMEAGGAPacket(double latitude, double longitude)
        {
            //$GPGGA,084125,5400.0000,N,02300.0000,E,1,05,1.00,100.0,M,10.000,M,,*7c
            var date = DateTime.UtcNow;

            string latitudeSign = "N";
            if (latitude < 0)
            {
                latitudeSign = "S";
                latitude = -latitude;
            }

            string longitudeSign = "E";
            if (longitude < 0)
            {
                longitudeSign = "W";
                longitude = -longitude;
            }

            int latitudeDegree = (int)latitude;
            double latitudeSeconds = ((latitude - latitudeDegree) * 60);
            string latitudeStr = string.Format("{0:00}{1:00.00000000}", latitudeDegree, latitudeSeconds).Replace(',','.');

            int longitudeDegree = (int)longitude;
            double longitudeSeconds = ((longitude - longitudeDegree) * 60);
            string longitudeStr = string.Format("{0:000}{1:00.00000000}", longitudeDegree, longitudeSeconds).Replace(',', '.');

            string retval = string.Format("$GPGGA,{0:00}{1:00}{2:00},{3},{4},{5},{6},1,05,1.00,100.0,M,10.000,M,,*", date.Hour, date.Minute, date.Second, latitudeStr, latitudeSign, longitudeStr, longitudeSign);
            string checksum = getChecksum(retval);

            retval = retval + checksum;

            return retval;
        }

        public string GetRawString()
        {
            return Encoding.ASCII.GetString(packet);
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


        public void ExtractPosition(out double lon, out double lat,  out int quality, out int satCount, out int correctionAge)
        {
            // $GNGGA,074511.00,4845.77729544,N,00758.32489181,E,1,19,0.6,125.7309,M,48.3746,M,,*79
            // Init
            lon = 0;
            lat = 0;
            quality = 0;
            satCount = 0;
            correctionAge = 0;

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

            string latDirectionStr = segments[3];
            if (latDirectionStr.Equals("N") == false) lat = -lat;

            // Longitude 00212.21149 becomes 2 degrees and 12.21149 seconds = 2 + 12.21149/60 = 2.20352483
            // Extract 3 first chars
            if (segments[4].Length > 4)
            {
                string lonDegreesStr = segments[4].Remove(3, segments[4].Length - 3);
                string lonSecondsStr = segments[4].Remove(0, 3);
                lon = Convert.ToDouble(lonDegreesStr) + double.Parse(lonSecondsStr, CultureInfo.InvariantCulture) / 60;
            }

            string lonDirectionStr = segments[5];
            if (lonDirectionStr.Equals("E") == false) lon = -lon;

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

            string correctionAgeStr = segments[13];
            try
            {
                correctionAge = Convert.ToInt32(correctionAgeStr);
            }
            catch (Exception)
            {
                correctionAge = 0;
            }
        }
    }
}

