using System;

namespace GodzilaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double extrasClothesPrice = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;

            if (extras > 150)
            {
                extrasClothesPrice = extrasClothesPrice - (extrasClothesPrice * 0.1);
            }
            else
            {

            }

            double moneyNeed = extras * extrasClothesPrice + decor;

            if (moneyNeed > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeed - budget:F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - moneyNeed:F2} leva left.");
            }
        }
    }
}
