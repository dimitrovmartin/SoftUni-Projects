using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            double side1 = double.Parse(Console.ReadLine());
            double side2 = double.Parse(Console.ReadLine());

            double area = side1 * side2;

            string cakeParts = Console.ReadLine();

            while (cakeParts != "STOP")
            {
                int input = int.Parse(cakeParts);

                area -= input;

                if (area <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(area)} pieces more.");
                    break;
                }

                cakeParts = Console.ReadLine();
            }

            if (cakeParts == "STOP")
            {
                Console.WriteLine($"{area} pieces are left.");
            }
        }
    }
}
