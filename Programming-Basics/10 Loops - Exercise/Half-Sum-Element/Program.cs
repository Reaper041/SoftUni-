using System;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int maxNum = int.MinValue;

            for (int number = 1; number <= n; number++)
            {
                int result = int.Parse(Console.ReadLine());

                if (result > maxNum)
                {
                    maxNum = result;
                }
                sum += result;

            }

            int diff = (maxNum * 2) - sum;
            if (diff == 0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(diff)}");
            }
        }
    }
}
