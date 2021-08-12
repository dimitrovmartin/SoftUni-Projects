using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projectsCount = int.Parse(Console.ReadLine());

            int oneProjectTimeNeed = 3;
            int totalTime = projectsCount * oneProjectTimeNeed;

            Console.WriteLine($"The architect {name} will need {totalTime} hours to complete {projectsCount} project/s.");
        }
    }
}
