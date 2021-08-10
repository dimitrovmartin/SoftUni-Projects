using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBotique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            int currentCapacity = rackCapacity;
            int racksCount = 1;

            Queue<int> wardrobe = new Queue<int>(clothes);

            while (wardrobe.Any())
            {
                int currentDress = wardrobe.Dequeue();

                if (currentCapacity - currentDress >= 0)
                {
                    currentCapacity -= currentDress;
                }
                else
                {
                    currentCapacity = rackCapacity - currentDress;
                    racksCount++;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
