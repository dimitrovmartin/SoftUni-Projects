using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int termInMonths = int.Parse(Console.ReadLine());
            double yearInterest = double.Parse(Console.ReadLine());

            double sum = deposit + termInMonths * ((deposit * (yearInterest / 100)) / 12);

            Console.WriteLine(sum);
        }
    }
}
