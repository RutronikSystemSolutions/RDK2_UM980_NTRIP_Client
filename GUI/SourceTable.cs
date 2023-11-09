using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    public class SourceTable
    {
        public static CorrectionStation GetNearest(List<CorrectionStation> list, double lat, double lon)
        {
            if ((list == null) || (list.Count == 0)) return null;
            CorrectionStation nearest = list[0];
            double bestDistance = nearest.DistanceTo(lat, lon);
            for(int i = 1; i < list.Count; ++i)
            {
                double distance = list[i].DistanceTo(lat, lon);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    nearest = list[i];
                }
            }
            return nearest;
        }

        public static List<CorrectionStation> GetStations(string sourceTable)
        {
            List<CorrectionStation> retval = new List<CorrectionStation>();

            string[] lines = sourceTable.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for(int i = 0; i < lines.Length; ++i)
            {
                // [0]: STR;
                // [1]: 56MOUS;
                // [2]: Moustoir-Ac;
                // [3]: RTCM3;
                // [4]: 1004,1005,1006,1008,1012,1019,1020,1033,1042,1046,1077,1087,1097,1107,1127,1230;
                // [5]: 2;
                // [6]: GLO+GAL+SBS+BDS+GPS;
                // [7]: NONE;
                // [8]: FRA;
                // [9]: 47.837;
                // [10]: -2.854;
                // [11]: 0;0;NTRIP RTKBase Ublox_ZED-F9P 2.4.1 1.13;none;N;N;15200;CentipedeRTK
                string[] segments = lines[i].Split(new char[] { ';' });

                if (segments.Length < 11)
                    continue;
                
                if (segments[0].Contains("STR") == false) 
                    continue;

                double lat = double.Parse(segments[9], CultureInfo.InvariantCulture);
                double lon = double.Parse(segments[10], CultureInfo.InvariantCulture);

                retval.Add(new CorrectionStation(segments[1], lat, lon));
            }

            return retval;
        }
    }
}
