using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int min = int.MaxValue;

            while (num != "Stop")
            {
                int input = int.Parse(num);

                if (min > input)
                {
                    min = input;
                }

                num = Console.ReadLine();
            }

            Console.WriteLine(min);
        }
    }
}
