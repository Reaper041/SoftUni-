using System;

namespace Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool inRectangle1 = (x > h && x < 2 * h) && (y < 4 * h && y > h);
            bool inRectangle2 = (x > 0 && x < 3 * h) && (y > 0 && y < h);

            bool outRectangle1 = (x < h || x > 2 * h) || (y > 4 * h || y < h);
            bool outRectangle2 = (x < 0 || x > 3 * h) || (y < 0 || y > h);
            bool commonBorder = (x > h) && (x < 2 * h) && y == h;

            if (inRectangle1  || inRectangle2 || commonBorder)
            {
                Console.WriteLine("inside");
            }
            else if (outRectangle1  && outRectangle2 )
            {
                Console.WriteLine("outside");
            }
            else
            {
                Console.WriteLine("border");
            }
        }
    }
}
