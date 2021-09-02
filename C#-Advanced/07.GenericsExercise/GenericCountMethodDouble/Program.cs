using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double value = double.Parse(Console.ReadLine());

                Box<double> box = new Box<double>(value);

                boxes.Add(box);
            }

            double element = double.Parse(Console.ReadLine());

            double biggestElementsCount = GetBiggestElementsCount(element, boxes);

            Console.WriteLine(biggestElementsCount);
        }

        public static void Swap<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            Box<T> temp = boxes[firstIndex];

            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }

        public static double GetBiggestElementsCount<T>(T value, List<Box<T>> boxes)
            where T : IComparable
        {
            return boxes.Where(b => b.Value.CompareTo(value) > 0).ToList().Count;
        }
    }
}
