using System;

namespace Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNum = int.Parse(Console.ReadLine());

            string[] daysOfWeek = new string[]
            {"Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
            };

            if (dayNum < 1 || dayNum > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine("{0}", daysOfWeek[dayNum-1]);
            }
        }
    }
}
