using System;
using System.Collections.Generic;

namespace Lisp_question
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input!");
            string input = Console.ReadLine();
            Console.WriteLine("Parentheses properly closed and nested ? = {0}", HasValidMatchingParentheses(input));
        }

        static bool HasValidMatchingParentheses(string input)
        {
            Stack<char> stack = new Stack<char>();
            char top;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        top = stack.Peek();
                        if (input[i] == ')' && top == '(' || input[i] == '}' && top == '{' || input[i] == ']' && top == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            if(stack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
