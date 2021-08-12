using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();

            double sum = 0;

            while (operation != "NoMoreMoney")
            {
                double input = double.Parse(operation);

                if (input < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {input:f2}");

                sum += input;

                operation = Console.ReadLine();
            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
