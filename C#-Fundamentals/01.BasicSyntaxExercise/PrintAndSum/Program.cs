using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingIndex = int.Parse(Console.ReadLine());
            int lastIndex = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = startingIndex; i < lastIndex + 1; i++)
            {
                sum += i;

                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
