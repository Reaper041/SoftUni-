using System;

namespace Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SingOfInt(n);
        }

        static void SingOfInt(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else
            {
                Console.WriteLine("The number 0 is zero.");
            }
        }
    }
}
