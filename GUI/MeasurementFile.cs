using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    class MeasurementFile
    {
        public List<GeoCoordinate> coordinates;

        public MeasurementFile(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            this.coordinates = new List<GeoCoordinate>();
            // Skip first line
            for (int i = 0; i < lines.Length; ++i)
            {
                string[] content = lines[i].Split(';');
                // 16: latitude
                // 17: longitude
                // 4: latitude degree
                // 5: latitude seconds
                // 6: latitude dir
                // 7: longitude degree
                // 8: longitude seconds
                // 9: longitude dir
                try
                {
                    double latitude = Convert.ToDouble(content[16]);
                    double longitude = Convert.ToDouble(content[17]);
                    GeoCoordinate coordinate = new GeoCoordinate();
                    coordinate.latitude = latitude;
                    coordinate.longitude = longitude;
                    coordinates.Add(coordinate);
                }
                catch (Exception) 
                { 
                    continue; 
                }
            }
        }
    }
}
