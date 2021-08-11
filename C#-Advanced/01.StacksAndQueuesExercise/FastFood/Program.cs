using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool IsFoodEnough = true;

            Queue<int> queue = new Queue<int>(orders);

            int biggestOrder = queue.Max();

            while (queue.Any() && IsFoodEnough)
            {
                int order = queue.Peek();

                if (totalFood >= order)
                {
                    totalFood -= order;

                    queue.Dequeue();
                }
                else
                {
                    IsFoodEnough = false;
                }
            }

            Console.WriteLine(biggestOrder);

            if (queue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine($"Orders complete");
            }
        }
    }
}
