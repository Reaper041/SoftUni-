using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] pricesWithVAT = Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .Select(x => x + x * 0.2m)
                .ToArray();

            foreach (var price in pricesWithVAT)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
