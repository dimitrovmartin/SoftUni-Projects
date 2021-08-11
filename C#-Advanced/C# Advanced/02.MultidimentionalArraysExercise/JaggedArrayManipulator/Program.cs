using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] matrixData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = new double[matrixData.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = matrixData[col];
                }
            }

            ManipulateArrays(n, jaggedArray);

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                int row = int.Parse(commandData[1]);
                int col = int.Parse(commandData[2]);
                int value = int.Parse(commandData[3]);

                if (AreValidCoordinates(row, col, jaggedArray))
                {
                    if (command == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }

                line = Console.ReadLine();
            }

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool AreValidCoordinates(int row, int col, double[][] jaggedArray)
        {
            return row >= 0 && row < jaggedArray.GetLength(0) && col >= 0 && col < jaggedArray[row].Length;
        }

        private static void ManipulateArrays(int n, double[][] jaggedArray)
        {
            for (int row = 1; row < n; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row - 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row - 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row - 1].Length; col++)
                    {
                        jaggedArray[row - 1][col] /= 2;
                    }
                }
            }
        }
    }
}
