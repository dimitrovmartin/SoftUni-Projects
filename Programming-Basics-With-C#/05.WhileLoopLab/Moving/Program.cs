using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeVolume = width * length * height;

            int spaceTaken = 0;

            string input = Console.ReadLine();

            while (input != "Done")
            {
                spaceTaken += int.Parse(input);

                if (spaceTaken >= freeVolume)
                {
                    Console.WriteLine($"No more free space! You need {spaceTaken - freeVolume} Cubic meters more.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "Done")
            {
                Console.WriteLine($"{freeVolume - spaceTaken} Cubic meters left.");
            }
        }
    }
}