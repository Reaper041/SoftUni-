using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                if (command[0] == "Insert")
                {
                    if (int.Parse(command[2]) < 0 || int.Parse(command[2]) > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    }
                }
                else if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    if (int.Parse(command[1]) < 0 || int.Parse(command[1]) > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(command[1]));
                    }
                }
                else if (command[0] == "Shift" && command[1] == "left")
                {
                    for (int i = 1; i <= int.Parse(command[2]); i++)
                    {
                        numbers.Add(numbers[0]);
                        numbers.Remove(numbers[0]);
                    }
                }
                else
                {
                    for (int i = 1; i <= int.Parse(command[2]); i++)
                    {
                        numbers.Insert(0, numbers[numbers.Count - 1]);
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
