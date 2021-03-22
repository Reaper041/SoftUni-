using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sitesToVisit = Console.ReadLine().Split();

            ISmartphone smartphone = new Phone();
            IStationaryPhone stationaryPhone = new Phone();

            foreach (var number in phoneNumbers)
            {
                if (Regex.IsMatch(number, "[a-z]|[A-Z]"))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (number.Length == 10)
                {
                    smartphone.CallOtherPhone(number, "Calling");
                }
                else if (number.Length == 7)
                {
                    stationaryPhone.CallOtherPhone(number, "Dialing");
                }
            }

            foreach (var site in sitesToVisit)
            {
                if (Regex.IsMatch(site, "[0-9]"))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                smartphone.Browse(site);
            }
        }
    }
}
