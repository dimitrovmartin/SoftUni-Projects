using System;

namespace ExamPreparations
{
    class Program
    {
        static void Main(string[] args)
        {
            int countBadGrades = int.Parse(Console.ReadLine());
            string examName = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            int counterBadGrades = 0;
            int exams = 0;
            double totalGrades = 0;

            string lastExam = string.Empty;

            while (examName != "Enough")
            {
                if (grade <= 4)
                {
                    counterBadGrades++;
                }

                if (counterBadGrades == countBadGrades)
                {
                    Console.WriteLine($"You need a break, {counterBadGrades} poor grades.");
                    break;
                }

                totalGrades += grade;
                exams++;
                lastExam = examName;

                examName = Console.ReadLine();

                if (examName == "Enough")
                {
                    break;
                }

                grade = int.Parse(Console.ReadLine());
            }

            if (examName == "Enough")
            {
                Console.WriteLine($"Average score: {totalGrades / exams:f2}");
                Console.WriteLine($"Number of problems: {exams}");
                Console.WriteLine($"Last problem: {lastExam}");
            }
        }
    }
}
