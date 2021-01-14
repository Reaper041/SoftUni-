using System;

namespace Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationString = Console.ReadLine();
            string[] input = Console.ReadLine().Split(">>>");

            while (input[0] != "Generate")
            {
                string command = input[0];
                if (command == "Contains")
                {
                    string substring = input[1];
                    if (activationString.Contains(substring))
                    {
                        Console.WriteLine($"{activationString} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string cmd = input[1];
                    int startIndex = int.Parse(input[2]);
                    int endIndex = int.Parse(input[3]);
                    string sub = activationString.Substring(startIndex, endIndex - startIndex);
                    string subToReplace = activationString.Substring(startIndex, endIndex - startIndex);
                    if (cmd == "Upper")
                    {
                        sub = sub.ToUpper();
                        activationString = activationString.Replace(subToReplace, sub);
                    }
                    else
                    {
                        sub = sub.ToLower();
                        activationString = activationString.Replace(subToReplace, sub);
                    }

                    Console.WriteLine(activationString);
                }
                else
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    int count = endIndex - startIndex;
                    activationString = activationString.Remove(startIndex, count);

                    Console.WriteLine(activationString);
                }
                input = Console.ReadLine().Split(">>>");
            }

            Console.WriteLine($"Your activation key is: {activationString}");
        }
    }
}
