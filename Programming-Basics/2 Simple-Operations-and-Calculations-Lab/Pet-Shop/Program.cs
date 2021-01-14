using System;

namespace Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());

            double totalPriceForDogs = dogs * 2.5;
            double totalPriceForOtherAnimals = otherAnimals * 4.0;
            double total = totalPriceForDogs + totalPriceForOtherAnimals;


            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
