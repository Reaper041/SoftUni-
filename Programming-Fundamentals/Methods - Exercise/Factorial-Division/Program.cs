using System;

namespace Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = int.Parse(Console.ReadLine());
            double second = int.Parse(Console.ReadLine());

            double firstResult = 1;
            double secondResult = 1;
            for (double i = 1; i <= first; i++)
            {
                firstResult *= i;
            }

            for (double i = 1; i <= second; i++)
            {
                secondResult *= i;
            }

            Console.WriteLine($"{firstResult / secondResult:f2}");
        }
    }
}
