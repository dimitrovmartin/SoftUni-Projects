using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queue = new Queue<string>(songs);

            string line = Console.ReadLine();

            while (queue.Any())
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "Play")
                {
                    queue.Dequeue();

                    if (!queue.Any())
                    {
                        break;
                    }
                }
                else if (command == "Add")
                {
                    string song = string.Join(" ", commandData.Skip(1));

                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
