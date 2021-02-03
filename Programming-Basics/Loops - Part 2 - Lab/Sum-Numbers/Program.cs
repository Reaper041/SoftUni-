using System;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int sum = 0;

            while (num != "Stop")
            {
                sum += int.Parse(num);
                num = Console.ReadLine();
            }
            Console.WriteLine(sum);
        }
    }
}
