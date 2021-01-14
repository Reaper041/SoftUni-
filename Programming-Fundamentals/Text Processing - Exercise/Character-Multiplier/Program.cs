using System;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            int sum = 0;

            for (int i = 0; i < Math.Min(words[0].Length, words[1].Length); i++)
            {
                int multiplied = words[0][i] * words[1][i];

                sum += multiplied;
            }

            if (words[0].Length > words[1].Length)
            {
                for (int i = words[1].Length; i < words[0].Length; i++)
                {
                    sum += words[0][i];
                }
            }
            else if(words[0].Length < words[1].Length)
            {
                for (int i = words[0].Length; i < words[1].Length; i++)
                {
                    sum += words[1][i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
