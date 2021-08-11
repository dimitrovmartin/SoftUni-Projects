namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            List<char> brackets = new List<char>(parentheses);

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < brackets.Count; i++)
            {
                char currentBracket = brackets[i];

                if (currentBracket == '[' || currentBracket == '(' || currentBracket == '{')
                {
                    stack.Push(currentBracket);
                }
                else
                {
                    if (stack.Any())
                    {
                        char startingBracket = stack.Pop();

                        if ((startingBracket == '(' && currentBracket == ')') ||
                            (startingBracket == '[' && currentBracket == ']') ||
                            (startingBracket == '{' && currentBracket == '}'))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
