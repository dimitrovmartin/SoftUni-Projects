using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());

            bool flag = false;

            int counter = 0;

            int sum = 0;

            for (int i = x; i <= y; i++)
            {
                for (int j = x; j <= y; j++)
                {
                    counter++;

                    sum = i + j;

                    if (sum == magic)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {sum})");

                        flag = true;

                        break;
                    }
                }

                if (flag)
                {
                    break;
                }

            }

            if (!flag)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magic}");
            }
        }
    }
}

