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

            string element = Console.ReadLine();

            int biggestElementsCount = GetBiggestElementsCount(element, boxes);

            Console.WriteLine(biggestElementsCount);
        }

        public static void Swap<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            Box<T> temp = boxes[firstIndex];

            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }

        public static int GetBiggestElementsCount<T>(T value, List<Box<T>> boxes)
            where T: IComparable
        {
            return boxes.Where(b => b.Value.CompareTo(value) > 0).ToList().Count;
        }
    }
}
