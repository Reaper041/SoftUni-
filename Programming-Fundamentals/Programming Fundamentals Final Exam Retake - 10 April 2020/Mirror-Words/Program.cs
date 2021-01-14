using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"((?:@)|(?:#))([a-zA-z]{3,})\1\1([a-zA-z]{3,})\1";
            string text = Console.ReadLine();

            var matches = Regex.Matches(text, pattern);

            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            foreach (Match match in matches)
            {
                char[] reversedArr = match.Groups[3].Value.Trim().ToCharArray();
                reversedArr = reversedArr.Reverse().ToArray();
                string reversed = string.Join("", reversedArr);

                if (match.Groups[2].Value == reversed)
                {
                    mirrorWords.Add(match.Groups[2].Value, match.Groups[3].Value);
                }
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");

                Console.Write(string.Join(", ", mirrorWords.Select(x => $"{x.Key} <=> {x.Value}")));
            }
        }
    }
}
