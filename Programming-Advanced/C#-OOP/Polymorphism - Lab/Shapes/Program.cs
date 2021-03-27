using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(6, 8);
            Shape circle = new Circle(3);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());

            Console.WriteLine(circle.Draw());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
        }
    }
}
