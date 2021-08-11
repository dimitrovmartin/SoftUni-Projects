using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<char> stack = new Stack<char>(text);

            while (stack.Any())
            {
                char currentChar = stack.Pop();

                Console.Write(currentChar);
            }
        }
    }
}
