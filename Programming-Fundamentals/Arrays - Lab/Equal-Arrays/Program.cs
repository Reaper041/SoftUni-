using System;
using System.Linq;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumFirstArr = 0;
            int sumSecondArr = 0;

            bool flag = false;
            for (int i = 0; i < firstArr.Length; i++)
            {
                if (firstArr[i] != secondArr[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    flag = true;
                    break;
                }
                sumFirstArr += firstArr[i];
                sumSecondArr += secondArr[i];
            }

            if (flag)
            {

            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumFirstArr}");
            }

        }
    }
}
