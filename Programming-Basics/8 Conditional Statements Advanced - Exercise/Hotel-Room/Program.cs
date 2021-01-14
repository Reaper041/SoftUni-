using System;
using System.Security.Cryptography;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double totalStudio = 0;
            double totalApartment = 0;

            if (month == "May" || month == "October")
            {
                totalApartment = 65 * nights;
                totalStudio = 50 * nights;

                if (nights > 14) totalStudio -= totalStudio * 0.3;
                else if (nights > 7) totalStudio -= totalStudio * 0.05;

            }
            else if (month == "June" || month == "September")
            {
                totalApartment = 68.70 * nights;
                totalStudio = 75.20 * nights;

                if (nights > 14) totalStudio -= totalStudio * 0.2;
            }
            else
            {
                totalApartment = 77 * nights;
                totalStudio = 76 * nights;

            }

            if (nights > 14) totalApartment -= totalApartment * 0.1;

            Console.WriteLine($"Apartment: {totalApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalStudio:f2} lv.");
        }
    }
}
