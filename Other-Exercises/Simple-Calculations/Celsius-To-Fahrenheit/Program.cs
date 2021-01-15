using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsius_To_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Celsius = ");

            var celsius = double.Parse(Console.ReadLine());

            Console.WriteLine("Fahrenheit = " + (celsius * 1.8 + 32));
        }
    }
}
