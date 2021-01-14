using System;
using System.Threading.Channels;

namespace Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(first, second));
                
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(first, second));
            }
            else if (type == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                Console.WriteLine(GetMax(first, second));
            }


        }

        static int GetMax(int first, int second)
        {
            int max = 0;
            if (first > second)
            {
                max = first;
            }
            else
            {
                max = second;
            }

            return max;
        }

        static string GetMax(string first, string second)
        {
            string max = string.Empty;
            if (first.CompareTo(second) > 0)
            {
                max = first;
            }
            else
            {
                max = second;
            }

            return max;
        }

        static char GetMax(char first, char second)
        {
            char max;
            if (first > second)
            {
                max = first;
            }
            else
            {
                max = second;
            }

            return max;
        }
    }
}
