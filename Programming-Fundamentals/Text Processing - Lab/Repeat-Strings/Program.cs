using System;
using System.Text;

namespace Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                for (int j = 0; j < line[i].Length; j++)
                {
                    sb.Append(line[i]);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
