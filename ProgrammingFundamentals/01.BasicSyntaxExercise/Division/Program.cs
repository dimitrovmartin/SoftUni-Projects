using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int maxDivideNum = 0;

            if (number % 10 == 0)
            {
                maxDivideNum = 10;
            }
            else if (number % 7 == 0)
            {
                maxDivideNum = 7;
            }
            else if (number % 6 == 0)
            {
                maxDivideNum = 6;
            }
            else if (number % 3 == 0)
            {
                maxDivideNum = 3;
            }
            else if (number % 2 == 0)
            {
                maxDivideNum = 2;
            }

            if (maxDivideNum != 0)
            {
                Console.WriteLine($"The number is divisible by {maxDivideNum}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
