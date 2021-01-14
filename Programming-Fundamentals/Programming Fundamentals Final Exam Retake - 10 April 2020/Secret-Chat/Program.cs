using System;
using System.Collections.Generic;
using System.Linq;

namespace Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            string[] input = Console.ReadLine().Split(":|:");

            while (input[0] != "Reveal")
            {
                string command = input[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(input[1]);

                    concealedMessage = concealedMessage.Insert(index, " ");
                    Console.WriteLine(concealedMessage);
                }
                else if (command == "Reverse")
                {
                    string substring = input[1];
                    if (concealedMessage.Contains(substring))
                    {
                        int index = concealedMessage.IndexOf(substring);
                        concealedMessage = concealedMessage.Remove(index, substring.Length);
                        char[] arr = substring.ToCharArray();
                        Array.Reverse(arr);
                        substring = string.Join("", arr);
                        concealedMessage += substring;
                        Console.WriteLine(concealedMessage);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    string substring = input[1];
                    string replacement = input[2];
                    concealedMessage = concealedMessage.Replace(substring, replacement);
                    Console.WriteLine( concealedMessage);
                }
                input = Console.ReadLine().Split(":|:");
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}
