using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string midChars = MiddleChars(input);
            Console.WriteLine(midChars);
        }

        static string MiddleChars(string input)
        {
            string midChars = string.Empty;
            if (input.Length % 2 == 0)
            {
                midChars = ($"{input[input.Length / 2 - 1]}{input[input.Length / 2]}");
            }
            else
            {
                midChars = $"{input[input.Length / 2]}";
            }

            return midChars;
        }
    }
}
