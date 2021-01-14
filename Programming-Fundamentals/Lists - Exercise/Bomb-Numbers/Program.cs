using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] spNumAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (numbers.Contains(spNumAndPower[0]))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == spNumAndPower[0])
                    {
                        int startIndex = i - spNumAndPower[1];
                        int endIndex = i + spNumAndPower[1];

                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }

                        if (endIndex > numbers.Count - 1)
                        {
                            endIndex = numbers.Count - 1;
                        }

                        int endIndexToRemove = endIndex - startIndex + 1;
                        numbers.RemoveRange(startIndex, endIndexToRemove);
                    }

                    
                }
            }

            int sum = 0;

            foreach (var VARIABLE in numbers)
            {
                sum += VARIABLE;
            }

            Console.WriteLine(sum);
        }
    }
}
