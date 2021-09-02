using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length % 2 == 0)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
