using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    public class Student
    {
        public Student(string firstName, string lastName, int age, string hometown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Hometown = hometown;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Hometown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] studentData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentData[0];
                string lastName = studentData[1];
                int age = int.Parse(studentData[2]);
                string hometown = studentData[3];

                bool isStudentExists = IsStudentExists(students, firstName, lastName);

                if (isStudentExists)
                {
                    Student student = students.Where(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefault();

                    student.Age = age;
                    student.Hometown = hometown;
                }
                else
                {
                    Student student = new Student(firstName, lastName, age, hometown);
                    students.Add(student);
                }

                line = Console.ReadLine();
            }

            string city = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.Hometown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        private static bool IsStudentExists(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
