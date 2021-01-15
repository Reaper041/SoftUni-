using System;

namespace Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("The English alphabet is: ");
            for (char i = 'a'; i <= 'z'; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
