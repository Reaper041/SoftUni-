using System;
using System.Linq;

namespace Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                string keyword = command[0];

                if (keyword == "swap")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);

                    int firstNum = numbers[firstIndex];
                    int secondNum = numbers[secondIndex];

                    numbers[firstIndex] = secondNum;
                    numbers[secondIndex] = firstNum;
                }
                else if (keyword == "multiply")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);

                    numbers[firstIndex] = numbers[firstIndex] * numbers[secondIndex];
                }
                else if (keyword == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
