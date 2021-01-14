using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('/');

            Catalog catalog = new Catalog();
            while (input[0] != "end")
            {
                string type = input[0];
                if (type == "Car")
                {
                    string brand = input[1];
                    string model = input[2];
                    int horsePower = int.Parse(input[3]);

                    Car car = new Car();

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;

                    catalog.Cars.Add(car);
                }
                else
                {
                    string brand = input[1];
                    string model = input[2];
                    int weight = int.Parse(input[3]);

                    Truck truck = new Truck();

                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;

                    catalog.Trucks.Add(truck);
                }

                input = Console.ReadLine().Split('/');
            }

            catalog.Cars = catalog.Cars.OrderBy(x => x.Brand).ToList();
            catalog.Trucks = catalog.Trucks.OrderBy(x => x.Brand).ToList();

            Console.WriteLine("Cars:");
            foreach (Car car in catalog.Cars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
            Console.WriteLine("Trucks:");
            foreach (Truck truck in catalog.Trucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }

    class Catalog
    {
        public List<Car> Cars;
        public List<Truck> Trucks;

        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }

    }
}
