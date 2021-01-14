using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int smallest = SmallestInt(firstNum, secondNum, thirdNum);
            Console.WriteLine(smallest);
        }

        static int SmallestInt(int num1, int num2, int num3)
        {
            return Math.Min(num1, Math.Min(num2, num3));
        }
    }
}
