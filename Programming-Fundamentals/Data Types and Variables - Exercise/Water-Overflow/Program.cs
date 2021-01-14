using System;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalWater = 0;
            for (int i = 0; i < n; i++)
            {
                int quantityOfWater = int.Parse(Console.ReadLine());
                totalWater += quantityOfWater;
                if (totalWater > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    totalWater -= quantityOfWater;
                }
            }
            Console.WriteLine(totalWater);
        }
    }
}
