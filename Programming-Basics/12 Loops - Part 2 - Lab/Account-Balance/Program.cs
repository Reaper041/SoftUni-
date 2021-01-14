using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int transactions = int.Parse(Console.ReadLine());

            double total = 0;

            for (int i = 0; i < transactions; i++)
            {
                double value = double.Parse(Console.ReadLine());

                if (value < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Increase: {value:f2}");
                    total += value;
                }
            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
