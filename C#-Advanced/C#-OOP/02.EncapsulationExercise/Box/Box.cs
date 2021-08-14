using System;
using System.Collections.Generic;
using System.Text;

namespace Box
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
                if (value <= 0)
                {
                    ThrowException("Length");
                }
                else
                {
                    length = value;
                }
            }
        }

        public double Width
        {
            get => width;

            private set
            {
                if (value <= 0)
                {
                    ThrowException("Width");
                }
                else
                {
                    width = value;
                }
            }
        }

        public double Height
        {
            get => height;

            private set
            {
                if (value <= 0)
                {
                    ThrowException("Height");
                }
                else
                {
                    height = value;
                }
            }
        }

        public double CalculateSurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double CalculateVolume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {CalculateSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {CalculateVolume():F2}");

            return sb.ToString().TrimEnd();
        }

        private void ThrowException(string side)
        {
            throw new ArgumentException($"{side} cannot be zero or negative.");
        }
    }
}
