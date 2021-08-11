using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMoves
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

            int counter = 0;

            string text = Console.ReadLine();

            char[,] matrix = new char[n, m];

            for (int row = 0; row < n; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < m; col++)
                    {
                        matrix[row, col] = text[counter];

                        if (counter == text.Length - 1)
                        {
                            counter = -1;
                        }

                        counter++;
                    }
                }
                else
                {
                    for (int col = m - 1; col >= 0; col--)
                    {
                        matrix[row, col] = text[counter];

                        if (counter == text.Length - 1)
                        {
                            counter = -1;
                        }

                        counter++;
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
