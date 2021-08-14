using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            FillMatrix(n, matrix);

            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int row = 0; row < n; row++)
            {
                firstDiagonalSum += matrix[row, row];
                secondDiagonalSum += matrix[row, n - row - 1];
            }

            int difference = Math.Abs(firstDiagonalSum - secondDiagonalSum);

            Console.WriteLine(difference);
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
