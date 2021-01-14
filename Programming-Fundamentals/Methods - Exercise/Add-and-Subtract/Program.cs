using System;

namespace Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            double sum = Sum(firstNum, secondNum);
            double subtract = Subtract(thirdNum, sum);

            Console.WriteLine(subtract);
        }

        private static double Subtract(int thirdNum, double sum)
        {
            double subtract = sum - thirdNum;
            return subtract;
        }

        static double Sum(int firstNum, int secondNum)
        {
            int sum = firstNum + secondNum;
            return sum;
        }
    }
}
