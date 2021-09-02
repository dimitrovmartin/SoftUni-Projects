using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] pascal = new long[n][];

            for (int row = 0; row < n; row++)
            {
                pascal[row] = new long[row + 1];

                for (int col = 0; col < pascal[row].Length; col++)
                {
                    long sum = 0;

                    if (IsValidIndex(row - 1, col, pascal))
                    {
                        sum += pascal[row - 1][col];
                    }

                    if (IsValidIndex(row- 1, col - 1, pascal))
                    {
                        sum += pascal[row - 1][col - 1];
                    }

                    if (sum == 0)
                    {
                        sum = 1;
                    }

                    pascal[row][col] = sum;
                }
            }

            for (int row = 0; row < pascal.GetLength(0); row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write($"{pascal[row][col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidIndex(int row, int col, long[][] pascal)
        {
            return row >= 0 && row < pascal.GetLength(0) && col >= 0 && col < pascal[row].Length;
        }
    }
}
