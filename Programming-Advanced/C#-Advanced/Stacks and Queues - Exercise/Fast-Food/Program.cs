using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(input);
            int biggest = orders.Max();
            Console.WriteLine(biggest);

            while (orders.Any())
            {
                if (orders.Peek() <= foodQuantity)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
