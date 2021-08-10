using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            bool[] field = new bool[fieldSize];

            int[] bugsIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var index in bugsIndexes)
            {
                if (index >= field.Length || index < 0)
                {
                    continue;
                }
                field[index] = true;
            }

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int index = int.Parse(commandData[0]);
                string direction = commandData[1];
                int flyLength = int.Parse(commandData[2]);

                if (index < 0 || index >= field.Length || !field[index])
                {
                    line = Console.ReadLine();
                    continue;
                }

                field[index] = false;

                while (true)
                {
                    if (direction == "right")
                    {
                        index += flyLength;
                    }
                    else if (direction == "left")
                    {
                        index -= flyLength;
                    }

                    if (index >= field.Length || index < 0)
                    {
                        break;
                    }
                    else if (!field[index])
                    {
                        field[index] = true;
                        break;
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var bug in field)
            {
                if (bug)
                {
                    Console.Write("1 ");
                }
                else
                {
                    Console.Write("0 ");
                }
            }
        }
    }
}
