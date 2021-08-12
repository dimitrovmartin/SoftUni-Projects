using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double countFishermen = double.Parse(Console.ReadLine());

            double rent = 0;

            switch (season)
            {
                case "Spring":
                    rent = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    rent = 4200;
                    break;
                case "Winter":
                    rent = 2600;
                    break;
                default:
                    break;
            }

            if (countFishermen <= 6)
            {
                rent = rent - rent * 0.1;
            }
            else if (countFishermen >= 7 && countFishermen <= 11)
            {
                rent = rent - rent * 0.15;
            }
            else if (countFishermen >= 12)
            {
                rent = rent - rent * 0.25;
            }

            if (season != "Autumn" && countFishermen % 2 == 0)
            {
                rent = rent - rent * 0.05;
            }

            if (budget >= rent)
            {
                double moneyLeft = budget - rent;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else if (rent > budget)
            {
                double moneyNeed = rent - budget;
                Console.WriteLine($"Not enough money! You need {moneyNeed:f2} leva.");
            }
        }
    }
}