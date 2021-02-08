using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Tire[]> tires = new List<Tire[]>();

            while (input != "No more tires")
            {
                int[] yearInfo = input.Split().Where((string a, int index)
                    => index % 2 == 0).Select(int.Parse).ToArray();

                double[] pressureInfo = input.Split().Where((string a, int index)
                    => index % 2 != 0).Select(double.Parse).ToArray();

                Tire[] setOfTires = new Tire[yearInfo.Length];
                for (int i = 0; i < yearInfo.Length; i++)
                {
                    Tire tire = new Tire(yearInfo[i], pressureInfo[i]);
                    setOfTires[i] = tire;
                }
                tires.Add(setOfTires);

                input = Console.ReadLine();
            }

            string inputEngine = string.Empty;

            List<Engine> engines = new List<Engine>();

            while ((inputEngine = Console.ReadLine()) != "Engines done")
            {
                string[] inputEngineArr = inputEngine.Split();

                int horsePower = int.Parse(inputEngineArr[0]);
                double cubicCapacity = double.Parse(inputEngineArr[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);
            }

            string carInput = string.Empty;

            List<Car> cars = new List<Car>();

            while ((carInput = Console.ReadLine()) != "Show special")
            {
                string[] carInpArr = carInput.Split();

                string make = carInpArr[0];
                string model = carInpArr[1];
                int year = int.Parse(carInpArr[2]);
                double fuelQuantity = double.Parse(carInpArr[3]);
                double fuelConsumption = double.Parse(carInpArr[4]);
                int engineIndex = int.Parse(carInpArr[5]);
                int tiresIndex = int.Parse(carInpArr[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, 
                    engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                double sumOfTirePressure = 0;
                foreach (Tire tire in car.Tires)
                {
                    sumOfTirePressure += tire.Pressure;
                }
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && sumOfTirePressure >= 9 && sumOfTirePressure <= 10)
                {
                    car.Drive(20.0);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
