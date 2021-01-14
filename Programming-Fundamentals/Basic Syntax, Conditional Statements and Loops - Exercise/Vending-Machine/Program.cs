using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coins = Console.ReadLine();
            double totalCoins = 0;
            while (coins != "Start")
            {
                if (coins == "0.1" || coins == "0.2" || coins == "0.5"
                    || coins == "1" || coins == "2")
                {
                    totalCoins += double.Parse(coins);
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                coins = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts" && totalCoins >= 2.0)
                {
                    Console.WriteLine($"Purchased nuts");
                    totalCoins -= 2.0;
                }
                else if (product == "Water" && totalCoins >= 0.7)
                {
                    Console.WriteLine($"Purchased water");
                    totalCoins -= 0.7;
                }
                else if (product == "Crisps" && totalCoins >= 1.5)
                {
                    Console.WriteLine($"Purchased crisps");
                    totalCoins -= 1.5;
                }
                else if (product == "Soda" && totalCoins >= 0.8)
                {
                    Console.WriteLine($"Purchased soda");
                    totalCoins -= 0.8;
                }
                else if (product == "Coke" && totalCoins >= 1.0)
                {
                    Console.WriteLine($"Purchased coke");
                    totalCoins -= 1.0;
                }
                else if (product != "Nuts" && product != "Water" && 
                    product != "Crisps" && product != "Soda" && product != "Coke")
                {
                    Console.WriteLine("Invalid product");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalCoins:f2}");
        }
    }
}
