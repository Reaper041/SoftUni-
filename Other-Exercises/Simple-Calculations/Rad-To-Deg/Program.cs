using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad_To_Deg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Radians = ");

            var rad = double.Parse(Console.ReadLine());
            double deg = rad * 180 / Math.PI;
            

            Console.WriteLine("Degrees = " + Math.Round(deg, 2));

            
        }
    }
}
