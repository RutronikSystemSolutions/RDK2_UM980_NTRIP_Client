using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    public class CorrectionStation
    {
        public string name;
        public double lat;
        public double lon;

        public CorrectionStation(string name, double lat, double lon)
        {
            this.name = name;
            this.lat = lat;
            this.lon = lon;
        }

        public double DistanceTo(double lat, double lon)
        {
            return GeoCoordinate.GetDistance(this.lon, this.lat, lon, lat);
        }
    }
}
