using System;
using System.Collections.Generic;

namespace Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<char> reducedText = new List<char>();
            char[] chars = text.ToCharArray();
            char lastLetter = ' ';

            foreach (var character in chars)
            {
                if (character == lastLetter)
                {
                    
                }
                else
                {
                    reducedText.Add(character);
                }
                lastLetter = character;
            }

            string newText = new string(reducedText.ToArray());

            Console.WriteLine(newText);
        }
    }
}
