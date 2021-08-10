using System;

namespace EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Math.Abs(int.Parse(Console.ReadLine()));

            while (n % 2 != 0)
            {
                Console.WriteLine($"Please write an even number.");

                n = Math.Abs(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine($"The number is: {n}");
        }
    }
}
