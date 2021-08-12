using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                bool isSpecial = true;

                for (int index = 0; index <= 3; index++)
                {
                    int digit = int.Parse(i.ToString()[index].ToString());

                    if (digit == 0)
                    {
                        isSpecial = false;
                        break;
                    }

                    if (n % digit != 0)
                    {
                        isSpecial = false;
                    }
                }

                if (isSpecial)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
