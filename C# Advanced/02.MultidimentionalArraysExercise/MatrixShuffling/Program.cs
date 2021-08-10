using System;
using System.Linq;

namespace MatrixShuffling
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

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                if (commandData.Length == 5 && command == "swap")
                {
                    int firstRow = int.Parse(commandData[1]);
                    int firstCol = int.Parse(commandData[2]);
                    int secondRow = int.Parse(commandData[3]);
                    int secondCol = int.Parse(commandData[4]);

                    if (IsValid(firstRow, firstCol, matrix) && IsValid(secondRow, secondCol, matrix))
                    {
                        string temp = matrix[firstRow, firstCol];

                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = temp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                }

                line = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValid(int row, int col, string[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
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
