using System;
using System.Runtime.InteropServices;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double gamesInSofiaSat = (48 - h) * 3.0 / 4;
            double gamesInSofiaHoliday = p * 2.0 / 3;
            double total = gamesInSofiaHoliday + gamesInSofiaSat + h;

            if (yearType == "leap")
            {
                total += total * 0.15;
            }

            Console.WriteLine(Math.Floor(total));
        }
    }
}
