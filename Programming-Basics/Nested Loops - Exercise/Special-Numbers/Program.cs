using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int sym1 = 1; sym1 < 9; sym1++)
            {
                for (int sym2 = 1; sym2 < 9; sym2++)
                {
                    for (int sym3 = 1; sym3 < 9; sym3++)
                    {
                        for (int sym4 = 1; sym4 < 9; sym4++)
                        {
                            bool specialNum= n % sym1 == 0 && n % sym2 == 0 && n % sym3 == 0 && n % sym4 == 0;

                            if (specialNum)
                            {
                                Console.Write($"{sym1}{sym2}{sym3}{sym4} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
