using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
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

            Queue<int> queue = new Queue<int>();

            Enqueue(numbers, n, queue);
            Dequeue(s, queue);


            if (queue.Any())
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static void Dequeue(int s, Queue<int> Queue)
        {
            for (int i = 0; i < s; i++)
            {
                if (Queue.Any())
                {
                    Queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
        }

        private static void Enqueue(int[] numbers, int n, Queue<int> Queue)
        {
            for (int i = 0; i < n; i++)
            {
                Queue.Enqueue(numbers[i]);
            }
        }
    }
}
