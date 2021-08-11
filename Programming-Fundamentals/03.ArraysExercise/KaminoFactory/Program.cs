using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());

            int maxDnaLength = 0;
            int startingIndex = 0;
            int bestStartingIndex = 0;
            int bestSum = 0;
            int bestSample = 0;
            int sample = 1;
            int[] bestDna = new int[dnaLength];

            string line = Console.ReadLine();

            while (line != "Clone them!")
            {
                int[] dna = line
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int sum = dna.Sum();


                for (int i = 0; i < dnaLength; i++)
                {
                    int count = 1;

                    int currentDna = dna[i];

                    for (int j = i + 1; j < dnaLength; j++)
                    {
                        int nextDna = dna[j];

                        if (currentDna == nextDna && count == 1)
                        {
                            startingIndex = i;
                        }
                        if (currentDna == nextDna)
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (count > maxDnaLength)
                    {
                        maxDnaLength = count;
                        bestStartingIndex = startingIndex;
                        bestSum = sum;
                        bestSample = sample;
                        bestDna = dna;
                    }
                    else if (count == maxDnaLength)
                    {
                        if (startingIndex < bestStartingIndex)
                        {
                            maxDnaLength = count;
                            bestStartingIndex = startingIndex;
                            bestSum = sum;
                            bestSample = sample;
                            bestDna = dna;
                        }
                        else if (startingIndex == bestStartingIndex)
                        {
                           if (sum > bestSum)
                            {
                                maxDnaLength = count;
                                bestStartingIndex = startingIndex;
                                bestSum = sum;
                                bestSample = sample;
                                bestDna = dna;
                            }
                        }
                    }
                }

                sample++;
                line = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}
