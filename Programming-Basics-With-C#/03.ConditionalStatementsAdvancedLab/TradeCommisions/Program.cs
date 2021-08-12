using System;

namespace TradeCommisions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sellings = double.Parse(Console.ReadLine());
            double comission = 0;

            bool isTownAndSellingsValid = true;

            if (town == "Sofia")
            {
                if (sellings >= 0 && sellings <= 500)
                {
                    comission = 0.05;
                }
                else if (sellings > 500 && sellings <= 1000)
                {
                    comission = 0.07;
                }
                else if (sellings > 1000 && sellings <= 10000)
                {
                    comission = 0.08;
                }
                else if (sellings > 10000)
                {
                    comission = 0.12;
                }
                else
                {
                    isTownAndSellingsValid = false;
                }

            }
            else if (town == "Varna")
            {
                if (sellings >= 0 && sellings <= 500)
                {
                    comission = 0.045;
                }
                else if (sellings > 500 && sellings <= 1000)
                {
                    comission = 0.075;
                }
                else if (sellings > 1000 && sellings <= 10000)
                {
                    comission = 0.1;
                }
                else if (sellings > 10000)
                {
                    comission = 0.13;

                }
                else
                {
                    isTownAndSellingsValid = false;
                }
            }
            else if (town == "Plovdiv")
            {
                if (sellings >= 0 && sellings <= 500)
                {
                    comission = 0.055;
                }
                else if (sellings > 500 && sellings <= 1000)
                {
                    comission = 0.08;
                }
                else if (sellings > 1000 && sellings <= 10000)
                {
                    comission = 0.12;
                }
                else if (sellings > 10000)
                {
                    comission = 0.145;
                }
                else
                {
                    isTownAndSellingsValid = false;
                }
            }
            else
            {
                isTownAndSellingsValid = false;
            }

            if (isTownAndSellingsValid)
            {
            Console.WriteLine($"{sellings * comission:f2}");
            }
            else
            {
                Console.WriteLine($"error");
            }
        }
    }
}
