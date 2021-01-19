using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> clothes = new Stack<int>(input);
            int rackCapacity = int.Parse(Console.ReadLine());
            int totalSum = 0;
            int count = 0;

            while (clothes.Any())
            {
                if (clothes.Peek() + totalSum > rackCapacity)
                {
                    totalSum = 0;
                    count++;
                }
                else
                {
                    totalSum += clothes.Pop();
                }
            }

            count++;
            Console.WriteLine(count);
        }
    }
}
