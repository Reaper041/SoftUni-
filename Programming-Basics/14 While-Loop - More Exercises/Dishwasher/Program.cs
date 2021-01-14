using System;

namespace Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());
            int detergent = bottles * 750;
            int count = 0;
            int countDishes = 0;
            int countPots = 0;

            while (detergent >= 0)
            {
                string dishes = Console.ReadLine();
                count++;

                if (dishes == "End")
                {
                    break;
                }

                if (count % 3 == 0)
                {
                    detergent -= 15 * int.Parse(dishes);
                    countPots += int.Parse(dishes);
                }
                else
                {
                    detergent -= 5 * int.Parse(dishes);
                    countDishes += int.Parse(dishes);
                }
            }

            if (detergent >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{countDishes} dishes and {countPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergent} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(detergent)} ml. more necessary!");
            }
        }
    }
}
