using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> reverse =
                nums =>
                {
                    List<int> newList = new List<int>();

                    for (int i = nums.Count - 1; i >= 0; i--)
                    {
                        newList.Add(nums[i]);
                    }

                    return newList;
                };

            nums = reverse(nums);


            Predicate<int> isDivisible = num => num % n == 0;

            Console.WriteLine(string.Join(' ', nums.Where(n => !isDivisible(n))));
        }
    }
}
