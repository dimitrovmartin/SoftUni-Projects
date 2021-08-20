using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine($"Sir {n}");

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
