using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSec = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondsForMeter = double.Parse(Console.ReadLine());

            double resistance = Math.Floor(meters / 15) * 12.5;

            double total = (meters * secondsForMeter) + resistance;

            if (recordInSec > total)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {total:f2} seconds.");
            }
            else if (recordInSec <= total)
            {
                Console.WriteLine($"No, he failed! He was {total - recordInSec:f2} seconds slower.");
            }
        }
    }
}
