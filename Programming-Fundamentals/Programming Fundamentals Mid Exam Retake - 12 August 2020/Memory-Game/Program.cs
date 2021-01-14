using System;
using System.Collections.Generic;
using System.Linq;

namespace Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int moves = 0;

            while (input[0] != "end")
            {
                int[] indexes = input.Select(int.Parse).ToArray();
                int firstIndex = indexes[0];
                int secondIndex = indexes[1];
                bool isInBounds = firstIndex < 0 ||
                                  firstIndex >= elements.Count ||
                                  secondIndex < 0 ||
                                  secondIndex >= elements.Count ||
                                  firstIndex == secondIndex;

                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }

                moves++;

                if (isInBounds)
                {
                    elements.Insert(elements.Count / 2, $"-{moves}a");
                    elements.Insert(elements.Count / 2 + 1, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (elements[firstIndex] == elements[secondIndex])
                {
                    string match = elements[firstIndex];
                    elements.RemoveAll(x => x == match);
                    Console.WriteLine($"Congrats! You have found matching elements - {match}!");
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            if (elements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(' ', elements));
            }
        }
    }
}
