using System;

namespace Time_Plus_15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());

            min += 15;

            if (min >= 60)
            {
                hour++;
                min -= 60;
            }
            else if (min >= 120)
            {
                hour += 2;
                min -= 120;
            }

            if (hour >= 24) hour -= 24;

            if (min < 10) Console.WriteLine($"{hour}:0{min}");
            else Console.WriteLine("{0}:{1}", hour, min);
        }
    }
}
