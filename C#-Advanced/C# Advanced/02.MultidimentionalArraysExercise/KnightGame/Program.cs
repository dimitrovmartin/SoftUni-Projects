using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int killerRow = -1;
            int killerCol = -1;

            int removedKnights = 0;

            bool areKillersGone = false;

            char[,] chessboard = new char[n, n];

            FillMatrix(n, chessboard);

            while (!areKillersGone)
            {
                int mostKills = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        int kills = 0;

                        if (chessboard[row,col] == 'K')
                        {
                            if (IsKnight(row - 2, col - 1, chessboard))
                            {
                                kills++;
                            }
                            
                            if (IsKnight(row - 2, col + 1, chessboard))
                            {
                                kills++;
                            }
                            
                            if (IsKnight(row - 1, col - 2, chessboard))
                            {
                                kills++;
                            }
                            
                            if (IsKnight(row - 1, col + 2, chessboard))
                            {
                                kills++;
                            }
                            
                            if (IsKnight(row + 1, col - 2, chessboard))
                            {
                                kills++;
                            }
                            
                            if (IsKnight(row + 1, col + 2, chessboard))
                            {
                                kills++;
                            }
                            
                            if (IsKnight(row + 2, col - 1, chessboard))
                            {
                                kills++;
                            }
                           
                            if (IsKnight(row + 2, col + 1, chessboard))
                            {
                                kills++;
                            }

                            if (kills > mostKills)
                            {
                                mostKills = kills;
                                killerRow = row;
                                killerCol = col;
                            }
                        }
                    }
                }

                if (mostKills > 0)
                {
                    chessboard[killerRow, killerCol] = '0';
                    removedKnights++;
                }
                else
                {
                    areKillersGone = true;
                }
            }

            Console.WriteLine(removedKnights);
        }

        private static bool IsKnight(int row, int col, char[,] chessboard)
        {
            return row >= 0 && row < chessboard.GetLength(0) && col >= 0 && col < chessboard.GetLength(1) && chessboard[row, col] == 'K';
        }

        private static void FillMatrix(int n, char[,] chessboard)
        {
            for (int row = 0; row < n; row++)
            {
                char[] chessboardData = Console.ReadLine()
                     .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    chessboard[row, col] = chessboardData[col];
                }
            }
        }
    }
}
