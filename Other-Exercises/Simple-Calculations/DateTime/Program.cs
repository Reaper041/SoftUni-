using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTime1
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = date.AddDays(1000);
            Console.WriteLine(date.ToString("dd-MM-yyyy"));
        }
    }
}
