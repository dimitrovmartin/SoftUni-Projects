using System;

namespace Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int k = 1;

            while (k <= number)
            {
                Console.WriteLine(k);

                k = k * 2 + 1;
            }
        }
    }
}