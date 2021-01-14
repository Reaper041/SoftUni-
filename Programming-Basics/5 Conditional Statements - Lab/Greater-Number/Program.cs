using System;

namespace Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Max(num1, num2));
        }
    }
}
