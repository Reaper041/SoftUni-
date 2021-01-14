using System;
using System.Text.RegularExpressions;

namespace Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            string reg = @"\b[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+\b";

            var regex = new Regex(reg);

            Console.WriteLine(string.Join(' ', regex.Matches(names)));
        }
    }
}
