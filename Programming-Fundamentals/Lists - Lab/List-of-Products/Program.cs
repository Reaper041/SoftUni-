using System;
using System.Collections.Generic;

namespace List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>(n);
            for (int j = 0; j < n; j++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();
            int i = 0;

            foreach (var VARIABLE in products)
            {
                i++;
                Console.WriteLine($"{i}.{VARIABLE}");
            }
        }
    }
}
