using System;

namespace Vehicles
{
    public class Truck : IVehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + 1.6;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity < FuelConsumption * distance)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine($"Truck travelled {distance} km");
            }
        }

        public void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
}