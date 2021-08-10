using System;
using System.Linq;

namespace SquaresInMatrix
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

            string[,] matrix = new string[n, m];

            FillMatrix(n, m, matrix);

            int squaresCount = GetSquaresCount(n, m, matrix);

            Console.WriteLine(squaresCount);
        }

        private static int GetSquaresCount(int n, int m, string[,] matrix)
        {
            int squaresCount = 0;

            for (int row = 0; row < n - 1; row++)
            {
                for (int col = 0; col < m - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row + 1, col] == matrix[row, col] &&
                        matrix[row + 1, col + 1] == matrix[row, col])
                    {
                        squaresCount++;
                    }
                }
            }

            return squaresCount;
        }

        private static void FillMatrix(int n, int m, string[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                string[] matrixData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }
        }
    }
}
