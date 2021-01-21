using System;
using System.Collections.Generic;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;
            Queue<string> historyStr = new Queue<string>();
            historyStr.Enqueue(text);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                if (command == "1")
                {
                    string substr = input[1];
                    text += substr;
                    historyStr.Enqueue(text);
                }
                else if (command == "2")
                {
                    int count = int.Parse(input[1]);

                    for (int j = 0; j < count; j++)
                    {
                        text = text.Remove(text.Length - 1);
                    }
                    historyStr.Enqueue(text);
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(historyStr.Peek()[index - 1]);
                }
                else
                {
                    historyStr.Dequeue();
                }
            }
        }
    }
}
