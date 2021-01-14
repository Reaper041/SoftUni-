using System;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeSec1 = int.Parse(Console.ReadLine());
            int timeSec2 = int.Parse(Console.ReadLine());
            int timeSec3 = int.Parse(Console.ReadLine());

            int totalSec = timeSec1 + timeSec2 + timeSec3;
            int mins = 0;

            if (totalSec >= 180)
            {
                totalSec -= 180;
                mins += 3;
            }
            else if (totalSec >= 120)
            {
                totalSec -= 120;
                mins += 2;
            }
            else if (totalSec >= 60)
            {
                totalSec -= 60;
                mins++;
            }

            if (totalSec < 10)
            {
                Console.WriteLine($"{mins}:0{totalSec}");
            }
            else
            {
                Console.WriteLine($"{mins}:{totalSec}");
            }
        }
    }
}
