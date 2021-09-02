using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resoursesByCount = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "stop")
            {
                int value = int.Parse(Console.ReadLine());

                if (resoursesByCount.ContainsKey(line))
                {
                    resoursesByCount[line] += value;
                }
                else
                {
                    resoursesByCount.Add(line, value);
                }

                line = Console.ReadLine();
            }

            foreach (var kvp in resoursesByCount)
            {
                string key = kvp.Key;
                int value = kvp.Value;

                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
