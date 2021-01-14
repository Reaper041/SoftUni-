using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternEmoji = @"(:{2}|\*{2})([A-Z]{1}[a-z]{2,})\1";
            string patternDigit = @"\d";

            string input = Console.ReadLine();

            var matchDigits = Regex.Matches(input, patternDigit);
            var matchEmojis = Regex.Matches(input, patternEmoji);

            long coolThreshold = 1;
            Dictionary<string, long> emojiCoolness = new Dictionary<string, long>();

            foreach (var digit in matchDigits)
            {
                coolThreshold *= int.Parse(digit.ToString());
            }

            foreach (Match matchEmoji in matchEmojis)
            {
                if (!emojiCoolness.ContainsKey(matchEmoji.Value))
                {
                    emojiCoolness.Add(matchEmoji.Value, 0);

                    for (int i = 0; i < matchEmoji.Groups[2].Value.Length; i++)
                    {
                        emojiCoolness[matchEmoji.Value] += matchEmoji.Groups[2].Value[i];
                    }
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiCoolness.Count} emojis found in the text. The cool ones are:");

            foreach (var emoji in emojiCoolness)
            {
                if (emoji.Value >= coolThreshold)
                {
                    Console.WriteLine($"{emoji.Key}");
                }
            }
        }
    }
}
