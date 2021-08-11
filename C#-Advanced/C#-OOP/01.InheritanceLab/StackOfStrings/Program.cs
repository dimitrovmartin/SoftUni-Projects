using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.Push("item");

            Console.WriteLine(stack.IsEmpty());

            List<string> range = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                range.Add($"{i}");
            }

            stack.AddRange(range);

            while (stack.Any())
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
