using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            List<int> secondList = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            List<int> newList = new List<int>();

            for (int i = 0; i < Math.Max(firstList.Count,secondList.Count); i++)
            {
                if (i < firstList.Count)
                {
                    newList.Add(firstList[i]);
                }
                if (i < secondList.Count)
                {
                    newList.Add(secondList[i]);
                }
            }
            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
