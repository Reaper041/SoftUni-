using System;
using System.Collections.Generic;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> letters = new Dictionary<char, int>();

            foreach (var letter in text)
            {
                if (letters.ContainsKey(letter) && letter != ' ')
                {
                    letters[letter]++;
                }
                else if (!letters.ContainsKey(letter) && letter != ' ')
                {
                    letters.Add(letter, 1);
                }
            }

            foreach (var letter in letters)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
