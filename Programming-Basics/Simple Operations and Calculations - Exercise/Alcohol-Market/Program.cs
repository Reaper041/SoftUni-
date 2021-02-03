using System;

namespace Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWhiskey = double.Parse(Console.ReadLine());
            double quantityBeer = double.Parse(Console.ReadLine());
            double quantityWine = double.Parse(Console.ReadLine());
            double quantityRaki = double.Parse(Console.ReadLine());
            double quantityWhiskey = double.Parse(Console.ReadLine());

            double priceRaki = priceWhiskey / 2;
            double priceWine = 60.0 / 100 * priceRaki;
            double priceBeer = 20.0 / 100 * priceRaki;

            double totalPriceBeer = priceBeer * quantityBeer;
            double totalPriceWine = priceWine * quantityWine;
            double totalPriceRaki = priceRaki * quantityRaki;
            double totalPriceWhiskey = priceWhiskey * quantityWhiskey;

            double total = totalPriceBeer + totalPriceRaki + totalPriceWhiskey + totalPriceWine;

            Console.WriteLine($"{total:f2}");
        }
    }
}
