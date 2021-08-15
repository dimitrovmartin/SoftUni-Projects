using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape circle = new Circle(2);
            Shape rectangle = new Rectangle(2, 3);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());
        }
    }
}