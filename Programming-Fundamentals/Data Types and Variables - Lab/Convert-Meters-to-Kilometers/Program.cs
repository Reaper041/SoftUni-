using System;

namespace Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meter = int.Parse(Console.ReadLine());
            decimal kilometers = meter * 1.0m / 1000m;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
