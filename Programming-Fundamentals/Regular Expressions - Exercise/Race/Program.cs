using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternName = @"[\d\W]";
            string patternDigit = @"[\D]";

            string[] names = Console.ReadLine().Split(", ");
            Dictionary<string, int> keyNames = new Dictionary<string, int>();

            foreach (var name in names)
            {
                keyNames.Add(name, 0);
            }

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                var matchName = Regex.Replace(input, patternName, "");
                var matchDigit = Regex.Replace(input, patternDigit, "");
                int sum = 0;

                foreach (var digit in matchDigit)
                {
                    sum += int.Parse(digit.ToString());
                }

                if (keyNames.ContainsKey(matchName))
                {
                    keyNames[matchName] += sum;
                }
                input = Console.ReadLine();
            }

            int count = 1;
            foreach (var keyName in keyNames.OrderByDescending(x => x.Value))
            {
                string sufix = count == 1 ? "st" : count == 2 ? "nd" : "rd";
                Console.WriteLine($"{count}{sufix} place: {keyName.Key}");
                count++;

                if (count > 3)
                {
                    break;
                }
            }
        }
    }
}
