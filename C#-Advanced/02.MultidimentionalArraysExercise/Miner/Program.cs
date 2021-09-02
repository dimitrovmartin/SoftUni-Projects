using System;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[,] field = new string[n, n];

            int minerRow = -1;
            int minerCol = -1;
            int totalCoals = 0;

            bool isGameOver = false;

            for (int row = 0; row < n; row++)
            {
                string[] fieldData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = fieldData[col];

                    if (field[row, col] == "s")
                    {
                        minerRow = row;
                        minerCol = col;
                    }

                    if (field[row, col] == "c")
                    {
                        totalCoals++;
                    }
                }
            }

            foreach (var direction in directions)
            {
                if (direction == "up")
                {
                    if (AreValidCoordinates(minerRow - 1, minerCol, field))
                    {
                        string currentPlace = field[minerRow - 1, minerCol];

                        if (currentPlace == "c")
                        {
                            totalCoals--;
                        }
                        else if (currentPlace == "e")
                        {
                            isGameOver = true;
                        }

                        field[minerRow, minerCol] = "*";

                        minerRow--;
                    }
                }
                else if (direction == "down")
                {
                    if (AreValidCoordinates(minerRow + 1, minerCol, field))
                    {
                        string currentPlace = field[minerRow + 1, minerCol];

                        if (currentPlace == "c")
                        {
                            totalCoals--;
                        }
                        else if (currentPlace == "e")
                        {
                            isGameOver = true;
                        }

                        field[minerRow, minerCol] = "*";

                        minerRow++;
                    }
                }
                else if (direction == "left")
                {
                    if (AreValidCoordinates(minerRow, minerCol - 1, field))
                    {
                        string currentPlace = field[minerRow, minerCol - 1];

                        if (currentPlace == "c")
                        {
                            totalCoals--;
                        }
                        else if (currentPlace == "e")
                        {
                            isGameOver = true;
                        }

                        field[minerRow, minerCol] = "*";

                        minerCol--;
                    }
                }
                else if (direction == "right")
                {
                    if (AreValidCoordinates(minerRow, minerCol + 1, field))
                    {
                        string currentPlace = field[minerRow, minerCol + 1];

                        if (currentPlace == "c")
                        {
                            totalCoals--;
                        }
                        else if (currentPlace == "e")
                        {
                            isGameOver = true;
                        }

                        field[minerRow, minerCol] = "*";

                        minerCol++;
                    }
                }

                if (isGameOver || totalCoals == 0)
                {
                    break;
                }
            }

            if (isGameOver)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else if (totalCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoals} coals left. ({minerRow}, {minerCol})");
            }

        }

        private static bool AreValidCoordinates(int row, int col, string[,] field)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}
