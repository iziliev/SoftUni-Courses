using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Maximum_and_Minimum_Element
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (input.Length==2)
                {
                    stack.Push(input[1]);
                }
                else
                {
                    switch (input[0])
                    {
                        case 2:
                            if (stack.Count>0)
                            {
                                stack.Pop();
                            }
                            break;
                        case 3:
                            if (stack.Count > 0)
                            {
                                Console.WriteLine(stack.Max());
                            }
                            break;
                        case 4:
                            if (stack.Count > 0)
                            {
                                Console.WriteLine(stack.Min());
                            }
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
