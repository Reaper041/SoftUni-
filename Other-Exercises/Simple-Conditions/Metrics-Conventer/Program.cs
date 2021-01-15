using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics_Conventer
{
    class Program
    {
        static void Main(string[] args)
        {
            var distance = double.Parse(Console.ReadLine());
            var sourseMetric = Console.ReadLine().ToLower();
            var destMetric= Console.ReadLine().ToLower();

            if (sourseMetric == "mm")
            {
                distance /= 1000;
            }
            else if (sourseMetric == "cm")
            {
                distance /= 100;
            }
            else if (sourseMetric == "mi")
            {
                distance /= 0.000621371192;
            }
            else if (sourseMetric == "in")
            {
                distance /= 39.3700787;
            }
            else if (sourseMetric == "km")
            {
                distance /= 0.001;
            }
            else if (sourseMetric == "ft")
            {
                distance /= 3.2808399;
            }
            else if (sourseMetric == "yd")
            {
                distance /= 1.0936133;
            }
            else if (sourseMetric == "m")
            {
                distance /= 1;
            }

            if (destMetric == "mm")
            {
                distance *= 1000;
            }
            else if (destMetric == "cm")
            {
                distance *= 100;
            }
            else if (destMetric == "mi")
            {
                distance *= 0.000621371192;
            }
            else if (destMetric == "in")
            {
                distance *= 39.3700787;
            }
            else if (destMetric == "km")
            {
                distance *= 0.001;
            }
            else if (destMetric == "ft")
            {
                distance *= 3.2808399;
            }
            else if (destMetric == "yd")
            {
                distance *= 1.0936133;
            }
            else if (destMetric == "m")
            {
                distance *= 1;
            }

            Console.WriteLine(distance);
        }
    }
}
