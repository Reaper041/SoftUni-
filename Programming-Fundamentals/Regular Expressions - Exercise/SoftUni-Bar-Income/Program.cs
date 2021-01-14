using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"%(?<customer>[A-Z]{1}[a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)\$";

            Regex regex = new Regex(pattern);
            StringBuilder sb = new StringBuilder();
            double total = 0;

            while (input != "end of shift")
            {
                var match = regex.Match(input);

                if (match.Success)
                {
                    var matchCustomer = regex.Match(input).Groups[1].Value;
                    var matchProduct = regex.Match(input).Groups[2].Value;
                    var matchCount = int.Parse(regex.Match(input).Groups[3].Value);
                    var matchPrice = double.Parse(regex.Match(input).Groups[4].Value);
                    total += matchCount * matchPrice;

                    //sb.AppendLine($"{matchCustomer}: {matchProduct} - {matchPrice * matchCount:f2}");
                    Console.WriteLine($"{matchCustomer}: {matchProduct} - {matchPrice * matchCount:f2}");
                }

                input = Console.ReadLine();
            }

            //sb.AppendLine($"Total income: {total:f2}");
            Console.WriteLine($"Total income: {total:f2}");
            Console.WriteLine(sb.ToString());
        }
    }
}
