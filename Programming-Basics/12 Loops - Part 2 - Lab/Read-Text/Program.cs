using System;

namespace Read_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = 0;

            while (text != "Stop")
            {
                text = Console.ReadLine();
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
