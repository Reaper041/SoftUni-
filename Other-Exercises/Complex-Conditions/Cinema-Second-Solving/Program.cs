using System;

namespace Cinema_Second_Solving
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            switch (projectionType)
            {
                case "premiere":
                    Console.WriteLine("{0:f2}", 12.00 * rows * column);
                    break;
                case "normal":
                    Console.WriteLine("{0:f2}", 7.50 * rows * column);
                    break;
                case "discount":
                    Console.WriteLine("{0:f2}", 5.00 * rows * column);
                    break;
            }
        }
    }
}
