using System;

namespace Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            int countPairs = 0;
            bool flag = false;

            for (int a = num1; a <= num2; a++)
            {
                for (int b = num1; b <= num2; b++)
                {
                    sum = a + b;
                    count++;
                    if (sum == magicNum)
                    {
                        Console.WriteLine($"Combination N:{count} ({a} + {b} = {sum})");
                        countPairs++;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }

            if (countPairs == 0)
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNum}");
            }
        }
    }
}
