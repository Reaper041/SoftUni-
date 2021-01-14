using System;

namespace Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());
            double power = int.Parse(Console.ReadLine());

            double total = PoweredNum(number, power);
            Console.WriteLine(total);
        }

        static double PoweredNum(double number, double power)
        {
            double powered = 1;
            for (int i = 0; i < power; i++)
            {
                powered *= number;
            }

            return powered;
        }
    }
}
