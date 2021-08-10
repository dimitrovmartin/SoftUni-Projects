using System;

namespace TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            int kms = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {city} has population of {population} and area {kms} square km.");
        }
    }
}
