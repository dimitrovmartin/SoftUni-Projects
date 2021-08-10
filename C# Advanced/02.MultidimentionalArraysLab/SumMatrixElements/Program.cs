using System;
using System.Linq;

namespace SumMatrixElements
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

            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = matrixData[col];

                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(m);
            Console.WriteLine(sum);
        }
    }
}
