using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Basic_Stack_Operations
{
    class StartUp
    {
        static void Main()
        {
            var n = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var inputNum = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < n[0]; i++)
            {
                stack.Push(inputNum[i]);
            }

            for (int i = 0; i < n[1]; i++)
            {
                if (stack.Count>0)
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }

            if (stack.Contains(n[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}