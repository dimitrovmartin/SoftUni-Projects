using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] commandParts = line.Split();

                if (commandParts[0] == "Add")
                {
                    int newWagonPassangers = int.Parse(commandParts[1]);

                    wagons.Add(newWagonPassangers);
                }
                else
                {
                    int newPassangers = int.Parse(commandParts[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + newPassangers <= maxCapacity)
                        {
                            wagons[i] += newPassangers;
                            break;
                        }
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
