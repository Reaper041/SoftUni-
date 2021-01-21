using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());

            Queue<string> pumpsInfo = new Queue<string>();

            for (int i = 0; i < pumps; i++)
            {
                pumpsInfo.Enqueue(Console.ReadLine());

            }

            for (int i = 0; i < pumps; i++)
            {
                int liters = 0;
                bool flag = true;
                for (int j = 0; j < pumps; j++)
                {
                    int[] pumpInfo = pumpsInfo.Dequeue().Split().Select(int.Parse).ToArray();

                    liters += pumpInfo[0];
                    liters -= pumpInfo[1];

                    if (liters < 0)
                    {
                        flag = false;
                    }

                    pumpsInfo.Enqueue(string.Join(" ", pumpInfo));

                }

                if (flag == true)
                {
                    Console.WriteLine(i);
                    break;
                }

                string inf = pumpsInfo.Dequeue();
                pumpsInfo.Enqueue(inf);
            }
        }
    }
}
