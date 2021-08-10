using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = dimentions[0];
            int m = dimentions[1];

            int[,] matrix = new int[n, m];

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            FillMatrix(n, m, matrix);

            for (int row = 0; row < n - 2; row++)
            {
                for (int col = 0; col < m - 2; col++)
                {
                    int sum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row, col + 2] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1] +
                        matrix[row + 1, col + 2] +
                        matrix[row + 2, col] +
                        matrix[row + 2, col + 1] +
                        matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            PrintMatrix(matrix, maxRow, maxCol);
        }

        private static void PrintMatrix(int[,] matrix, int maxRow, int maxCol)
        {
            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int col = maxCol; col < maxCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(int n, int m, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
