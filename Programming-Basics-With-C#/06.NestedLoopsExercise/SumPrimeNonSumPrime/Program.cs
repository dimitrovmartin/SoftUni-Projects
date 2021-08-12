using System;

namespace SumPrimeNonSumPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double primeNums = 0;
            double nonPrimeNums = 0;

            int flag = 0;

            while (input != "stop")
            {
                double num = double.Parse(input);

                flag = 0;

                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0 && num >= 0)
                    {
                        nonPrimeNums += num;

                        flag = 1;

                        break;
                    }
                }

                if (flag == 0 && num >= 0)
                {
                    primeNums += num;
                }

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }

                input = Console.ReadLine();
            }

            if (input == "stop")
            {
                Console.WriteLine($"Sum of all prime numbers is: {primeNums}");
                Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNums}");
            }
        }
    }
}
