using System;
using System.Linq;

namespace SumMatrixColumns
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

            for (int col = 0; col < m; col++)
            {
                int sum = 0;

                for (int row = 0; row < n; row++)
                {
                        sum += matrix[row,col];
                }

                Console.WriteLine(sum);
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
