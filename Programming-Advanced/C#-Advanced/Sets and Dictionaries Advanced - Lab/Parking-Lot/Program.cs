using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ");

            while (input[0] != "END")
            {
                string command = input[0];
                string number = input[1];

                if (command == "IN")
                {
                    carNumbers.Add(number);
                }
                else
                {
                    carNumbers.Remove(number);
                }

                input = Console.ReadLine().Split(", ");
            }


            if (carNumbers.Count > 0)
            {
                foreach (var carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
