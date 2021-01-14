using System;
using System.Collections.Generic;
using System.Linq;

namespace Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine().Split("<->");
                string plantName = plantInfo[0];
                double rarity = double.Parse(plantInfo[1]);

                var plant = new Plant()
                {
                    PlantName = plantName,
                    Rarity = rarity,
                    Rating = new List<double>()
                };

                if (plants.Contains(plant))
                {
                    plant.Rarity = rarity;
                }
                else
                {
                    plants.Add(plant);
                }
            }

            string[] input = Console.ReadLine().Split(": ");

            while (input[0] != "Exhibition")
            {
                string[] parameters = input[1].Split(" - ");
                string command = input[0];
                string plantName = parameters[0];

                var plant = plants.FirstOrDefault(x => x.PlantName == plantName);
                
                if (command == "Rate")
                {
                    double rating = double.Parse(parameters[1]);

                    plant.Rating.Add(rating);
                }
                else if (command == "Update")
                {
                    double rarity = double.Parse(parameters[1]);

                    plant.Rarity = rarity;
                }
                else
                {
                    plant.Rating.RemoveRange(1, plant.Rating.Count - 1);
                    plant.Rating[0] = 0;
                }

                input = Console.ReadLine().Split(": ");
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants.OrderByDescending(x => x.Rarity)
                .ThenByDescending( x => x.Rating.Average(x => x)))
            {
                Console.WriteLine($"- {plant.PlantName}; Rarity: {plant.Rarity}; Rating: {plant.Rating.Average(x => x):f2}");
            }
        }
    }

    class Plant
    {
        public string PlantName { get; set; }
        public double Rarity { get; set; }
        public List<double> Rating { get; set; }
    }
}
