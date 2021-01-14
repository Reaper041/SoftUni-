using System;

namespace Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0m;
            for (int num = 0; num < n; num++)
            {
                decimal value = decimal.Parse(Console.ReadLine());

                sum += value;
            }
            Console.WriteLine(sum);
        }
    }
}
