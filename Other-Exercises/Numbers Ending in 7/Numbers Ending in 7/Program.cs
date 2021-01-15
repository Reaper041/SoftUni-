using System;

namespace Numbers_Ending_in_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (i % 10 == 7) Console.WriteLine(i);
            }
        }
    }
}
