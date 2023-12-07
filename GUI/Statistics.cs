using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    public class Statistics
    {
        private int maxValueCount = 1000;
        private List<double> values = new List<double>();


        public void pushData(double value)
        {
            values.Add(value);
            if (values.Count > maxValueCount) values.RemoveAt(0);
        }

        public void clear()
        {
            values.Clear();
        }

        public double Average()
        {
            return Average(values);
        }

        public double StandardDeviation()
        {
            return StandardDeviation(values);
        }

        public static double Average(List<double> array)
        {
            double retval = 0;
            for (int i = 0; i < array.Count; ++i)
            {
                retval += array[i];
            }
            return retval / (double)array.Count;
        }

        public static double StandardDeviation(List<double> array)
        {
            double avg = Average(array);
            double sum = 0;
            for (int i = 0; i < array.Count; ++i)
            {
                double tmp = (array[i] - avg);
                tmp = tmp * tmp;
                sum += tmp;
            }

            sum = sum / array.Count;
            return Math.Sqrt(sum);
        }
    }
}