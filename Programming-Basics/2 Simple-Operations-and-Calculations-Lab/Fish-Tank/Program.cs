using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double occupiedPartPercent = double.Parse(Console.ReadLine());

            double volumeCentimeters = length * width * height;
            double volumeDecimeters = volumeCentimeters / 1000.0;
            double occupiedPartLiter = volumeDecimeters * occupiedPartPercent / 100.0;
            double waterNeeded = volumeDecimeters - occupiedPartLiter;

            Console.WriteLine("{0:f3}", waterNeeded);
        }
    }
}
