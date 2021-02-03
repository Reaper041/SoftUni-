using System;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string fig = Console.ReadLine();

            if (fig == "square")
            {
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine(a * a);
            }
            else if (fig == "circle")
            {
                double r = double.Parse(Console.ReadLine());

                Console.WriteLine(Math.PI * r * r);
            }
            else if (fig == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine(a * b);
            }
            else
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());


                Console.WriteLine(a*h/2);
            }

        }
    }
}
