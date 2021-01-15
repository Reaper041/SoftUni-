using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine().ToLower();
            int holiday = int.Parse(Console.ReadLine());
            int weekends = int.Parse(Console.ReadLine());

            double weekendsInSofia = (48 - weekends) * 0.75;
            double gamesInHolidays = holiday * 2.0 / 3;
            double sumGames = weekendsInSofia + weekends + gamesInHolidays;

            if (year == "leap")
            {
                Console.WriteLine(Math.Floor(sumGames + 0.15 * sumGames));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(sumGames));
            }
        }
    }
}
