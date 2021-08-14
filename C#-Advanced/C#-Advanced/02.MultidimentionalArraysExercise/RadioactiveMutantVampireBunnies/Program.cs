using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
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

            int playerRow = -1;
            int playerCol = -1;

            bool isDead = false;
            bool isEscaped = false;

            char[,] field = new char[n, m];

            FillMatrix(field, ref playerRow, ref playerCol);

            char[] directions = Console.ReadLine()
                .ToCharArray();

            foreach (var direction in directions)
            {
                field[playerRow, playerCol] = '.';

                if (direction == 'U')
                {
                    if (AreValidCoordinates(playerRow - 1, playerCol, field))
                    {
                        char currentPlace = field[playerRow - 1, playerCol];

                        if (currentPlace == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            field[playerRow - 1, playerCol] = 'P';
                        }

                        playerRow--;
                    }
                    else
                    {
                        isEscaped = true;
                    }
                }
                else if (direction == 'D')
                {
                    if (AreValidCoordinates(playerRow + 1, playerCol, field))
                    {
                        char currentPlace = field[playerRow + 1, playerCol];

                        if (currentPlace == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            field[playerRow + 1, playerCol] = 'P';
                        }

                        playerRow++;
                    }
                    else
                    {
                        isEscaped = true;
                    }
                }
                else if (direction == 'L')
                {
                    if (AreValidCoordinates(playerRow, playerCol - 1, field))
                    {
                        char currentPlace = field[playerRow, playerCol - 1];

                        if (currentPlace == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            field[playerRow, playerCol - 1] = 'P';
                        }

                        playerCol--;
                    }
                    else
                    {
                        isEscaped = true;
                    }
                }
                else if (direction == 'R')
                {
                    if (AreValidCoordinates(playerRow, playerCol + 1, field))
                    {
                        char currentPlace = field[playerRow, playerCol + 1];

                        if (currentPlace == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            field[playerRow, playerCol + 1] = 'P';
                        }

                        playerCol++;
                    }
                    else
                    {
                        isEscaped = true;
                    }
                }
                

                List<int[]> bunniesCoordinates = GetBunniesCoordinates(field);
                SpreadBunnies(field, bunniesCoordinates);

                if (field[playerRow,playerCol] == 'B' && !isEscaped)
                {
                    isDead = true;
                }

                if (isEscaped || isDead)
                {
                    break;
                }
            }

            PrintMatrix(field);

            if (isEscaped)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");

            }
            else if(isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row,col]}");
                }

                Console.WriteLine();
            }
        }

        private static void SpreadBunnies(char[,] field, List<int[]> bunniesCoordinates)
        {
            foreach (var bunnyCoordinates in bunniesCoordinates)
            {
                int bunnyRow = bunnyCoordinates[0];
                int bunnyCol = bunnyCoordinates[1];

                if (AreValidCoordinates(bunnyRow - 1, bunnyCol, field))
                {
                    field[bunnyRow - 1, bunnyCol] = 'B';
                }

                if (AreValidCoordinates(bunnyRow + 1, bunnyCol, field))
                {
                    field[bunnyRow + 1, bunnyCol] = 'B';
                }
                
                if (AreValidCoordinates(bunnyRow, bunnyCol - 1, field))
                {
                    field[bunnyRow, bunnyCol - 1] = 'B';
                }
                
                if (AreValidCoordinates(bunnyRow, bunnyCol + 1, field))
                {
                    field[bunnyRow , bunnyCol + 1] = 'B';
                }
            }
        }

        private static List<int[]> GetBunniesCoordinates(char[,] field)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row,col] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] { row, col });
                    }
                }
            }

            return bunniesCoordinates;
        }

        private static bool AreValidCoordinates(int row, int col, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }

        private static void FillMatrix(char[,] field, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] fieldData = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = fieldData[col];

                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
