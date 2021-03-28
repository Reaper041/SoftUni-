using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                string vehicle = input[1];

                if (vehicle == "Car")
                {
                    if (command == "Drive")
                    {
                        car.Drive(double.Parse(input[2]));
                    }
                    else
                    {
                        car.Refuel(double.Parse(input[2]));
                    }
                }
                else
                {
                    if (command == "Drive")
                    {
                        truck.Drive(double.Parse(input[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(input[2]));
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");

        }
    }
}
