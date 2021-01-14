using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int capacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + int.Parse(command[0]) <= capacity)
                        {
                            wagons[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
