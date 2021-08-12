using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double precentage = double.Parse(Console.ReadLine());

            double precentageInProcents = precentage / 100;
            double volume = length * width * height;
            double totalLiters = volume * 0.001;

            double littersNeed = totalLiters * (1 - precentageInProcents);

            Console.WriteLine(littersNeed);
        }
    }
}
