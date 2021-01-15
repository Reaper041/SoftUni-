using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());
            var bonus = 0.0;

            if (num <= 100)
            {
                bonus = 5;
            }
            else if (num > 100 && num < 1000)
            {
                bonus = 20.0 / 100 * num;
            }
            else if (num > 1000)
            {
                bonus = 10.0 / 100 * num; 
            }

            if (num % 2 == 0)
            {
                bonus += 1;
            }
            else if (num % 10 == 5)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(num + bonus);
        }
    }
}
