using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>, List<int>> customComparator =
                numbers =>
                {
                    List<int> evenList = new List<int>();
                    List<int> oddList = new List<int>();

                    foreach (var number in numbers)
                    {
                        if (number % 2 == 0) 
                        {
                            evenList.Add(number);
                        }
                        else
                        {
                            oddList.Add(number);
                        }
                    }

                    numbers.Clear();

                    numbers = numbers.Concat(evenList.OrderBy(n => n)).ToList();
                    numbers = numbers.Concat(oddList.OrderBy(n => n)).ToList();


                    return numbers;
                };

            nums = customComparator(nums);


            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
