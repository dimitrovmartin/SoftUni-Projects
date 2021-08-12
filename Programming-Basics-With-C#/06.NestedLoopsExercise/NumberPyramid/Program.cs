using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentNum = 1;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    Console.Write($"{currentNum} ");

                    currentNum++;

                    if (currentNum > n)
                    {
                        return;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
