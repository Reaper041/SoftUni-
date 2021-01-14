using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";

            string input = Console.ReadLine();
            int travelPoints = 0;
            List<string> destinations = new List<string>();
            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string destination = match.Groups[2].Value.Trim();
                destinations.Add(destination);
                travelPoints += destination.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
