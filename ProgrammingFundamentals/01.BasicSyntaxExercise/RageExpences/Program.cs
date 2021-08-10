using System;

namespace RageExpences
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());

            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double monitorPrice = double.Parse(Console.ReadLine());

            double moneyExpences = headSetPrice * (lostGamesCount / 2) + mousePrice * (lostGamesCount / 3) + keyboardPrice * (lostGamesCount / 6) + monitorPrice * (lostGamesCount / 12);

            Console.WriteLine($"Rage expenses: {moneyExpences:f2} lv.");


        }
    }
}
