using System;

namespace Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForTrip = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double savedMoney = 0;

            for (int i = 1; i <= months; i++)
            {
                if (i % 4 == 0)
                {
                    savedMoney += savedMoney * 0.25;
                }

                if (i != 1 && i % 2 == 1)
                {
                    savedMoney -= 0.16 * savedMoney;
                }

                savedMoney += priceForTrip * 0.25;
            }

            if (savedMoney >= priceForTrip)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {savedMoney - priceForTrip:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {priceForTrip - savedMoney:f2}lv. more.");
            }
        }
    }
}
