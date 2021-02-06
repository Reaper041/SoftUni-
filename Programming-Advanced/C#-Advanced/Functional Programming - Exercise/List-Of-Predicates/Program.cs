using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbers = Enumerable.Range(1, n).ToList();

            Func<int, bool> isSpecial =
                number =>
                {
                    for (int i = 0; i < dividers.Count; i++)
                    {
                        if (number % dividers[i] != 0)
                        {
                            return false;
                        }
                    }
                    
                    return true;
                };

            List<int> special = numbers.Where(isSpecial).ToList();


            Console.WriteLine(string.Join(' ', special));
        }
    }
}
