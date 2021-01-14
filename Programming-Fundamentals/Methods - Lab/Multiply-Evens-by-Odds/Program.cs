using System;

namespace Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int total = GetMultipleOfEvenAndOdds(number);

            Console.WriteLine(total);
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sumOfEvens = 0;
            while (number != 0)
            {
                if (Math.Abs(number % 10) % 2 == 0)
                {
                    sumOfEvens += Math.Abs(number % 10);
                }
                number /= 10;
            }

            return sumOfEvens;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sumOfOdds = 0;
            while (number != 0)
            {
                if (Math.Abs(number % 10) % 2 == 1)
                {
                    sumOfOdds += Math.Abs(number % 10);
                }
                number /= 10;
            }

            return sumOfOdds;
        }
    }
}
