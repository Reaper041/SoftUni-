using System;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char mathOperator = char.Parse(Console.ReadLine());

            double result = 0;
            string evenOdd = string.Empty;

            if (mathOperator == '+')
            {
                result = num1 + num2;
                if (result % 2 == 0) evenOdd = "even";
                else evenOdd = "odd";

                Console.WriteLine($"{num1} {mathOperator} {num2} = {result} - {evenOdd}");
            }
            else if (mathOperator == '-')
            {
                result = num1 - num2;
                if (result % 2 == 0) evenOdd = "even";
                else evenOdd = "odd";

                Console.WriteLine($"{num1} {mathOperator} {num2} = {result} - {evenOdd}");
            }
            else if (mathOperator == '*')
            {
                result = num1 * num2;
                if (result % 2 == 0) evenOdd = "even";
                else evenOdd = "odd";

                Console.WriteLine($"{num1} {mathOperator} {num2} = {result} - {evenOdd}");
            }
            else if (mathOperator == '/')
            {
                result = num1 * 1.0 / num2;

                if (num2 != 0) Console.WriteLine($"{num1} / {num2} = {result:f2}");
                else Console.WriteLine($"Cannot divide {num1} by zero");
            }
            else
            {
                result = num1 * 1.0 % num2;

                if (num2 != 0) Console.WriteLine($"{num1} % {num2} = {result}");
                else Console.WriteLine($"Cannot divide {num1} by zero");
            }
        }
    }
}
