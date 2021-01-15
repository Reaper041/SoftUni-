using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earning
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double moneyperday = double.Parse(Console.ReadLine());
            double course = double.Parse(Console.ReadLine());

            double moneypermonth = moneyperday * days;
            double moneyperyear = (moneypermonth * 12) + (2.5 * moneypermonth);
            double total = (moneyperyear - (25.00 / 100 * moneyperyear)) * course;
            double totalmoneyperday = total / 365;

            Console.WriteLine("{0:f2}", totalmoneyperday);
        }
    }
}
