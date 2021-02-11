using System;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1Km = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km);

                cars.Add(car);
            }

            string[] commandArr = Console.ReadLine().Split();

            while (commandArr[0] != "End")
            {
                string carModel = commandArr[1];
                double amountOfKm = double.Parse(commandArr[2]);

                Car currCar = cars.First(x => x.Model == carModel);

                bool isDrive = currCar.CanDrive(amountOfKm);

                if (!isDrive)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                commandArr = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}
