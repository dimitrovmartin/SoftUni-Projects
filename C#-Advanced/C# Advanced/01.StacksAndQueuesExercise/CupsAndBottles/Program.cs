using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottlesData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(bottlesData);
            Queue<int> cups = new Queue<int>(cupsData);

            int wastedWater = 0;

            while (bottles.Any() && cups.Any())
            {
                int bottle = bottles.Pop();
                int cup = cups.Peek();

                cup -= bottle;

                while (cup > 0 && bottles.Any())
                {
                    bottle = bottles.Pop();

                    cup -= bottle;
                }

                cups.Dequeue();

                if (cup < 0)
                {
                    wastedWater += Math.Abs(cup);
                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
