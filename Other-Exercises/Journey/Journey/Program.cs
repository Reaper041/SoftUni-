using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double spent = 0;
            string destination = string.Empty;
            string nightSpending = string.Empty;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    spent = 0.3 * budget;
                    nightSpending = "Camp";
                }
                else
                {
                    spent = 0.7 * budget;
                    nightSpending = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    spent = 0.4 * budget;
                    nightSpending = "Camp";
                }
                else
                {
                    spent = 0.8 * budget;
                    nightSpending = "Hotel";
                }
            }
            else
            {
                destination = "Europe";
                spent = 0.9 * budget;
                nightSpending = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{nightSpending} - {spent:f2}");
        }
    }
}
