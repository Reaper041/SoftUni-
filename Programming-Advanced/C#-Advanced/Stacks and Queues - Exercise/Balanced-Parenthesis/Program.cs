using System;
using System.Collections.Generic;

namespace Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parenthesesStack = new Stack<char>(input);
            Queue<char> parenthesesQueue = new Queue<char>(input);

            bool valid = true;


            for (int i = 0; i < parenthesesStack.Count / 2; i++)
            {
                char leftParenthes = parenthesesQueue.Dequeue();
                char rightParenthes = parenthesesStack.Pop();

                if (!(leftParenthes == '{' && rightParenthes == '}' || 
                    leftParenthes == '[' && rightParenthes == ']' || 
                    leftParenthes == '(' && rightParenthes == ')' ||
                    leftParenthes == ' ' && rightParenthes == ' '))
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
