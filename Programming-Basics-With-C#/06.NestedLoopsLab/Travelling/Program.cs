using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            while (country != "End")
            {
                double moneySaved = 0;

                double moneyNeed = double.Parse(Console.ReadLine());

                while (moneySaved < moneyNeed)
                {
                    moneySaved += double.Parse(Console.ReadLine());
                }

                Console.WriteLine($"Going to {country}!");

                country = Console.ReadLine();
            }
        }
    }
}
