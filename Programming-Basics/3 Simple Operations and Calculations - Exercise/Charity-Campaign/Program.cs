using System;

namespace Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double confectioners = double.Parse(Console.ReadLine());
            double cakes = double.Parse(Console.ReadLine());
            double waffles = double.Parse(Console.ReadLine());
            double pancakes = double.Parse(Console.ReadLine());

            double totalCakes = cakes * confectioners * days;
            double totalWaffles = waffles * confectioners * days;
            double totalPancakes = pancakes * confectioners * days;

            double priceCakes = totalCakes * 45;
            double pricePancakes = totalPancakes * 3.2;
            double priceWaffles = totalWaffles * 5.8;

            double totalPrice = priceCakes + pricePancakes + priceWaffles;
            double profit = totalPrice - 1.0 / 8 * totalPrice;

            Console.WriteLine($"{profit:f2}");

        }
    }
}
