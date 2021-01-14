using System;
using System.Linq;

namespace Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            numbers = numbers.OrderByDescending(n => n).Take(3).ToArray();

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

        }
    }
}
