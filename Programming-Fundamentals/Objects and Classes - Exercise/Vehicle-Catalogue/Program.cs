using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Vehicle> vehicles = new List<Vehicle>();

            while (input[0] != "End")
            {
                string type = input[0].ToLower();
                string model = input[1];
                string color = input[2];
                int horsepower = int.Parse(input[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsepower);

                vehicles.Add(vehicle);

                input = Console.ReadLine().Split();
            }

            string modelInput = Console.ReadLine();


            List<Vehicle> onlyCars = vehicles.Where(x => x.Type == "car").ToList();
            List<Vehicle> onlyTrucks = vehicles.Where(x => x.Type == "truck").ToList();

            int carsCount = onlyCars.Count;
            int trucksCount = onlyTrucks.Count;
            double carsHpSum = onlyCars.Sum(x => x.Horsepower);
            double trucksHpSum = onlyTrucks.Sum(x => x.Horsepower);

            while (modelInput != "Close the Catalogue")
            {
                Vehicle specialVehicle = vehicles.First(x => x.Model == modelInput);

                StringBuilder sb = new StringBuilder();

                if (specialVehicle.Type == "car")
                {
                    sb.AppendLine($"Type: Car");
                }
                else
                {
                    sb.AppendLine($"Type: Truck");
                }
                sb.AppendLine($"Model: {specialVehicle.Model}");
                sb.AppendLine($"Color: {specialVehicle.Color}");
                sb.AppendLine($"Horsepower: {specialVehicle.Horsepower}");

                Console.WriteLine(sb.ToString().TrimEnd());


                modelInput = Console.ReadLine();
            }

            double avgCarsHp = 0;
            double avgTrucksHp = 0;

            if (carsCount > 0)
            {
                avgCarsHp = carsHpSum / carsCount;
            }

            if (trucksCount > 0)
            {
                avgTrucksHp = trucksHpSum / trucksCount;
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarsHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTrucksHp:f2}.");

        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }
    }
}
