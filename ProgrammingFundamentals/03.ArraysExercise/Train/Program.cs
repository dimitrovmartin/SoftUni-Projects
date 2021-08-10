using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = int.Parse(Console.ReadLine());

                numbers[i] = number;
            }

            int sum = numbers.Sum();

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(sum);
        }
    }
}
