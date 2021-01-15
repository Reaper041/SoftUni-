using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seconds_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            var third = int.Parse(Console.ReadLine());
            var seconds = first + second + third;
            var minutes = 0;

            if (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }
            if (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }
            if (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }

            if (seconds < 10)
            {
                Console.WriteLine(minutes + ":0" + seconds);
            }
            else
            {
                Console.WriteLine(minutes + ":" + seconds);
            }
        }
    }
}
