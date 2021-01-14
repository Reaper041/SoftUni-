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

            for (int number = 1; number <= n; number++)
            {
                int leftNums = int.Parse(Console.ReadLine());

                leftSum += leftNums;
            }
            for (int number = 1; number <= n; number++)
            {
                int rightNums = int.Parse(Console.ReadLine());

                rightSum += rightNums;
            }

            if (leftSum == rightSum) Console.WriteLine($"Yes, sum = {leftSum}");
            else Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
        }
    }
}
