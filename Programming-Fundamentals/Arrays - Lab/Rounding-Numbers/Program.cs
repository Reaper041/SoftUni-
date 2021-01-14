using System;
using System.Linq;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] numbersArr = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            for (int i = 0; i < numbersArr.Length; i++)
            {

                if (numbersArr[i] == -0)
                {
                    numbersArr[i] = 0;
                }
                Console.WriteLine($"{numbersArr[i]} => {Math.Round(numbersArr[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
