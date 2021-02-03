using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> input = Console.ReadLine().Split().ToList();

            Func<List<string>, List<string>> namesCondition =
                names =>
                {
                    List<string> newList = new List<string>();

                    return newList = names.Where(x => x.Length <= n).ToList();
                };

            List<string> namesInRange = namesCondition(input);

            foreach (var name in namesInRange)
            {
                Console.WriteLine(name);
            }
        }
    }
}
