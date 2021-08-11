using System;
using System.Linq;

namespace CountUpperCaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
