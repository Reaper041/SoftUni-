using System;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerKind = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double total = 0;

            if (flowerKind == "Roses")
            {
                total = numberOfFlowers * 5;
                if (numberOfFlowers > 80) total -= 0.1 * total;
            }
            else if (flowerKind == "Dahlias")
            {
                total = numberOfFlowers * 3.80;
                if (numberOfFlowers > 90) total -= 0.15 * total;
            }
            else if (flowerKind == "Tulips")
            {
                total = numberOfFlowers * 2.80;
                if (numberOfFlowers > 80) total -= 0.15 * total;
            }
            else if (flowerKind == "Narcissus")
            {
                total = numberOfFlowers * 3;
                if (numberOfFlowers < 120) total += 0.15 * total;
            }
            else if (flowerKind == "Gladiolus")
            {
                total = numberOfFlowers * 2.50;
                if (numberOfFlowers < 80) total += 0.2 * total;
            }

            double diff = budget - total;

            if (diff >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {flowerKind} and {diff:f2} leva left.");
            }
            else Console.WriteLine($"Not enough money, you need {Math.Abs(diff):f2} leva more.");
        }
    }
}
