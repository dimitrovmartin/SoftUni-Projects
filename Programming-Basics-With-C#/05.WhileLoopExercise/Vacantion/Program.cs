using System;

namespace Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeed = double.Parse(Console.ReadLine());
            double moneyHave = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double spendSave = double.Parse(Console.ReadLine());

            int daysSpend = 0;
            int daysPassed = 0;

            bool moneySaved = false;

            while (!moneySaved)
            {
                daysPassed++;

                if (command == "spend")
                {
                    moneyHave -= spendSave;

                    daysSpend++;

                    if (spendSave >= moneyHave)
                    {
                        moneyHave = 0;
                    }

                    if (daysSpend == 5)
                    {
                        break;
                    }
                }
                else if (command == "save")
                {
                    moneyHave += spendSave;
                    daysSpend = 0;
                }
                if (moneyHave >= moneyNeed)
                {
                    moneySaved = true;
                    continue;
                }

                command = Console.ReadLine();

                spendSave = double.Parse(Console.ReadLine());
            }

            if (moneySaved)
            {
                Console.WriteLine($"You saved the money for {daysPassed} days.");
            }
            else
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine($"{daysPassed}");
            }
        }
    }
}
