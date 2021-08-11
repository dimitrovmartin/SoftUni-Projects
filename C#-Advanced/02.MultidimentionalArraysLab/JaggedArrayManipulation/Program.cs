using System;
using System.Linq;

namespace JaggedArrayManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            FillMatrix(n, matrix);

            string line = Console.ReadLine().ToLower();

            while (line != "end")
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                int row = int.Parse(commandData[1]);
                int col = int.Parse(commandData[2]);
                int value = int.Parse(commandData[3]);

                if (IsValidIndex(matrix, row, col))
                {
                    if (command == "add")
                    {
                        matrix[row, col] += value;
                    }
                    else if (command == "subtract")
                    {
                        matrix[row, col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                line = Console.ReadLine().ToLower();
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
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

        private static bool IsValidIndex(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
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
