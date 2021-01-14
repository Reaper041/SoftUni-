using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "Finish")
            {
                string command = input[0];

                if (command == "Replace")
                {
                    string currentChar = input[1];
                    string newChar = input[2];

                    text = text.Replace(currentChar, newChar);
                    Console.WriteLine(text);
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    int count = endIndex - startIndex + 1;
                    if (startIndex >= 0 && endIndex < text.Length)
                    {
                        text = text.Remove(startIndex, count);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                else if (command == "Make")
                {
                    string subcmnd = input[1];
                    if (subcmnd == "Upper")
                    {
                        text = text.ToUpper();
                    }
                    else
                    {
                        text = text.ToLower();
                    }

                    Console.WriteLine(text);
                }
                else if (command == "Check")
                {
                    string substring = input[1];

                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }
                }
                else
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    int count = endIndex - startIndex + 1;

                    if (startIndex >= 0 && endIndex < text.Length)
                    {
                        string substring = text.Substring(startIndex, count);
                        int sum = 0;
                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += substring[i];
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                input = Console.ReadLine().Split();
            }
        }
    }
}
