using System;

namespace ChairityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int pastryCookers = int.Parse(Console.ReadLine());
            int cakesCount = int.Parse(Console.ReadLine());
            int wafflesCount = int.Parse(Console.ReadLine());
            int pancakesCount = int.Parse(Console.ReadLine());

            double cakePrice = 45;
            double wafflePrice = 5.80;
            double pancakesPrice = 3.20;

            double moneyForOneDay = pastryCookers * (cakesCount * cakePrice + wafflesCount * wafflePrice + pancakesCount * pancakesPrice);

            double totalMoney = moneyForOneDay * days;
            double costs = totalMoney / 8;

            totalMoney -= costs;

            Console.WriteLine(totalMoney);
        }
    }
}
