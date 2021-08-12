using System;

namespace RadiansToDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double degrees = r * 180 / Math.PI;

            Console.WriteLine(Math.Round(degrees));
        }
    }
}
