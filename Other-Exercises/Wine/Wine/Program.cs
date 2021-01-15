using System;

namespace Wine
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardArea = int.Parse(Console.ReadLine());
            double grapePerSquare = double.Parse(Console.ReadLine());
            int neededLiters = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double wineLiters = vineyardArea * 0.4 * grapePerSquare / 2.5;

            if (wineLiters < neededLiters)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededLiters - wineLiters)} liters wine needed.");
            }
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineLiters)} liters.");
                Console.WriteLine($"{Math.Ceiling(wineLiters - neededLiters)} liters left -> {Math.Ceiling((wineLiters - neededLiters) / workers)} liters per person.");
            }
        }
    }
}
