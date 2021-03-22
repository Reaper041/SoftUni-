using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Phone : ISmartphone, IStationaryPhone
    {
        public void CallOtherPhone(string number, string message)
        {
            Console.WriteLine($"{message}... {number}");
        }

        public void Browse(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }

    }
}
