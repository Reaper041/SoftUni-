using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Select(n => n.ToLower()).ToArray();

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var element in input)
            {
                if (words.ContainsKey(element))
                {
                    words[element]++;
                }
                else
                {
                    words.Add(element, 1);
                }
            }

            foreach (var word in words)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write(word.Key.ToLower() + ' ');
                }
            }
        }
    }
}
