using System;

namespace VacantionBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagesCount = int.Parse(Console.ReadLine());
            double pagesForHour = double.Parse(Console.ReadLine());
            int countDays = int.Parse(Console.ReadLine());

            double hoursPerDay = (pagesCount / pagesForHour) / countDays;

            Console.WriteLine(hoursPerDay);
        }
    }
}
