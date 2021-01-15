using System;

namespace Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (num < evenMin) evenMin = num;
                    if (num > evenMax) evenMax = num;
                }
                else
                {
                    oddSum += num;
                    if (num < oddMin) oddMin = num;
                    if (num > oddMax) oddMax = num;
                }
            }
            if (n >= 2)
            {
                Console.WriteLine($"OddSum = {oddSum}");
                Console.WriteLine($"OddMin = {oddMin}");
                Console.WriteLine($"OddMax = {oddMax}");
                Console.WriteLine($"EvenSum = {evenSum}");
                Console.WriteLine($"EvenMin = {evenMin}");
                Console.WriteLine($"EvenMax = {evenMax}");
            }
            else if (n == 1)
            {
                Console.WriteLine($"OddSum = {oddSum}");
                Console.WriteLine($"OddMin = {oddMin}");
                Console.WriteLine($"OddMax = {oddMax}");
                Console.WriteLine($"EvenSum = {evenSum}");
                Console.WriteLine($"EvenMin = No");
                Console.WriteLine($"EvenMax = No");
            }
            else
            {
                Console.WriteLine($"OddSum = {oddSum}");
                Console.WriteLine($"OddMin = No");
                Console.WriteLine($"OddMax = No");
                Console.WriteLine($"EvenSum = {evenSum}");
                Console.WriteLine($"EvenMin = No");
                Console.WriteLine($"EvenMax = No");
            }
        }
    }
}
