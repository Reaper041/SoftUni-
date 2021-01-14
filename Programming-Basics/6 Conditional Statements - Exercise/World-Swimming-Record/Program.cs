using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSec = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secsPerMeter = double.Parse(Console.ReadLine());

            double delay = Math.Floor(meters / 15.0) * 12.5;

            string result = string.Empty;
            double diff = Math.Abs((delay + meters * secsPerMeter) - recordInSec);

            if (recordInSec <= secsPerMeter * meters + delay)
            {
                result = string.Format($"No, he failed! He was {diff:f2} seconds slower.");
            }
            else
            {
                result = string.Format($"Yes, he succeeded! The new world record is {meters * secsPerMeter + delay:f2} seconds.");
            }
            Console.WriteLine(result);
        }
    }
}
