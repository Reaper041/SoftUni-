using System;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 1;
            int last = 0;
            for (int rows = 1; rows <= n; rows++)
            {
                for (int colls = 1; colls <= rows; colls++)
                {
                    Console.Write($"{count} ");
                    last = count;
                    count++;
                    if (last == n)
                    {
                        return;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
