using System;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string from = Console.ReadLine();
            string to = Console.ReadLine();
            double inMeters = 0;
            double result = 0;

            if (from == "mm") inMeters = number / 1000;
            else if (from == "cm") inMeters = number / 100;
            else if (from == "m") inMeters = number;

            if (to == "mm") result = inMeters * 1000;
            else if (to == "cm") result = inMeters * 100;
            else if (to == "m") result = inMeters;

            Console.WriteLine($"{result:f3}");
        }
    }
}
