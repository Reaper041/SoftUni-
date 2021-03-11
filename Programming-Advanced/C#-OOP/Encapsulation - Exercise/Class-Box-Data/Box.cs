using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Length));

                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Width));

                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Height));

                height = value;
            }
        }

        public void Volume()
        {
            Console.WriteLine($"Volume - {Length * Width * Height:f2}");
        }

        public void LateralSurfaceArea()
        {
            Console.WriteLine($"Lateral Surface Area - {2 * Length * Height + 2 * Width * Height:f2}");
        }

        public void SurfaceArea()
        {
            Console.WriteLine($"Surface Area - {2 * Length * Width + 2 * Length * Height + 2 * Width * Height:f2}");
        }

        private void ThrowIfInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                Console.WriteLine($"{side} cannot be zero or negative.");
                System.Environment.Exit(0);
            }
        }
    }
}
