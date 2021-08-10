using System;
using System.Linq;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            FillMatrix(n, matrix);

            char symbol = char.Parse(Console.ReadLine());
            bool isSymbolFound = FindSymbol(n, matrix, symbol);

            if (!isSymbolFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }

        private static bool FindSymbol(int n, char[,] matrix, char symbol)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");

                        return true;
                    }
                }
            }

            return false;
        }

        private static void FillMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                char[] matrixData = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }
        }
    }
}
