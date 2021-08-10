using System;

namespace MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int startingIndex = int.Parse(Console.ReadLine());

            for (int i = startingIndex; i <= 10; i++)
            {
                Console.WriteLine($"{n} X {i} = {n * i}");
            }

            if (startingIndex > 10)
            {
                Console.WriteLine($"{n} X {startingIndex} = {n * startingIndex}");
            }
        }
    }
}
