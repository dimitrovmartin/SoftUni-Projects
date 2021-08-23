using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                try
                {
                    string[] commandData = line
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    string command = commandData[0];

                    if (command == "Push")
                    {
                        int[] itemsToPush = commandData.Skip(1)
                            .Select(int.Parse)
                            .ToArray();

                        foreach (var item in itemsToPush)
                        {
                            stack.Push(item);
                        }
                    }
                    else if (command == "Pop")
                    {
                        stack.Pop();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
