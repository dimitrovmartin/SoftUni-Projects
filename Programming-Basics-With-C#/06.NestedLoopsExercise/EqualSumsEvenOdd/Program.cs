using System;

namespace EqualSumsEvenOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                int counter = 0;
                int evenPos = 0;
                int oddPos = 0;

                string currentNum = i.ToString();

                for (int k = 0; k < currentNum.Length; k++)
                {
                    counter++;

                    if (counter % 2 != 0)
                    {
                        oddPos += int.Parse(currentNum[k].ToString());
                    }
                    else
                    {
                        evenPos += int.Parse(currentNum[k].ToString());
                    }
                }

                if (oddPos == evenPos)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
