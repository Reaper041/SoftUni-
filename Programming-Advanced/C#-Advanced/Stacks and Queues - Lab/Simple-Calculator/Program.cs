using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] chars = Console.ReadLine().Split();

            chars = chars.Reverse().ToArray();

            Stack<string> elements = new Stack<string>(chars);
            int firstNum = 0;
            int secondNum = 0;

            while (elements.Count > 1)
            {
                string element = elements.Pop();

                if (element != "+" && element != "-")
                {
                    firstNum = int.Parse(element);
                }
                else
                {
                    secondNum = int.Parse(elements.Pop());

                    if (element == "+")
                    {
                        string result = (firstNum + secondNum).ToString();
                        elements.Push(result);
                    }
                    else
                    {
                        string result = (firstNum - secondNum).ToString();
                        elements.Push(result);
                    }
                }
            }

            Console.WriteLine(elements.Pop());
        }
    }
}
