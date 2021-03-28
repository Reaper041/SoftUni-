using System;

namespace Vehicles
{
    public class Car : IVehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + 0.9;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity < FuelConsumption * distance)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine($"Car travelled {distance} km");
            }
        }

        public void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}