using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesArr = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] rosesArr = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> roses = new Queue<int>(rosesArr);

            Stack<int> lilies = new Stack<int>(liliesArr);

            int stored = 0;
            int wreaths = 0;

            while (roses.Count > 0 && lilies.Count > 0)
            {
                int rosesCount = roses.Peek();
                int liliesCount = lilies.Pop();
                int sum = rosesCount + liliesCount;

                if (sum == 15)
                {
                    roses.Dequeue();
                    wreaths++;
                }
                else if (sum > 15)
                {
                    lilies.Push(liliesCount - 2);

                }
                else
                {
                    roses.Dequeue();
                    stored += sum;
                }
            }

            wreaths += stored / 15;

            if (wreaths < 5)
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
            else
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
        }
    }
}
