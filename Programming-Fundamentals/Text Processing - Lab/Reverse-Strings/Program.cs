using System;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word != "end")
            {
                char[] reversed = word.Reverse().ToArray();

                Console.WriteLine($"{word} = {string.Join("", reversed)}");

                word = Console.ReadLine();
            }
        }
    }
}
