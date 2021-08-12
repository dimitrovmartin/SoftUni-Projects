using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            bool isBancrupt = false;

            for (int i = 1; i <= n; i++)
            {
                string site = Console.ReadLine();

                if (site == "Facebook")
                {
                    salary -= 150;
                }
                else if (site == "Instagram")
                {
                    salary -= 100;
                }
                else if (site == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");

                    isBancrupt = true;
                    break;
                }
            }

            if (isBancrupt == false)
            {
                Console.WriteLine($"{salary}");
            }
        }
    }
}
