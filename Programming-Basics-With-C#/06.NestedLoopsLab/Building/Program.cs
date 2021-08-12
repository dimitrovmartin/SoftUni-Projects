using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int apartments = int.Parse(Console.ReadLine());

            for (int i = floors; i >= 1; i--)
            {
                for (int k = 0; k < apartments; k++)
                {
                    if (i == floors)
                    {
                        Console.Write($"L{i}{k} ");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{k} ");
                    }
                    else if (i % 2 != 0)
                    {
                        Console.Write($"A{i}{k} ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
