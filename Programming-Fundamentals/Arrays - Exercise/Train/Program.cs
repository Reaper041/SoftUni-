using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] peopleArray = new int[wagons];
            int sum = 0;
            for (int i = 0; i < wagons; i++)
            {
                int peopleInWagon = int.Parse(Console.ReadLine());
                peopleArray[i] = peopleInWagon;
                sum += peopleArray[i];
            }
            //Console.WriteLine(sum);
            Console.WriteLine(string.Join(' ', peopleArray));
            Console.WriteLine(peopleArray.Sum());
        }
    }
}
