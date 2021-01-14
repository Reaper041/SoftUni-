using System;

namespace House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double rearWallArea = x * x;
            double frontWallArea = x * x - 1.2 * 2;
            double frontAndRearWallsArea = rearWallArea + frontWallArea;
            double sideWallsArea = (x * y - 1.5 * 1.5) * 2;
            double roofSideSidesArea = x * y * 2;
            double roofFrontAndRearSidesArea = (x * h / 2.0) * 2;

            double greenPaintLiters = (sideWallsArea + frontAndRearWallsArea) / 3.4;
            double redPaintLiters = (roofSideSidesArea + roofFrontAndRearSidesArea) / 4.3;

            Console.WriteLine($"{greenPaintLiters:f2}");
            Console.WriteLine($"{redPaintLiters:f2}");

        }
    }
}