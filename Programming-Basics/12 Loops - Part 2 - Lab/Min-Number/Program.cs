using System;

namespace Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int minValue = int.MaxValue;
            while (n > 0)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < minValue)
                {
                    minValue = number;
                }
                n--;
            }
            Console.WriteLine(minValue);
        }
    }
}
