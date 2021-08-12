using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbersArr = Console.ReadLine()
                .Split("|");

            List<int> mergedArrays = new List<int>();

            for (int i = numbersArr.Length - 1; i >= 0; i--)
            {
                int[] arr = numbersArr[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < arr.Length; j++)
                {
                    mergedArrays.Add(arr[j]);
                }
            }

            Console.WriteLine(string.Join(" ",mergedArrays));
        }
    }
}
