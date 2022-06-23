using System;
using System.Collections.Generic;

namespace _08_Balanced_Parentheses
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .ToCharArray();

            var stack = new Stack<char>();

            var isNot = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '(' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        var bracket = stack.Pop();

                        if (bracket == '{' && input[i] == '}' || bracket == '(' && input[i] == ')' || bracket == '[' && input[i] == ']')
                        {
                            continue;
                        }
                        else
                        {
                            isNot = true;
                        }
                    }
                    else
                    {
                        isNot = true;
                    }
                }
                if (isNot)
                {
                    break;
                }
            }
            if (isNot || stack.Count>0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }

    }
}
