using System;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallLength = double.Parse(Console.ReadLine());
            double hallWidth = double.Parse(Console.ReadLine());
            double wardrobeSide = double.Parse(Console.ReadLine());

            double hallArea = hallLength * hallWidth * 10000;
            double wardrobeArea = wardrobeSide * wardrobeSide * 10000;
            double bench = hallArea / 10.0;
            double dancingArea = hallArea - wardrobeArea - bench;

            Console.WriteLine(Math.Floor(dancingArea / 7040.0));

        }
    }
}
