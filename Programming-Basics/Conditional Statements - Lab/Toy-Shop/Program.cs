using System;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double holiday = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dulls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double total = puzzles * 2.6 + dulls * 3.0 + teddyBears * 4.10 + minions * 8.20 + trucks * 2;
            double discount = 0;

            if (puzzles + dulls + teddyBears + minions + trucks >= 50)
            {
                discount = 0.25 * total;
                total -= discount;
            }

            total -= total * 0.1;

            if (total >= holiday)
            {
                Console.WriteLine($"Yes! {total - holiday:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {holiday - total:f2} lv needed.");
            }
        }
    }
}
