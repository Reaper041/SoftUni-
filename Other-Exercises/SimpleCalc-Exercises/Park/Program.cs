using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park
{
    class Program
    {
        static void Main(string[] args)
        {
            double parkside = double.Parse(Console.ReadLine());
            double wplate = double.Parse(Console.ReadLine());
            double lplate = double.Parse(Console.ReadLine());
            double wbench = double.Parse(Console.ReadLine());
            double lbench = double.Parse(Console.ReadLine());

            double parkarea = parkside * parkside;
            double bencharea = wbench * lbench;
            double platearea = wplate * lplate;

            double platesneeded = (parkarea - bencharea) / platearea;
            double timeneeded = platesneeded * 0.2;

            Console.WriteLine(platesneeded);
            Console.WriteLine(timeneeded);


        }
    }
}
