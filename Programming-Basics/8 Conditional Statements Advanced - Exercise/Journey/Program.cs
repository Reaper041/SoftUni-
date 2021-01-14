using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double spendedMoney = 0;
            string holidayKind = string.Empty;
            string destination = string.Empty;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    holidayKind = "Camp";
                    spendedMoney = 0.3 * budget;
                }
                else
                {
                    holidayKind = "Hotel";
                    spendedMoney = 0.7 * budget;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    holidayKind = "Camp";
                    spendedMoney = 0.4 * budget;
                }
                else
                {
                    holidayKind = "Hotel";
                    spendedMoney = 0.8 * budget;
                }
            }
            else
            {
                destination = "Europe";
                holidayKind = "Hotel";
                spendedMoney = 0.9 * budget;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{holidayKind} - {spendedMoney:f2}");
        }
    }
}
