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
        public string identifier;
        public string format;
        public string navigationSystem;
        public string country;
        public double lat;
        public double lon;
        public int nmeaRequested;

        public CorrectionStation(string name, string identifier, string format, string navigationSystem, string country, double lat, double lon, int nmeaRequested)
        {
            this.name = name;
            this.identifier = identifier;
            this.format = format;
            this.navigationSystem = navigationSystem;
            this.country = country;
            this.lat = lat;
            this.lon = lon;
            this.nmeaRequested = nmeaRequested;
        }

        public double DistanceTo(double lat, double lon)
        {
            return GeoCoordinate.GetDistance(this.lon, this.lat, lon, lat);
        }
    }
}
