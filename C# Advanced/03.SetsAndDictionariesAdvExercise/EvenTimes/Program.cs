using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int,int> numbersByCount = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numbersByCount.ContainsKey(number))
                {
                    numbersByCount[number]++;
                }
                else
                {
                    numbersByCount.Add(number, 1);
                }
            }

            KeyValuePair<int, int> kvp = numbersByCount.First(n => n.Value % 2 == 0);

            Console.WriteLine(kvp.Key);
        }
    }
}
