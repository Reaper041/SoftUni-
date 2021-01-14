using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("||");

            Dictionary<string, int> townsAndPopulation = new Dictionary<string, int>();
            Dictionary<string, int> townsAndGold = new Dictionary<string, int>();

            while (input[0] != "Sail")
            {
                string town = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);

                if (!townsAndPopulation.ContainsKey(town))
                {
                    townsAndPopulation.Add(town, population);
                    townsAndGold.Add(town, gold);
                }
                else
                {
                    townsAndPopulation[town] += population;
                    townsAndGold[town] += gold;
                }
                
                input = Console.ReadLine().Split("||");
            }

            string[] secInput = Console.ReadLine().Split("=>");

            while (secInput[0] != "End")
            {
                string command = secInput[0];
                string town = secInput[1];

                if (command == "Plunder")
                {
                    int people = int.Parse(secInput[2]);
                    int gold = int.Parse(secInput[3]);

                    townsAndPopulation[town] -= people;
                    townsAndGold[town] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (townsAndPopulation[town] == 0 || townsAndGold[town] == 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        townsAndPopulation.Remove(town);
                        townsAndGold.Remove(town);
                    }
                }
                else
                {
                    int gold = int.Parse(secInput[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        townsAndGold[town] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {townsAndGold[town]} gold.");
                    }
                }
                secInput = Console.ReadLine().Split("=>");
            }

            if (townsAndGold.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townsAndGold.Count} wealthy settlements to go to:");
                foreach (var town in townsAndGold.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{town.Key} -> Population: {townsAndPopulation[town.Key]} citizens, Gold: {town.Value} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
