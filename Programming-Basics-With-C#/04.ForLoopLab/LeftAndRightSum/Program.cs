using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 1; i <= n1; i++)
            {
                int number1 = int.Parse(Console.ReadLine());

                sum1 += number1;
            }

            for (int i = 1; i <= n1; i++)
            {
                int number2 = int.Parse(Console.ReadLine());

                sum2 += number2;
            }

            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                int diff = Math.Abs(sum1 - sum2);
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}