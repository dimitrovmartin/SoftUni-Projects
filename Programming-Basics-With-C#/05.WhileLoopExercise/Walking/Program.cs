using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;

            string input = Console.ReadLine();

            int countSteps = 0;

            while (input != "Going home")
            {
                int steps = int.Parse(input);

                countSteps += steps;

                if (countSteps >= goal)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{countSteps - goal} steps over the goal!");
                    return;
                }

                input = Console.ReadLine();
            }

            if (input == "Going home")
            {
                countSteps += int.Parse(Console.ReadLine());

                if (countSteps >= goal)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{countSteps - goal} steps over the goal!");
                }
                else
                {
                    Console.WriteLine($"{goal - countSteps} more steps to reach goal.");
                }
            }
        }
    }
}
