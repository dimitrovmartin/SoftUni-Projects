using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int weekends = 48;

            double weekendsInSofia = (weekends - h);
            double gamesInSofia = weekendsInSofia * 3.0 / 4;
            double gameWeekHome = h;
            double gameWeek = p * 2.0 / 3;

            double result = gameWeek + gameWeekHome + gamesInSofia;

            switch (year)
            {
                case "leap":
                    result = result + result * 0.15;
                    Console.WriteLine($"{Math.Floor(result)}");
                    break;
                default:
                    Console.WriteLine($"{Math.Floor(result)}");
                    break;
            }
        }
    }
}
