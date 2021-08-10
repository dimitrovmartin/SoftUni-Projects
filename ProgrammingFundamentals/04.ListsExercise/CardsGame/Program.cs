using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isFirstWinner = false;
            bool isSecondWinner = false;

            while (true)
            {
                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    firstPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.Add(secondPlayerCards[0]);

                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }
                else if (firstPlayerCards[0] < secondPlayerCards[0])
                {
                    secondPlayerCards.Add(secondPlayerCards[0]);
                    secondPlayerCards.Add(firstPlayerCards[0]);

                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }
                else if (firstPlayerCards[0] == secondPlayerCards[0])
                {
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }

                if (firstPlayerCards.Count == 0)
                {
                    isSecondWinner = true;
                    break;
                }
                else if (secondPlayerCards.Count == 0)
                {
                    isFirstWinner = true;
                    break;
                }
            }

            if (isFirstWinner)
            {
                int sum = firstPlayerCards.Sum();

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if(isSecondWinner)
            {
                int sum = secondPlayerCards.Sum();

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
