using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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

            while (line != "End")
            {
                string[] commandParts = line
                    .Split();
                string command = commandParts[0];

                if (command == "Add")
                {
                    int number = int.Parse(commandParts[1]);

                    numbers.Add(number);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(commandParts[1]);
                    int index = int.Parse(commandParts[2]);

                    if (index > numbers.Count - 1 || index < 0)
                    {
                        Console.WriteLine($"Invalid index");

                        line = Console.ReadLine();
                        continue;
                    }

                    numbers.Insert(index, number);
                }
                else if (command == "Remove")
                {
                    int index = int.Parse(commandParts[1]);

                    if (index > numbers.Count - 1 || index < 0)
                    {
                        Console.WriteLine($"Invalid index");
                        
                        line = Console.ReadLine();
                        continue;
                    }

                    numbers.RemoveAt(index);
                }
                else if (command == "Shift")
                {
                    string direction = commandParts[1];
                    int counts = int.Parse(commandParts[2]);

                    if (direction == "left")
                    {
                        for (int i = 0; i < counts; i++)
                        {
                            int firstNumber = numbers[0];

                            numbers.RemoveAt(0);
                            numbers.Add(firstNumber);
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < counts; i++)
                        {
                            int lastNumber = numbers[numbers.Count - 1];

                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastNumber);
                        }
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
