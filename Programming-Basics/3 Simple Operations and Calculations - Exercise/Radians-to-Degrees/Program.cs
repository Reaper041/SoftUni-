using System;

namespace Radians_to_Degrees
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
