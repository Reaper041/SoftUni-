using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
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

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    numbers.RemoveAll(n => n == int.Parse(command[1]));
                }
                else
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
