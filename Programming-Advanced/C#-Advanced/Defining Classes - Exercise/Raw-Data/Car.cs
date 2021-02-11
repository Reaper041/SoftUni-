using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, 
            int cargoWeight, string cargoType, double tire1Pressure, 
            int tire1Age, double tire2Pressure, int tire2Age, 
            double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine();
            Engine.EngineSpeed = engineSpeed;
            Engine.EnginePower = enginePower;
            Cargo = new Cargo();
            Cargo.CargoWeight = cargoWeight;
            Cargo.CargoType = cargoType;
            Tires = new List<Tire>();
            Tires.Add(new Tire());
            Tires[0].TirePressure = tire1Pressure;
            Tires[0].TireAge = tire1Age;
            Tires.Add(new Tire());
            Tires[1].TirePressure = tire2Pressure;
            Tires[1].TireAge = tire2Age;
            Tires.Add(new Tire());
            Tires[2].TirePressure = tire3Pressure;
            Tires[2].TireAge = tire3Age;
            Tires.Add(new Tire());
            Tires[3].TirePressure = tire4Pressure;
            Tires[3].TireAge = tire4Age;
        }


        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tires { get; set; }


    }
}
