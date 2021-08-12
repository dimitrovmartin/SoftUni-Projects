using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int capacity = 0;

            for (int i = 0; i < n; i++)
            {
                int water = int.Parse(Console.ReadLine());

                if (capacity + water > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity += water;
                }
            }

            Console.WriteLine(capacity);
        }
    }
}
