using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int factorial = 1;
                int integer = int.Parse(number[i].ToString());

                for (int j = 1; j <= integer; j++)
                {
                    factorial *= j;
                }

                sum += factorial;
            }

            int numberInt = int.Parse(number);

            if (numberInt == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
