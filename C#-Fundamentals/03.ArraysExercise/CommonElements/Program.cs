using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstWords = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] secondWords = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < secondWords.Length; i++)
            {
                for (int j = 0; j < firstWords.Length; j++)
                {
                    if (secondWords[i] == firstWords[j])
                    {
                        Console.Write(secondWords[i] + " ");
                    }
                }
            }
        }
    }
}
