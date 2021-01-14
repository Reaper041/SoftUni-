using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxValue = int.MinValue;
            while (n > 0)
            {
                int number = int.Parse(Console.ReadLine());

                if (number > maxValue)
                {
                    maxValue = number;
                }
                n--;
            }
            Console.WriteLine(maxValue);
        }
    }
}
