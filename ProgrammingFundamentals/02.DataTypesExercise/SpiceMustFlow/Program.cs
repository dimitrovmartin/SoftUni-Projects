using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int days = 0;
            int totalYieldCollected = 0;
            int workersConsume = 26;

            while (yield >= 100)
            {
                totalYieldCollected += yield - workersConsume;
                yield -= 10;
                days++;
            }

            if (totalYieldCollected >= workersConsume)
            {
                totalYieldCollected -= workersConsume;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalYieldCollected);
        }
    }
}
