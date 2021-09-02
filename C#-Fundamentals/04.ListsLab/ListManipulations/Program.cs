using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] arr = input.Split().ToArray();
                string command = arr[0];

                if (command == "Add")
                {
                    int number = int.Parse(arr[1]);
                    numbers.Add(number);
                }
                else if (command == "Remove")
                {
                    int number = int.Parse(arr[1]);
                    numbers.Remove(number);
                }
                else if (command == "RemoveAt")
                {
                    int index = int.Parse(arr[1]);
                    numbers.RemoveAt(index);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(arr[1]);
                    int index = int.Parse(arr[2]);
                    numbers.Insert(index, number);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
