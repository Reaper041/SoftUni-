using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string biggestKeg = String.Empty;
            double maxValue = double.MinValue;
            for (int i = 0; i < n; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                double kegVolume  = Math.PI * kegRadius * kegRadius * kegHeight;
                if (kegVolume > maxValue)
                {
                    biggestKeg = kegModel;
                    maxValue = kegVolume;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
