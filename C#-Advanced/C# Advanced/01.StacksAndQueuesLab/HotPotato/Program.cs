using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int count = int.Parse(Console.ReadLine());
            int counter = 0;

            Queue<string> hotPotato = new Queue<string>(children);

            while (hotPotato.Count != 1)
            {
                counter++;

                string child = hotPotato.Dequeue();

                if (counter == count)
                {
                    Console.WriteLine($"Removed {child}");

                    counter = 0;
                }
                else
                {
                    hotPotato.Enqueue(child);
                }
            }

            string lastChild = hotPotato.Dequeue();

            Console.WriteLine($"Last is {lastChild}");
        }
    }
}
