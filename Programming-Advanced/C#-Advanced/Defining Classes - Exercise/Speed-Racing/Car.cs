using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Racing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TraveledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }

        public bool CanDrive(double amountOfKm)
        {
            double neededFuel = amountOfKm * FuelConsumptionPerKilometer;
            if (FuelAmount < neededFuel)
            {
                return false;
            }

            FuelAmount -= neededFuel;
            TraveledDistance += amountOfKm;
            return true;
        }
    }
}
