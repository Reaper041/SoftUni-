using System;
using System.Collections.Generic;
using System.Linq;

namespace Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInput = Console.ReadLine().Split("|");
                string carName = carInput[0];
                int mileage = int.Parse(carInput[1]);
                int fuel = int.Parse(carInput[2]);

                Car car = new Car()
                {
                    Mileage = mileage,
                    CarName = carName,
                    Fuel = fuel
                };

                cars.Add(car);
            }

            string[] input = Console.ReadLine().Split(" : ");

            while (input[0] != "Stop")
            {
                string command = input[0];
                string carName = input[1];

                Car car = cars.FirstOrDefault(x => x.CarName == carName);

                if (command == "Drive")
                {
                    int distance = int.Parse(input[2]);
                    int fuel = int.Parse(input[3]);
                    if (car.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        car.Fuel -= fuel;
                        car.Mileage += distance;
                        Console.WriteLine($"{car.CarName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (car.Mileage >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car.CarName}!");
                        cars.Remove(car);
                    }
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(input[2]);
                    int lastFuel = car.Fuel;
                    car.Fuel += fuel;
                    if (car.Fuel > 75)
                    {
                        car.Fuel = 75;

                        Console.WriteLine($"{car.CarName} refueled with {75 - lastFuel} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{car.CarName} refueled with {fuel} liters");
                    }
                }
                else
                {
                    int kilometers = int.Parse(input[2]);
                    car.Mileage -= kilometers; if (car.Mileage < 10000)
                    {
                        car.Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car.CarName} mileage decreased by {kilometers} kilometers");
                    }
                    
                }
                input = Console.ReadLine().Split(" : ");
            }

            foreach (var car in cars.OrderByDescending(x => x.Mileage).ThenBy(x => x.CarName))
            {
                Console.WriteLine(car);
            }
        }
    }

    class Car
    {
        public string CarName { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public override string ToString()
        {
            return $"{CarName} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
}
