using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lower = range[0];
            int upper = range[1];

            string condition = Console.ReadLine().ToLower();

            Func<int, int, List<int>> getNumsInRange = (lower, upper) =>
            {
                List<int> nums = new List<int>();
                for (int i = lower; i <= upper; i++)
                {
                    nums.Add(i);
                }

                return nums;
            };

            List<int> numsInRange = getNumsInRange(lower, upper);

            Predicate<int> predicate = null;

            if (condition == "odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (condition == "even")
            {
                predicate = n => n % 2 == 0;
            }


            Console.WriteLine(string.Join(" ", MyWhere(numsInRange, predicate)));
        }

        static List<int> MyWhere(List<int> nums, Predicate<int> predicate)
        {
            List<int> filtered = new List<int>();

            foreach (var num in nums)
            {
                if (predicate(num))
                {
                    filtered.Add(num);
                }
            }

            return filtered;
        }
    }
}
