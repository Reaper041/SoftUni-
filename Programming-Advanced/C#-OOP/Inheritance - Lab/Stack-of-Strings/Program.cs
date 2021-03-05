using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            List<string> list = new List<string>
            {
                "123",
                "234",
                "5643"
            };

            stack.AddRange(list);

            foreach (var el in stack)
            {
                Console.WriteLine(el);
            }
        }
    }
}
