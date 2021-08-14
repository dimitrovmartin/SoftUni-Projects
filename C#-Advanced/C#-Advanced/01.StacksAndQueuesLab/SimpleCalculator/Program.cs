using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] problem = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(problem.Reverse());

            while (stack.Count != 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                int result = GetResult(firstNumber, sign, secondNumber);

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }

        private static int GetResult(int firstNumber, string sign, int secondNumber)
        {
            if (sign == "+")
            {
                return firstNumber + secondNumber;
            }
            else
            {
                return firstNumber - secondNumber;
            }
        }
    }
}
