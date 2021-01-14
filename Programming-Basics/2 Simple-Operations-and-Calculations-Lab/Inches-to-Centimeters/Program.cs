using System;

namespace Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inches = ");

            var inch = double.Parse(Console.ReadLine());
            var centimeter = inch * 2.54;

            Console.WriteLine("Centimeter = {0}", centimeter);
        }
    }
}
