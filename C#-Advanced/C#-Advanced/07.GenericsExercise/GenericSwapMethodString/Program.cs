using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();

                Box<string> box = new Box<string>(value);

                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap(boxes, firstIndex, secondIndex);

            Console.WriteLine(string.Join(Environment.NewLine, boxes));
        }

        public static void Swap<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            Box<T> temp = boxes[firstIndex];

            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }
    }
}
