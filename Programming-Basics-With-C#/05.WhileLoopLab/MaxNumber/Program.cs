using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int max = int.MinValue;

            while (num != "Stop")
            {
                int input = int.Parse(num);

                if (max < input)
                {
                    max = input;
                }

                num = Console.ReadLine();
            }

            Console.WriteLine(max);
        }
    }
}
