using System;

namespace Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine());
            double priceOfEgg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());

            double totalFlourPrice = students * priceOfFlour - (students / 5) * priceOfFlour;
            double totalEggPrice = students * 10 * priceOfEgg;
            double totalApronPrice = (students + (Math.Ceiling(0.2 * students))) * priceOfApron;
            double total = totalApronPrice + totalEggPrice + totalFlourPrice;

            if (budget >= total)
            {
                Console.WriteLine($"Items purchased for {Math.Ceiling(total):f2}$.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(budget - Math.Ceiling(total)):f2}$ more needed.");
            }
        }
    }
}
