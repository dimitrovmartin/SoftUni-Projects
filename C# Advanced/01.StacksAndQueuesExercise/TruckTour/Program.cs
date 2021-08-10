using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();


            for (int i = 0; i < pumpsCount; i++)
            {
                int[] pump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(pump);
            }

            for (int i = 0; i < pumpsCount; i++)
            {
                int fuel = 0;
                bool isSuccessful = true;

                for (int j = 0; j <= pumpsCount; j++)
                {
                    int[] currentPump = pumps.Dequeue();

                    int currentFuel = currentPump[0];
                    int currentDistance = currentPump[1];

                    fuel += currentFuel - currentDistance;

                    if (fuel < 0)
                    {
                        isSuccessful = false;
                    }

                    pumps.Enqueue(currentPump);
                }

                if (isSuccessful)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
