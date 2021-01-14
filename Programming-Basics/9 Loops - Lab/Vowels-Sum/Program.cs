using System;

namespace Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a')
                {
                    sum++;
                }
                if (word[i] == 'e')
                {
                    sum += 2;
                }
                if (word[i] == 'i')
                {
                    sum += 3;
                }
                if (word[i] == 'o')
                {
                    sum += 4;
                }
                if (word[i] == 'u')
                {
                    sum += 5;
                }

            }
            Console.WriteLine(sum);
        }
    }
}
