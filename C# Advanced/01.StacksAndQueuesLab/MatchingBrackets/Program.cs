using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string problem = Console.ReadLine();

            Stack<int> bracketsIndexes = new Stack<int>();

            for (int i = 0; i < problem.Length; i++)
            {
                if (problem[i] == '(')
                {
                    bracketsIndexes.Push(i);
                }
                else if (problem[i] == ')')
                {
                    if (bracketsIndexes.Any())
                    {
                        int startingIndex = bracketsIndexes.Pop();
                        int currentIndex = i;

                        string result = problem.Substring(startingIndex, currentIndex - startingIndex + 1);

                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}
