using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = dimentions[0];
            int m = dimentions[1];

            int[,] matrix = new int[n, m];

            FillMatrix(n, m, matrix);

            int bestRow = 0;
            int bestCol = 0;
            int biggestSum = 0;

            FindsTheMaximumSum(n, m, matrix, ref bestRow, ref bestCol, ref biggestSum);
            PrintSquareWithMaximumSum(matrix, bestRow, bestCol);

            Console.WriteLine(biggestSum);
        }

        private static void PrintSquareWithMaximumSum(int[,] matrix, int bestRow, int bestCol)
        {
            for (int row = bestRow; row < bestRow + 2; row++)
            {
                for (int col = bestCol; col < bestCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FindsTheMaximumSum(int n, int m, int[,] matrix, ref int bestRow, ref int bestCol, ref int biggestSum)
        {
            for (int row = 0; row < n - 1; row++)
            {
                int sum = 0;

                for (int col = 0; col < m - 1; col++)
                {
                    sum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1];

                    if (sum > biggestSum)
                    {
                        bestRow = row;
                        bestCol = col;
                        biggestSum = sum;
                    }
                }
            }
        }

        private static void FillMatrix(int n, int m, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }
        }
    }
}
