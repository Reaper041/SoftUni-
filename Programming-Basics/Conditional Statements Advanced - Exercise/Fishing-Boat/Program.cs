using System;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double total = 0;

            if (season == "Spring")
            {
                total = 3000;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                total = 4200;
            }
            else if (season == "Winter")
            {
                total = 2600;
            }

            if (fishermans <= 6)
            {
                total -= total * 0.1;
            }
            else if (fishermans <= 11)
            {
                total -= total * 0.15;
            }
            else if (fishermans > 12)
            {
                total -= total * 0.25;
            }

            if (fishermans % 2 == 0 && season != "Autumn")
            {
                total -= total * 0.05;
            }

            double diff = Math.Abs(total - budget);

            if (total <= budget)
            {
                Console.WriteLine($"Yes! You have {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {diff:f2} leva.");
            }
        }
    }
}
