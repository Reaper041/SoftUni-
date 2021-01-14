using System;

namespace Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                bool flag = false;
                int index = i;
                int sum = 0;
                while (index != 0)
                {
                    if (index % 10 % 2 == 1)
                    {
                        flag = true;
                    }
                    sum += index % 10;
                    index /= 10;
                }

                if (sum % 8 == 0 && flag)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
