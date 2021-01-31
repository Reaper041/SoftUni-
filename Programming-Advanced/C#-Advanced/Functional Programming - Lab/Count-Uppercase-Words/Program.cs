using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperCaseCondition = word => char.IsUpper(word[0]);

            string[] upperCase = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(upperCaseCondition)
                .ToArray();

            foreach (var word in upperCase)
            {
                Console.WriteLine(word);
            }
        }
    }
}
