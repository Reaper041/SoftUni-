using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int average = numbers.Sum() / numbers.Count;

            List<int> specialNums = numbers.OrderByDescending(x => x).Where(x => x > average).ToList();


            if (specialNums.Count <= 0)
            {
                Console.WriteLine("No"); 
            }
            else if (specialNums.Count > 5)
            {
                List<int> topFive = new List<int>(5);
                for (int i = 0; i < 5; i++)
                {
                    topFive.Add(specialNums[i]);
                }

                Console.WriteLine(string.Join(' ', topFive));
            }
            else
            {
                Console.WriteLine(string.Join(' ', specialNums));
            }
        }
    }
}
