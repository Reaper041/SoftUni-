using System;

namespace Graphic_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square();
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            
            square.Draw();
            circle.Draw();
            rectangle.Draw();

            GraphicEditor graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(circle);
        }
    }
}
