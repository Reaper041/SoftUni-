using System;

namespace Godzilla_vs_Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double statists = double.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());

            double diff = 0;

            if (statists > 150)
            {
                clothingPrice = 0.9 * clothingPrice;
            }

            double totalPrice = statists * clothingPrice + 0.1 * budget;

            diff = totalPrice - budget;
            if (totalPrice > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(diff):f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {Math.Abs(diff):f2} leva left.");
            }
        }
    }
}
