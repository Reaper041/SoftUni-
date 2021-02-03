using System;
using System.Xml.Schema;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCargoes = int.Parse(Console.ReadLine());


            double tonesBus = 0;
            double tonesTruck = 0;
            double tonesTrain = 0;
            int totalTones = 0;
            int totalPrice = 0;

            for (int cargo = 1; cargo <= numberOfCargoes; cargo++)
            {
                int tones = int.Parse(Console.ReadLine());

                totalTones += tones;

                if (tones <= 3)
                {
                    totalPrice += tones * 200;
                    tonesBus += tones;
                }
                else if (tones > 3 && tones <= 11)
                {
                    totalPrice += tones * 175;
                    tonesTruck += tones;
                }
                else
                {
                    totalPrice += tones * 120;
                    tonesTrain += tones;
                }
            }

            Console.WriteLine($"{totalPrice * 1.0 / totalTones:f2}");
            Console.WriteLine($"{tonesBus * 1.0 /  totalTones * 100:f2}%");
            Console.WriteLine($"{tonesTruck * 1.0 / totalTones * 100:f2}%");
            Console.WriteLine($"{tonesTrain * 1.0 / totalTones * 100:f2}%");

        }
    }
}
