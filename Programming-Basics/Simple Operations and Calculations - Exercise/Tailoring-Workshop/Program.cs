using System;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double tableLengthMeters = double.Parse(Console.ReadLine());
            double tableWidthMeters = double.Parse(Console.ReadLine());

            double tableclothArea = (tableLengthMeters + 0.6) * (tableWidthMeters + 0.6);
            double tableCoverArea = 0.5 * tableLengthMeters * 0.5 * tableLengthMeters;
            double priceUSD = (tableclothArea * 7 + tableCoverArea * 9) * tables;
            double priceBGN = priceUSD * 1.85;

            Console.WriteLine($"{priceUSD:f2} USD");
            Console.WriteLine($"{priceBGN:f2} BGN");

        }
    }
}
