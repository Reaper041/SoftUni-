using System;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();

            Console.WriteLine(VowelsCount(word));
        }

        static int VowelsCount(string word)
        {
            int count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'u' || word[i] == 'o' || word[i] == 'e' || word[i] == 'i' || word[i] == 'y')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
