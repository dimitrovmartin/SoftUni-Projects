using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberToDivide = int.Parse(Console.ReadLine());

            numbers = numbers
                .Where(n => n % numberToDivide != 0)
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
