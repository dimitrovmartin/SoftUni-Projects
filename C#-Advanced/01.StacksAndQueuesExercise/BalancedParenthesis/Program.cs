using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] brackets = Console.ReadLine()
                .ToCharArray();

            Stack<char> stack = new Stack<char>();

            bool areBracketsBalanced = true;

            foreach (var bracket in brackets)
            {
                if (bracket == '{' ||
                    bracket == '[' ||
                    bracket == '(')
                {
                    stack.Push(bracket);
                }
                else
                {
                    if (stack.Any())
                    {
                        char startingBracket = stack.Pop();

                        if (startingBracket == '{' && bracket == '}' ||
                            startingBracket == '[' && bracket == ']' ||
                            startingBracket == '(' && bracket == ')')
                        {
                            continue;
                        }
                        else
                        {
                            areBracketsBalanced = false;

                            break;
                        }
                    }
                    else
                    {
                        areBracketsBalanced = false;

                        break;
                    }
                }
            }

            if (areBracketsBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
