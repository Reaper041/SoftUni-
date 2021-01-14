using System;

namespace Stream_Of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = 0;

            while (text != "End")
            {
                count++;
                if (text == "n" || text == "o" || text == "c")
                {
                    count++;
                }
                else
                {
                    Console.Write(text);
                }
                if (count == 3)
                {
                    Console.WriteLine(" ");
                }
                text = Console.ReadLine();

            }
        }
    }
}
