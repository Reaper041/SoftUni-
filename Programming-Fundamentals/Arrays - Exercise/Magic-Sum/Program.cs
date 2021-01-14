using System;
using System.Linq;

namespace Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int specialNum = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < nums.Length; i++)
            {
                bool isSpecial = false;
                int[] specialArr = new int[2];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == specialNum)
                    {
                        specialArr = new int[] { nums[i], nums[j] };
                        isSpecial = true;
                    }
                }
                if (isSpecial)
                {
                Console.WriteLine(string.Join(' ', specialArr));
                }
            }

        }
    }
}
