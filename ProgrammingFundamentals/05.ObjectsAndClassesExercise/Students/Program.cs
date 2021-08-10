using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Student
    {
        public Student(string firstName,string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentData[0];
                string lastName = studentData[1];
                double grade = double.Parse(studentData[2]);

                Student student = new Student(firstName, lastName, grade);

                students.Add(student);
            }

            students = students.OrderByDescending(s => s.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
