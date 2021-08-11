using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                if (line == "Paid")
                {
                    while (queue.Any())
                    {
                        string person = queue.Dequeue();

                        Console.WriteLine(person);
                    }
                }
                else
                {
                    queue.Enqueue(line);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
