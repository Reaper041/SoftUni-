using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<prize>\d+\.?\d*)!(?<quantity>\d+)";
            List<string> items = new List<string>();
            string input = Console.ReadLine();
            double total = 0;

            while (input != "Purchase")
            {
                Regex regex = new Regex(pattern);
                var match = regex.Match(input);
                if (match.Success)
                {

                    string furniture = match.Groups[1].Value;
                    double prize = double.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);
                    total += prize * quantity;
                    items.Add(furniture);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
