using System;
using System.Collections.Generic;
using System.Linq;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<double> sums = new List<double>();
            double num = 0.0;
            double leftSum = 0;
            double sum = 0;

            foreach (var str in input)
            {
                num = int.Parse(str.Substring(1, str.Length - 2));

                if (char.IsLower(str[0]))
                {
                    leftSum = num * (char.ToUpper(str[0]) - 64);
                }
                else
                {
                    leftSum = num / (char.ToUpper(str[0]) - 64);
                }

                if (char.IsLower(str[str.Length - 1]))
                {
                    sum = leftSum + (char.ToUpper(str[str.Length - 1]) - 64);
                }
                else
                {
                    sum = leftSum - (char.ToUpper(str[str.Length - 1]) - 64);
                }

                sums.Add(sum);
            }

            Console.WriteLine($"{sums.Sum(x => x):f2}");
        }
    }
}
