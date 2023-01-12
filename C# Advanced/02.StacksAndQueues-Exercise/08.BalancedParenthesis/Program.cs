namespace _08.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            string parenthesis = Console.ReadLine();

            var stack = new Stack<char>();

            bool isBalanced = true;

            if (parenthesis.Length % 2 == 0)
            {
                for (int i = 0; i < parenthesis.Length; i++)
                {
                    char currentPar = parenthesis[i];

                    if (currentPar == '{' || currentPar == '[' || currentPar == '(')
                    {
                        stack.Push(currentPar);
                    }
                    else if (currentPar == '}' || currentPar == ']' || currentPar == ')')
                    {
                        char lastPar = stack.Peek();
                        if (stack.Any() && currentPar == '}' && lastPar == '{')
                        {
                            stack.Pop();
                        }
                        else if (stack.Any() && currentPar == ']' && lastPar == '[')
                        {
                            stack.Pop();
                        }
                        else if (stack.Any() && currentPar == ')' && lastPar == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                isBalanced = false;

            }
            if (isBalanced)
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