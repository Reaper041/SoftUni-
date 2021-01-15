using System;

namespace Vine_Field
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardArea = int.Parse(Console.ReadLine());
            double grapeperSquare = double.Parse(Console.ReadLine());
            double neededLiters = double.Parse(Console.ReadLine());
            double workers = double.Parse(Console.ReadLine());

            double grapeforVine = 0.4 * (vineyardArea * grapeperSquare);
            double litersWine = grapeforVine / 2.5;

            if (litersWine < neededLiters)
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", 
                    Math.Floor(neededLiters - litersWine));
            }
            else
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.", 
                    Math.Floor(litersWine));
                Console.WriteLine("{0} liters left -> {1} liters per person.", 
                    Math.Ceiling(litersWine - neededLiters), 
                    Math.Ceiling((litersWine - neededLiters) / workers));
            }
        }
    }
}
