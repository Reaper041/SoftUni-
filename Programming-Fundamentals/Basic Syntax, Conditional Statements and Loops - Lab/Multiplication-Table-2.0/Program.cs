using System;

namespace Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            if (times > 10)
            {
                Console.WriteLine($"{integer} X {times} = {integer * times}");
            }
            else
            {
                for (int i = times; i <= 10; i++)
                {
                    int product = integer * i;
                    Console.WriteLine($"{integer} X {i} = {product}");
                }
            }
        }
    }
}
