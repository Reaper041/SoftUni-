using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int seasonNum = int.Parse(Console.ReadLine());
            string season;

            if (seasonNum == 1 || seasonNum == 2 || seasonNum == 12)
            {
                season = "Зима";
            }
            else if (seasonNum == 3 || seasonNum == 4 || seasonNum == 5)
            {
                season = "Пролет";
            }
            else if (seasonNum == 6 || seasonNum == 7 || seasonNum == 8)
            {
                season = "Лято";
            }
            else if (seasonNum == 9 || seasonNum == 10 || seasonNum == 11)
            {
                season = "Есен";
            }
            else
            {
                season = "Не е валиден месец";
            }

            Console.WriteLine(season);
        }
    }
}
