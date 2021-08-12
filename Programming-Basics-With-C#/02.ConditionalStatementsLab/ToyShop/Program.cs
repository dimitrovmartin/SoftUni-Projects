using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double holiday = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.6;
            double dollsPrice = 3;
            double bearPrice = 4.1;
            double minionPrice = 8.2;
            double truckPrice = 2;

            double toysCount = puzzles + dolls + bears + minions + trucks;

            double total = puzzles * puzzlePrice + dolls * dollsPrice + bears * bearPrice + minions * minionPrice + trucks * truckPrice;

            if (toysCount >= 50)
            {
                total -= total * 0.25;
            }

            double rent = total * 0.1;

            total -= rent;

            if (total >= holiday)
            {
                Console.WriteLine($"Yes! {total - holiday:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {holiday - total:f2} lv needed.");
            }
        }
    }
}
