using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            Stack<int> copy = new Stack<int>(numbers);

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = input[0];

                if (command == 1)
                {
                    int num = input[1];

                    numbers.Push(num);
                }
                else if (command == 2)
                {
                    numbers.Pop();
                }
                else if (command == 3)
                {
                    int maxNum = int.MinValue;
                    copy = new Stack<int>(numbers);

                    if (copy.Any())
                    {
                        while (copy.Any())
                        {
                            if (copy.Peek() > maxNum)
                            {
                                maxNum = copy.Pop();
                            }
                            else
                            {
                                copy.Pop();
                            }
                        }

                        Console.WriteLine(maxNum);
                    }
                }
                else if (command == 4)
                {
                    int minNum = int.MaxValue;
                    copy = new Stack<int>(numbers);

                    if (copy.Any())
                    {
                        while (copy.Any())
                        {
                            if (copy.Peek() < minNum)
                            {
                                minNum = copy.Pop();
                            }
                            else
                            {
                                copy.Pop();
                            }
                        }

                        Console.WriteLine(minNum);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
