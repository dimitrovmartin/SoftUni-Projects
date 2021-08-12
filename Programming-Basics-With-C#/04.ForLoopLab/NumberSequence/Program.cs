using System;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 1; i <= numbersCount; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (min > num)
                {
                    min = num;
                }

                if (max < num)
                {
                    max = num;
                }
            }

            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
