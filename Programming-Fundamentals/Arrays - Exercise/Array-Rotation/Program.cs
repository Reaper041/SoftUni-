using System;

namespace Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int numberOfRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotations; i++)
            {
                string firstSymbol = array[0];
                for (int j = 0; j <= array.Length - 2; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = firstSymbol;
            }
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
