using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigger_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = double.Parse(Console.ReadLine());
            var num2 = double.Parse(Console.ReadLine());

            if (num1 < num2)
            {
                Console.WriteLine(num2);
            }
            else
            {
                Console.WriteLine(num1);
            }
        }
    }
}
