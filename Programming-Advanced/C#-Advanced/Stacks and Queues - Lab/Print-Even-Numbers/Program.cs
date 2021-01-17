using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Queue<double> evenNums = new Queue<double>();

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNums.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
