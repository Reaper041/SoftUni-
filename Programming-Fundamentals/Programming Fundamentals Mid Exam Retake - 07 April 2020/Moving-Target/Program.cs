using System;
using System.Collections.Generic;
using System.Linq;

namespace Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                string command = input[0];
                int index = int.Parse(input[1]);
                int value = int.Parse(input[2]);
                bool isIndexValid = index >= 0 && index < targets.Count;
                if (command == "Shoot" && isIndexValid)
                {
                    targets[index] -= value;
                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                else if (command == "Add")
                {
                    if (isIndexValid)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (command == "Strike")
                {
                    if (index + value <= targets.Count - 1 && index - value >= 0)
                    {
                        targets.RemoveRange(index - value, value * 2 + 1);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}
