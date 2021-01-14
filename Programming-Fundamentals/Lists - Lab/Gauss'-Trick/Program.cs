using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            List<int> numbersList = new List<int>();
            numbersList = numbers.Split().Select(int.Parse).ToList();

            int lenght = numbersList.Count / 2;

            for (int i = 0; i < lenght; i++)
            {
                numbersList[i] += numbersList[numbersList.Count - 1];
                numbersList.RemoveAt(numbersList.Count - 1);
            }

            Console.WriteLine(string.Join(' ', numbersList));
        }
    }
}
