using System;
using System.Text.RegularExpressions;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"U\$([A-Z]{1}[a-z]{2,})U\$P@\$([A-Za-z]{5,}[0-9]+)P@\$";

            int n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    count++;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups[1].Value}, Password: {match.Groups[2].Value}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {count}");
        }
    }
}
