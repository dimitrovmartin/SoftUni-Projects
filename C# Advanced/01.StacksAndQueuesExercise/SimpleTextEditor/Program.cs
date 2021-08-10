using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();

            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] commandData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(commandData[0]);

                if (command == 1)
                {
                    stack.Push(result);

                    string text = string.Join(string.Empty, commandData.Skip(1));

                    result += text;
                }
                else if (command == 2)
                {
                    int count = int.Parse(commandData[1]);

                    if (result.Length >= count)
                    {
                        stack.Push(result);

                        result = result.Remove(result.Length - count);
                    }
                }
                else if (command == 3)
                {
                    int index = int.Parse(commandData[1]);

                    if (result.Length >= index)
                    {
                        Console.WriteLine(result[index - 1]);
                    }
                }
                else if (command == 4)
                {
                    if (stack.Any())
                    {
                        result = stack.Pop();
                    }
                }
            }
        }
    }
}
