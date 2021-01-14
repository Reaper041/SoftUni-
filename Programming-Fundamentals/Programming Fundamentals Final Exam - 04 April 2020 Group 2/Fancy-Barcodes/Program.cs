using System;
using System.Text.RegularExpressions;

namespace Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@{1}#{1,})([A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1})(@{1}#{1,})";
            string digitPattern = @"\d";


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                var match = Regex.Match(barcode, pattern);
                string productGroup = string.Empty;

                if (match.Success)
                {
                    var digitMatch = Regex.Match(barcode, digitPattern);

                    if (digitMatch.Success)
                    {
                        foreach (var matchD in Regex.Matches(barcode, digitPattern))
                        {
                            productGroup += matchD.ToString();
                        }
                    }
                    else
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
