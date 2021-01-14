using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Dictionary<string, double> products = new Dictionary<string, double>();
            Dictionary<string, int> itemAndQuantity = new Dictionary<string, int>();
            int index = 0;

            while (input[0] != "buy")
            {
                string item = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                double total = price * quantity;

                if (itemAndQuantity.ContainsKey(item))
                {
                    itemAndQuantity[item] += quantity;
                }
                else
                {
                    itemAndQuantity.Add(item, quantity);
                }

                if (products.ContainsKey(item))
                {
                    products[item] = itemAndQuantity[item] * price;
                }
                else
                {
                    products.Add(item, total);
                }

                input = Console.ReadLine().Split();
                index++;
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value:f2}");
            }
        }
    }
}
