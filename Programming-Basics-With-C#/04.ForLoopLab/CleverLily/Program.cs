using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            double washingMashinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            int toysCount = 0;
            int moneySum = 0;
            int moneyPresent = 10;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    moneySum += moneyPresent - 1;
                    moneyPresent += 10;
                }
                else
                {
                    toysCount++;
                }
            }

            double totalMoneyCollected = moneySum + (toysCount * toysPrice);

            if (totalMoneyCollected >= washingMashinePrice)
            {
                Console.WriteLine($"Yes! {totalMoneyCollected - washingMashinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMashinePrice - totalMoneyCollected:f2}");
            }

        }
    }
}
