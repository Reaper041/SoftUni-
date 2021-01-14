using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Basics
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
            bool flag = false;
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        flag = true;
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(command[1]));
                        flag = true;
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(command[1]));
                        flag = true;
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        flag = true;
                        break;
                    case "Contains":
                        if (numbers.Contains(int.Parse(command[1]))) 
                            Console.WriteLine("Yes");
                        else 
                            Console.WriteLine("No such number");
                        break;
                    case "PrintEven":
                        for (int i = 0; i < numbers.Count; i++)
                            if (numbers[i] % 2 ==0) Console.Write(numbers[i] + " ");
                        Console.WriteLine();
                        break;
                    case "PrintOdd":
                        for (int i = 0; i < numbers.Count; i++)
                            if (numbers[i] % 2 == 1) Console.Write(numbers[i] + " ");
                        Console.WriteLine();
                        break;
                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }

                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (command[1] == "<")
                            {
                                if (int.Parse(command[2]) > numbers[i])
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                            }
                            else if (command[1] == ">")
                            {
                                if (int.Parse(command[2]) < numbers[i])
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                            }
                            else if (command[1] == ">=")
                            {
                                if (int.Parse(command[2]) <= numbers[i])
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                            }
                            else if (command[1] == "<=")
                            {
                                if (int.Parse(command[2]) >= numbers[i])
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                            }

                        }
                        Console.WriteLine();
                        break;

                }
                command = Console.ReadLine().Split();
            }

            if (flag)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}