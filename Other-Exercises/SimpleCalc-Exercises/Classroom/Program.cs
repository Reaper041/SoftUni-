using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Дължина на залата = ");
            
            double l = double.Parse(Console.ReadLine());
            
            Console.Write("Ширина на залата = ");

            double w = double.Parse(Console.ReadLine());

            double rows = Math.Floor(l / 1.20);
            double cols = Math.Truncate((w - 1) / 0.70);

            Console.WriteLine(rows * cols - 3);



        }
    }
}
