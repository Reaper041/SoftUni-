using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var character in input)
            {
                stack.Push(character);
            }

            int count = stack.Count;
            for (int i = 0; i < count; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
