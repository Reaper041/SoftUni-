using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    int firstIndex = indexes.Pop();

                    Console.WriteLine(input.Substring(firstIndex, i - firstIndex + 1));
                }
            }
        }
    }
}
