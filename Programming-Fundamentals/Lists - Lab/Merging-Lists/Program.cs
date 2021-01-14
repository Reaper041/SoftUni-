using System;
using System.Collections.Generic;
using System.Linq;

namespace Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList(); 
            List<int> secondNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < Math.Min(numbers.Count, secondNumbers.Count); i++)
            {
                result.Add(numbers[i]);
                result.Add(secondNumbers[i]);
            }

            if (numbers.Count > secondNumbers.Count)
            {
                for (int i = secondNumbers.Count; i < numbers.Count; i++)
                {
                    result.Add(numbers[i]);
                }
            }
            else
            {
                for (int i = numbers.Count; i < secondNumbers.Count; i++)
                {
                    result.Add(secondNumbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
