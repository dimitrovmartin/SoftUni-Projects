using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal change = decimal.Parse(Console.ReadLine());

            int coinsCount = 0;

            while (change != 0)
            {
                if (change >= 2)
                {
                    change -= 2;

                    coinsCount++;
                }
                else if (change >= 1)
                {
                    change -= 1;

                    coinsCount++;
                }
                else if (change >= 0.5m)
                {
                    change -= 0.5m;

                    coinsCount++;
                }
                else if (change >= 0.2m)
                {
                    change -= 0.2m;

                    coinsCount++;
                }
                else if (change >= 0.1m)
                {
                    change -= 0.1m;

                    coinsCount++;
                }
                else if (change >= 0.05m)
                {
                    change -= 0.05m;

                    coinsCount++;
                }
                else if (change >= 0.02m)
                {
                    change -= 0.02m;

                    coinsCount++;
                }
                else if (change >= 0.01m)
                {
                    change -= 0.01m;

                    coinsCount++;
                }
            }

            Console.WriteLine(coinsCount);
        }
    }
}