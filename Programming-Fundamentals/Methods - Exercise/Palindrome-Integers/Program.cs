using System;

namespace Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            while (num != "END")
            {
                if (num[0] != num[num.Length - 1])
                {
                    Console.WriteLine("false");
                }
                else
                {
                    Console.WriteLine("true");
                }

                num = Console.ReadLine();
            }
        }
    }
}
