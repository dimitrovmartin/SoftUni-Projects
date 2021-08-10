using System;
using System.Numerics;

namespace Snowball
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger bestSnowball = 0;
            int bestBall = 0;
            int bestTime = 0;
            int bestQuality = 0;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger result = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (result > bestSnowball)
                {
                    bestSnowball = result;
                    bestBall = snowballSnow;
                    bestTime = snowballTime;
                    bestQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{bestBall} : {bestTime} = {bestSnowball} ({bestQuality})");
        }
    }
}
