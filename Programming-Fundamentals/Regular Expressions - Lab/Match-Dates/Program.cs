using System;
using System.Text.RegularExpressions;

namespace Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?<day>(?:[0-2][0-9])|(?:[3][0-1]))([.\-\/])(?<month>[A-Z]{1}[a-z]{2})\1(?<year>[0-9]{4})\b";
            string input = Console.ReadLine();

            var matches = Regex.Matches(input, regex);

            foreach (Match match in matches)
            {
                var day = match.Groups["day"].Value;
                var year = match.Groups["year"].Value;
                var month = match.Groups["month"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
