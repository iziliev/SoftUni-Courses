using System;
using System.Collections.Generic;

namespace _04_Matching_Brackets
{
    internal class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i]==')')
                {
                    var startIndex = stack.Pop();
                    Console.WriteLine(input.Substring(startIndex,i-startIndex+1));
                }
            }
        }
    }
}
