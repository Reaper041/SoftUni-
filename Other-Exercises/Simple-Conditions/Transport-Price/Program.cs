using System;

namespace Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            double distance = int.Parse(Console.ReadLine());
            string period = Console.ReadLine();
            double taxitariff = 0.0;
            double price = 0.0;

            if (period == "day" && distance < 20)
            {
                taxitariff = 0.79;
            }
            else if (period == "night" && distance < 20)
            {
                taxitariff = 0.9;
            }

            if (distance < 20)
            {
                price = 0.7 + taxitariff * distance;
            }
            else if (distance >= 20 && distance < 100)
            {
                price = 0.09 * distance;
            }
            else if (distance >= 100)
            {
                price = 0.06 * distance;
            }

            Console.WriteLine(price);
        }
    }
}
