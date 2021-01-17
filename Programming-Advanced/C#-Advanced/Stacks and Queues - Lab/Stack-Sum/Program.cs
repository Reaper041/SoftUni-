using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfNumbers = new Stack<int>(numbers);

            string[] input = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();

            while (input[0] != "end")
            {
                string command = input[0];
                if (command == "add")
                {
                    int firstNum = int.Parse(input[1]);
                    int secondNum = int.Parse(input[2]);

                    stackOfNumbers.Push(firstNum);
                    stackOfNumbers.Push(secondNum);
                }
                else
                {
                    int count = int.Parse(input[1]);
                    if (count <= stackOfNumbers.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stackOfNumbers.Pop();
                        }
                    }
                }
                input = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();
            }

            Console.WriteLine($"Sum: {stackOfNumbers.Sum()}");
        }
    }
}
