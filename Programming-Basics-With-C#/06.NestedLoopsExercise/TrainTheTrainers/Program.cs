using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judgesCount = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double sumGradesPerPresentation = 0;
            double totalGrade = 0;

            int examsCount = 0;

            while (presentationName != "Finish")
            {
                sumGradesPerPresentation = 0;

                examsCount++;

                for (int i = 1; i <= judgesCount; i++)
                {
                    double grade = double.Parse(Console.ReadLine());

                    sumGradesPerPresentation += grade;
                }

                sumGradesPerPresentation /= judgesCount;
                totalGrade += sumGradesPerPresentation;

                Console.WriteLine($"{presentationName} - {sumGradesPerPresentation:f2}.");

                presentationName = Console.ReadLine();
            }

            if (presentationName == "Finish")
            {
                Console.WriteLine($"Student's final assessment is {totalGrade / examsCount:f2}.");
            }
        }
    }
}
