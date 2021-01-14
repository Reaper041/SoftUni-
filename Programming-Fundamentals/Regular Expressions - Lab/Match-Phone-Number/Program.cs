using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string phoneNumber = Console.ReadLine();
            string reg = @"\+359([- ])2\1[0-9]{3}\1[0-9]{4}\b";

            var phoneMatches = Regex.Matches(phoneNumber, reg);

            var matchedPhones = phoneMatches.Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
