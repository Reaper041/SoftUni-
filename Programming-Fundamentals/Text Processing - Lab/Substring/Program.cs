using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string odd = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();
            int index = text.IndexOf(odd);

            while (index != -1)
            {
                text = text.Remove(index, odd.Length);
                index = text.IndexOf(odd);
            }

            Console.WriteLine(text);
        }
    }
}
