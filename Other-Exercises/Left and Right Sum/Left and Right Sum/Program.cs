using System;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;
            int diff = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                leftSum += num; 
            }
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                rightSum += num;
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine("Yes, sum = " + leftSum);
            }
            else
            {
                diff = Math.Abs(leftSum - rightSum);
                Console.WriteLine("No, diff = " + diff);
            }
        }
    }
}
