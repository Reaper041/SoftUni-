using System;
using System.Collections.Generic;

namespace Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairs = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < pairs; i++)
            {
                string firstWord = Console.ReadLine();
                string secondWord = Console.ReadLine();

                if (synonyms.ContainsKey(firstWord))
                {
                    synonyms[firstWord].Add(secondWord);
                }
                else
                {
                    synonyms.Add(firstWord, new List<string>());
                    synonyms[firstWord].Add(secondWord);
                }
            }

            foreach (var synonym in synonyms)
            {
                Console.WriteLine($"{synonym.Key} - {string.Join(", ", synonym.Value)}");
            }
        }
    }
}
