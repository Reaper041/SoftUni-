using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> collectingItems = Console.ReadLine().Split(", ").ToList();

            string[] input = Console.ReadLine().Split(" - ");

            while (input[0] != "Craft!")
            {
                string command = input[0];
                if (command == "Collect")
                {
                    if (!collectingItems.Contains(input[1]))
                    {
                        collectingItems.Add(input[1]);
                    }
                }
                else if (command == "Drop")
                {
                    if (collectingItems.Contains(input[1]))
                    {
                        collectingItems.Remove(input[1]);
                    }
                }
                else if (command == "Combine Items")
                {
                    string[] items = input[1].Split(':');

                    if (collectingItems.Contains(items[0]))
                    {
                        int index = collectingItems.IndexOf(items[0]);

                        collectingItems.Insert(index + 1, items[1]);
                    }
                }
                else
                {
                    if (collectingItems.Contains(input[1]))
                    {
                        collectingItems.Remove(input[1]);
                        collectingItems.Add(input[1]);
                    }
                }

                input = Console.ReadLine().Split(" - ");
            }

            Console.WriteLine(string.Join(", ", collectingItems));
        }
    }
}
