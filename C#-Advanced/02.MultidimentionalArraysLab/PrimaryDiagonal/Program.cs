using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            FillMatrix(n, matrix);

            int sum = GetSum(n, matrix);

            Console.WriteLine(sum);
        }

        private static int GetSum(int n, int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                sum += matrix[row, row];
            }

            return sum;
        }

        private static void FillMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }
        }
    }
}
