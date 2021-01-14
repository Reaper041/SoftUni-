using System;
using System.Xml;

namespace Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int input = num;
            int current = 0;
            int factorialSum = 0;
            while (num != 0)
            {
                current = num % 10;
                num /= 10;

                int factorial = 1;

                for (int i = 1; i <= current; i++)
                {
                    factorial *= i;
                }
                factorialSum += factorial;
            }
            if (factorialSum == input)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            
        }
    }
}
