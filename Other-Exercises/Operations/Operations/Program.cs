using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal N1 = decimal.Parse(Console.ReadLine());
            decimal N2 = decimal.Parse(Console.ReadLine());
            string mathOperator = Console.ReadLine();

            decimal result = 0.0M;
            string evenOdd = string.Empty;
            string model = string.Empty;

            if ((N2 == 0) && (mathOperator.Equals("/") || mathOperator.Equals("%")))
            {
                model = string.Format($"Cannot divide {N1} by zero");
            }
            else if (mathOperator == "/")
            {
                result = N1 / N2;
                model = string.Format($"{N1} / {N2} = {result:f2}");
            }
            else if (mathOperator == "%")
            {
                result = N1 % N2;
                model = string.Format($"{N1} % {N2} = {result}");
            }
            else if (mathOperator == "+")
            {
                result = N1 + N2;
                model = string.Format("{0} {1} {2} = {3} - {4}",
                    N1, mathOperator, N2, result, result % 2 == 0 ? "even" : "odd");
            }
            else if (mathOperator == "-")
            {
                result = N1 - N2;
                model = string.Format("{0} {1} {2} = {3} - {4}",
                    N1, mathOperator, N2, result, result % 2 == 0 ? "even" : "odd");
            }
            else
            {
                result = N1 * N2;
                model = string.Format("{0} {1} {2} = {3} - {4}",
                    N1, mathOperator, N2, result, result % 2 == 0 ? "even" : "odd");
            }
            Console.WriteLine(model);

        }
    }
}
