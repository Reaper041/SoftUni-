using System;

namespace Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintCharactersBetween(firstChar, secondChar);

            
        }

        static void PrintCharactersBetween(char firstChar, char secondChar)
        {
            if (firstChar < secondChar)
            {
                for (char i = (char)(firstChar + 1); i < secondChar; i++)
                {
                    Console.Write(i + " ");
                }
            }
            else
            {
                for (char i = (char)(secondChar + 1); i < firstChar; i++)
                {
                    Console.Write(i + " ");
                }
            }
            
        }
    }
}
