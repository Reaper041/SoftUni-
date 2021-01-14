using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rating = Console.ReadLine();

            double total = 0;
            double discount = 0;

            switch (room)
            {
                case "room for one person":
                    total = 18 * (days - 1);
                    break;
                case "apartment":
                    if (days < 10)
                    {
                        discount = 0.3 * 25 * (days - 1);
                        total = 25 * (days - 1) - discount;
                    }
                    else if (days <= 15)
                    {
                        discount = 0.35 * 25 * (days - 1);
                        total = 25 * (days - 1) - discount;
                    }
                    else
                    {
                        discount = 0.5 * 25 * (days - 1);
                        total = 25 * (days - 1) - discount;
                    }
                    break;
                case "president apartment":
                    if (days < 10)
                    {
                        discount = 0.1 * 35 * (days - 1);
                        total = 35 * (days - 1) - discount;
                    }
                    else if (days <= 15)
                    {
                        discount = 0.15 * 35 * (days - 1);
                        total = 35 * (days - 1) - discount;
                    }
                    else
                    {
                        discount = 0.2 * 35 * (days - 1);
                        total = 35 * (days - 1) - discount;
                    }
                    break;
                default:
                    break;
            }

            if (rating == "negative")
            {
                total -= total * 0.1;
            }
            else
            {
                total += total * 0.25;
            }

            Console.WriteLine($"{total:f2}");
        }
    }
}
