using System;
using System.Linq;
using System.Text;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine().TrimStart('0');
            int num2 = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            int temp = 0;

            if (num2 == 0 || num1 == "")
            {
                Console.WriteLine(0);
                return;
            }

            foreach (char dig in num1.Reverse())
            {
                int num = int.Parse(dig.ToString());
                int result = num * num2 + temp;

                int restDigit = result % 10;
                temp = result / 10;

                sb.Insert(0, restDigit);
            }

            if (temp != 0)
            {
                sb.Insert(0, temp);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
