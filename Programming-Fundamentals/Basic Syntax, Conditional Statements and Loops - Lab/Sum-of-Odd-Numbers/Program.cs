using System;

namespace Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());
            int sum = 0;
            int num = 1;
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                Console.WriteLine(num);
                sum += num;
                num += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
