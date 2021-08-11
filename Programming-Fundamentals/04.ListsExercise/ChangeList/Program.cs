using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] commandParts = line.Split();
                string command = commandParts[0];
                int number = int.Parse(commandParts[1]);

                if (command == "Delete")
                {
                    while (numbers.Contains(number))
                    {
                        numbers.Remove(number);
                    }
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(commandParts[2]);

                    numbers.Insert(index, number);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}