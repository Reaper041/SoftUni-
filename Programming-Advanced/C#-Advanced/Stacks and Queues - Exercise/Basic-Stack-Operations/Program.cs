using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> nums = new Stack<int>();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            for (int i = 0; i < n; i++)
            {
                nums.Push(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                nums.Pop();
            }

            if (nums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (nums.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(nums.Min());
            }
        }
    }
}
