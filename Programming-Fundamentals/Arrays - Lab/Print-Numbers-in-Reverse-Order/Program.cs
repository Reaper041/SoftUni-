using System;

namespace Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                nums[i] = number;
            }
            Array.Reverse(nums);

            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
        }
    }
}
