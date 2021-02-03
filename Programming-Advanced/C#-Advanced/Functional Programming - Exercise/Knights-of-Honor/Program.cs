using System;
using System.Collections.Generic;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().Select(n => $"Sir {n}").ToList();

            Action<List<string>> appendSir = n =>
                Console.WriteLine(string.Join(Environment.NewLine, n));

            appendSir(input);
        }
    }
}
