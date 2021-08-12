using System;

namespace GraduationPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double finalGrade = 0;
            double classes = 1;

            while (classes <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                finalGrade += grade;

                if (grade >= 4)
                {
                    classes++;
                }

                if (grade == 2)
                {
                    Console.WriteLine($"{name} has been excluded at {classes} grade");
                    break;
                }
            }

            if (classes > 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {finalGrade / 12:f2}");
            }
        }
    }
}
