using System;

namespace Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            string[] stringArr = line.Split();
            Array.Reverse(stringArr);

            foreach (string item in stringArr)
            {
                Console.Write(item + " ");
            }


        }
    }
}
