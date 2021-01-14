using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            Random rnd = new Random();
            int randomNum = 0;
            string last = String.Empty;
            for (int i = 0; i < words.Count; i++)
            {
                randomNum = rnd.Next(0, words.Count);
                last = words[i];
                words[i] = words[randomNum];
                words[randomNum] = last;
            }

            foreach (var VARIABLE in words)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
