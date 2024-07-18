using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    class GGAPacket
    {
        public byte hours;
        public byte minutes;
        public byte seconds;
        public double lat_degree;
        public double lat_seconds;
        public byte lat_dir;
        public double lon_degree;
        public double lon_seconds;
        public byte lon_dir;
        public byte quality;
        public byte satellites_in_use;
        public double hdop; // Horizontal dilution of precision - the smaller the value, the better the quality
        public double altitude; // Altitude above/below MSL (geoid)
        public double undulation;   // Geoidal separation, the difference between the Earth ellipsoid surface and mean-sealevel (geoid) surface.
                                    // If the geoid is above the ellipsoid, the value is positive; otherwise, it is negative
        public int correction_age;



        /// <summary>
        /// Constructor using raw string
        /// </summary>
        /// <param name="rawPacket">Example: $GNGGA,074511.00,4845.77729544,N,00758.32489181,E,1,19,0.6,125.7309,M,48.3746,M,,*79</param>
        public GGAPacket(string rawPacket)
        {
            const int segmentCount = 15;
            
            string[] segments = rawPacket.Split(',');
            if (segments.Length != segmentCount) return;

            // UTC time
            string utcTimeStr = segments[1];
            if (utcTimeStr.Length != 9)
            {
                hours = 0;
                minutes = 0;
                seconds = 0;
            }
            else
            {
                string hourStr = utcTimeStr.Substring(0, 2);
                string minuteStr = utcTimeStr.Substring(2, 2);
                string secondStr = utcTimeStr.Substring(4, 2);

                try
                {
                    hours =  (byte) Convert.ToInt32(hourStr);
                    minutes = (byte)Convert.ToInt32(minuteStr);
                    seconds = (byte)Convert.ToInt32(secondStr);
                }
                catch(Exception)
                {
                    hours = 0;
                    minutes = 0;
                    seconds = 0;
                }
            }

            // Latitude 3137.36664 becomes 31 degrees and 37.26664 seconds = 31 + 37.36664/60 = 31.6227773
            // Extract 2 first chars
            if (segments[2].Length > 4)
            {
                string latDegreesStr = segments[2].Remove(2, segments[2].Length - 2);
                string latSecondsStr = segments[2].Remove(0, 2);
                // lat = Convert.ToDouble(latDegreesStr) + double.Parse(latSecondsStr, CultureInfo.InvariantCulture) / 60;
                try
                {
                    lat_degree = double.Parse(latDegreesStr, CultureInfo.InvariantCulture);
                    lat_seconds = double.Parse(latSecondsStr, CultureInfo.InvariantCulture);
                }
                catch(Exception)
                {
                    lat_degree = 0;
                    lat_seconds = 0;
                }
            }
            else
            {
                lat_degree = 0;
                lat_seconds = 0;
            }

            string latDirectionStr = segments[3];
            if (latDirectionStr.Equals("N") == false)
            {
                // S
                lat_dir = 1;
            }
            else
            {
                // N
                lat_dir = 0;
            }

            // Longitude 00212.21149 becomes 2 degrees and 12.21149 seconds = 2 + 12.21149/60 = 2.20352483
            // Extract 3 first chars
            if (segments[4].Length > 4)
            {
                string lonDegreesStr = segments[4].Remove(3, segments[4].Length - 3);
                string lonSecondsStr = segments[4].Remove(0, 3);
                //lon = Convert.ToDouble(lonDegreesStr) + double.Parse(lonSecondsStr, CultureInfo.InvariantCulture) / 60;
                try
                {
                    lon_degree = double.Parse(lonDegreesStr, CultureInfo.InvariantCulture);
                    lon_seconds = double.Parse(lonSecondsStr, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    lon_degree = 0;
                    lon_seconds = 0;
                }
            }
            else
            {
                lon_degree = 0;
                lon_seconds = 0;
            }

            string lonDirectionStr = segments[5];
            if (lonDirectionStr.Equals("E") == false)
            {
                // W
                lon_dir = 1;
            }
            else
            {
                // E
                lon_dir = 0;
            }

            string qualityStr = segments[6];
            if (qualityStr.Length != 0)
            {
                try
                {
                    quality = (byte)Convert.ToInt32(qualityStr);
                }
                catch (Exception)
                {
                    quality = 0;
                }
            }
            else quality = 0;

            string satCountStr = segments[7];
            if (satCountStr.Length != 0)
            {
                try
                {
                    satellites_in_use = (byte)Convert.ToInt32(satCountStr);
                }
                catch (Exception)
                {
                    satellites_in_use = 0;
                }
            }
            else satellites_in_use = 0;

            string hdopStr = segments[8];
            if (hdopStr.Length != 0)
            {
                try
                {
                    hdop = double.Parse(hdopStr, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    hdop = 0;
                }
            }
            else hdop = 0;

            string altitudeStr = segments[9];
            if (altitudeStr.Length != 0)
            {
                try
                {
                    altitude = double.Parse(altitudeStr, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    altitude = 0;
                }
            }
            else altitude = 0;

            string undulationStr = segments[11];
            if (undulationStr.Length != 0)
            {
                try
                {
                    undulation = double.Parse(undulationStr, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    undulation = 0;
                }
            }
            else undulation = 0;

            // $GNGGA,104006.00,4845.77986177,N,00758.32408413,E,2,22,0.6,129.6143,M,48.3745,M,7.0,0000*54

            string correctionAgeStr = segments[13];
            if (correctionAgeStr.Length >= 1)
            {
                try
                {
                    correction_age = (int) double.Parse(correctionAgeStr, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    correction_age = 999;
                }
            }
            else
            {
                correction_age = 999;
            }
        }

        public double GetLatitude()
        {
            double retval = lat_degree + lat_seconds / 60;
            if (lat_dir != 0) retval = -retval;
            return retval;
        }

        public double GetLongitude()
        {
            double retval = lon_degree + lon_seconds / 60;
            if (lon_dir != 0) retval = -retval;
            return retval;
        }

        public double GetAltitude()
        {
            double realAltitude = altitude + undulation;
            return realAltitude;
        }

        public string GetTimestampAsString()
        {
            return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }

        public static string GetCsvHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("hours;");
            sb.Append("minutes;");
            sb.Append("seconds;");
            sb.Append("latitude degree;");
            sb.Append("latitude seconds;");
            sb.Append("latitude dir;");
            sb.Append("longitude degree;");
            sb.Append("longitude seconds;");
            sb.Append("longitude dir;");
            sb.Append("quality;");
            sb.Append("satellites in use;");
            sb.Append("hdop;");
            sb.Append("altitude;");
            sb.Append("undulation;");
            sb.Append("correction age;");
            sb.Append("latitude;");
            sb.Append("longitude;");
            sb.Append("altitude;");
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        public string GetAsStringForCSV()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0};", hours));
            sb.Append(string.Format("{0};", minutes));
            sb.Append(string.Format("{0};", seconds));
            sb.Append(string.Format("{0};", lat_degree));
            sb.Append(string.Format("{0};", lat_seconds));
            sb.Append(string.Format("{0};", lat_dir));
            sb.Append(string.Format("{0};", lon_degree));
            sb.Append(string.Format("{0};", lon_seconds));
            sb.Append(string.Format("{0};", lon_dir));
            sb.Append(string.Format("{0};", quality));
            sb.Append(string.Format("{0};", satellites_in_use));
            sb.Append(string.Format("{0};", hdop));
            sb.Append(string.Format("{0};", altitude));
            sb.Append(string.Format("{0};", undulation));
            sb.Append(string.Format("{0};", correction_age));
            sb.Append(string.Format("{0};", GetLatitude()));
            sb.Append(string.Format("{0};", GetLongitude()));
            sb.Append(string.Format("{0};", GetAltitude()));
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
