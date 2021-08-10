using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string line = Console.ReadLine().ToLower();

            while (line != "end")
            {
                string[] commandData = line
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (command == "add")
                {
                    int firstNumber = int.Parse(commandData[1]);
                    int secondNumber = int.Parse(commandData[2]);

                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (command == "remove")
                {
                    int count = int.Parse(commandData[1]);

                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                line = Console.ReadLine().ToLower();
            }

            int sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
