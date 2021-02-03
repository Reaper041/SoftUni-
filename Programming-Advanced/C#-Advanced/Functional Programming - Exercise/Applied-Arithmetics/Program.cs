using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    nums = nums.Select(n => n + 1).ToList();
                }
                else if (command == "multiply")
                {
                    nums = nums.Select(n => n * 2).ToList();
                }
                else if (command == "subtract")
                {
                    nums = nums.Select(n => n - 1).ToList();
                }
                else
                {
                    Console.WriteLine(string.Join(' ', nums));
                }
                command = Console.ReadLine();
            }
        }
    }
}
