using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            double bitcoins = double.Parse(Console.ReadLine());
            double chinesecur = double.Parse(Console.ReadLine());
            double commissioner = double.Parse(Console.ReadLine());

            double bittobgn = bitcoins * 1168;
            double chintousd = chinesecur * 0.15;
            double usdtobgn = chintousd * 1.76;

            double withcomm = ((bittobgn + usdtobgn) / 1.95) - (commissioner / 100 * ((bittobgn + usdtobgn) / 1.95));

            Console.WriteLine(withcomm);


        }
    }
}
