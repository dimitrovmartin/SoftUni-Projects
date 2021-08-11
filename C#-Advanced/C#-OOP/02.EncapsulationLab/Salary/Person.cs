using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public decimal Salary { get; private set; }

        public void IncreaseSalary(decimal precentage)
        {
            if (Age < 30)
            {
                precentage /= 2;
            }

            Salary += Salary * (precentage / 100);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
