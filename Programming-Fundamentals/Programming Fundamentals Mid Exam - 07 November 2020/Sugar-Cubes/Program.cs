using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Sugar_Cubes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cubes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "Mort")
            {
                string command = input[0];
                int value = int.Parse(input[1]);
                if (command == "Add")
                {
                    cubes.Add(value);
                }
                else if (command == "Remove")
                {
                    for (int i = 0; i < cubes.Count; i++)
                    {
                        if (value == cubes[i])
                        {
                            cubes.RemoveAt(i);
                            break;
                        }
                    }
                }
                else if (command == "Replace")
                {
                    for (int i = 0; i < cubes.Count; i++)
                    {
                        if (value == cubes[i])
                        {
                            cubes[i] = int.Parse(input[2]);
                            break;
                        }
                    }
                }
                else if (command == "Collapse")
                {
                    cubes.RemoveAll(x => x < value);
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', cubes));
        }
    }
}
