using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            Action<List<string>> nameOnNewLine = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            nameOnNewLine(names);

        }
    }
}
