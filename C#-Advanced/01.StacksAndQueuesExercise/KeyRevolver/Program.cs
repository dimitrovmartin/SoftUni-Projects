using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelCapacity = int.Parse(Console.ReadLine());

            int[] bulletsData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locksData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int price = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsData);
            Queue<int> locks = new Queue<int>(locksData);

            int totalBulletsShoted = 0;
            int bulletsShoted = 0;

            while (bullets.Any() && locks.Any())
            {
                int bullet = bullets.Pop();
                int @lock = locks.Peek();

                totalBulletsShoted++;
                bulletsShoted++;

                if (bullet <= @lock)
                {
                    Console.WriteLine($"Bang!");

                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Ping!");
                }

                if (bulletsShoted == gunBarrelCapacity)
                {
                    if (bullets.Any())
                    {
                        Console.WriteLine($"Reloading!");
                        bulletsShoted = 0;
                    }
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int totalMoney = price - totalBulletsShoted * bulletPrice;

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${totalMoney}");
            }
        }
    }
}
