using System;
using System.Linq;

namespace PrintNumsInReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                numbers[i] = number;
            }

            numbers = numbers.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
