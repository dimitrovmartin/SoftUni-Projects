using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0;

            if (budget <= 100 && season == "summer")
            {
                price = budget * 0.3;

                Console.WriteLine("Somewhere in Bulgaria");
                Console.WriteLine($"Camp - {price:f2}");
            }
            else if (budget <= 100 && season == "winter")
            {
                price = budget * 0.7;

                Console.WriteLine("Somewhere in Bulgaria");
                Console.WriteLine($"Hotel - {price:f2}");
            }
            else if (budget <= 1000 && season == "summer")
            {
                price = budget * 0.4;

                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine($"Camp - {price:f2}");
            }
            else if (budget <= 1000 && season == "winter")
            {
                price = budget * 0.8;

                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine($"Hotel - {price:f2}");
            }
            else if (budget > 1000)
            {
                price = budget * 0.9;

                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {price:f2}");
            }
        }
    }
}