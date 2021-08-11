using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constants = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int n = constants[0];
            int s = constants[1];
            int x = constants[2];

            Stack<int> stack = new Stack<int>();

            Push(numbers, n, stack);
            Pop(s, stack);

            
            if (stack.Any())
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static void Pop(int s, Stack<int> stack)
        {
            for (int i = 0; i < s; i++)
            {
                if (stack.Any())
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }
        }

        private static void Push(int[] numbers, int n, Stack<int> stack)
        {
            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
        }
    }
}
