using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumAndMaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] commandData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int query = commandData[0];

                if (query == 1)
                {
                    int number = commandData[1];

                    stack.Push(number);
                }
                else if (stack.Any())
                {
                    if (query == 2)
                    {
                        stack.Pop();
                    }
                    else if (query == 3)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (query == 4)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
