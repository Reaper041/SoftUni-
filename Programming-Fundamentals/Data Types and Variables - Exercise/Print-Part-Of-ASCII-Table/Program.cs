using System;

namespace Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            for (char i = (char)startNum; i <= endNum; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}
