using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int sum = 0;
            int count = 0;

            FillMatrix(n, matrix);

            string[] bombsData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var bomb in bombsData)
            {
                int[] coordinates = bomb
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (matrix[row, col] > 0)
                {
                    if (IsValid(row - 1, col - 1, matrix))
                    {
                        matrix[row - 1, col - 1] -= matrix[row, col];
                    }

                    if (IsValid(row - 1, col, matrix))
                    {
                        matrix[row - 1, col] -= matrix[row, col];
                    }

                    if (IsValid(row - 1, col + 1, matrix))
                    {
                        matrix[row - 1, col + 1] -= matrix[row, col];
                    }

                    if (IsValid(row, col - 1, matrix))
                    {
                        matrix[row, col - 1] -= matrix[row, col];
                    }

                    if (IsValid(row, col + 1, matrix))
                    {
                        matrix[row, col + 1] -= matrix[row, col];
                    }

                    if (IsValid(row + 1, col - 1, matrix))
                    {
                        matrix[row + 1, col - 1] -= matrix[row, col];
                    }

                    if (IsValid(row + 1, col, matrix))
                    {
                        matrix[row + 1, col] -= matrix[row, col];
                    }

                    if (IsValid(row + 1, col + 1, matrix))
                    {
                        matrix[row + 1, col + 1] -= matrix[row, col];
                    }

                    matrix[row, col] = 0;
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        count++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValid(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1)
                && matrix[row, col] > 0;
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
