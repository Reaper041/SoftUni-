using System;

namespace Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            while (Math.Abs(num) % 2 == 1)
            {
                if (Math.Abs(num) % 2 == 1)
                {
                    Console.WriteLine("Please write an even number.");
                }
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {Math.Abs(num)}");
        }
    }
}
