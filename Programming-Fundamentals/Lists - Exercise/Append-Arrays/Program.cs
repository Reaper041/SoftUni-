using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            list.Reverse();

            string toSplit = string.Empty;
            toSplit = String.Join(' ', list);
            list = toSplit.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();


            Console.WriteLine(string.Join(' ', list));
        }
    }
}
