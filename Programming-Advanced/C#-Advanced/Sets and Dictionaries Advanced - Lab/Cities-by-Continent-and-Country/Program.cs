using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            Dictionary<string, Dictionary<string, List<string>>> continents =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string county = input[1];
                string city = input[2];

                if (continents.ContainsKey(continent))
                {
                    if (continents[continent].ContainsKey(county))
                    {
                        continents[continent][county].Add(city);
                    }
                    else
                    {
                        continents[continent].Add(county, new List<string>());
                        continents[continent][county].Add(city);
                    }
                }
                else
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                    continents[continent].Add(county, new List<string>());
                    continents[continent][county].Add(city);
                }
            }


            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($"{country.Key} -> ");
                    Console.WriteLine(string.Join(", ", country.Value));
                }
            }
        }
    }
}
