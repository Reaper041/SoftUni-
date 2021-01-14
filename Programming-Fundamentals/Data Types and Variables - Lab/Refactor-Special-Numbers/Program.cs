using System;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;
            for (int i = 1; i <= n; i++)
            {
                bool isSpecial = false;
                num = i;
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecial);
                sum = 0;
            }

        }
    }
}
