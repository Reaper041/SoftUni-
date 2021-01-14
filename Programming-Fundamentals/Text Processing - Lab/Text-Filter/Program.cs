using System;

namespace Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            for (int i = 0; i < banList.Length; i++)
            {
                char replace = '*';
                string banWord = banList[i];

                text = text.Replace(banWord, new string('*', banWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}
