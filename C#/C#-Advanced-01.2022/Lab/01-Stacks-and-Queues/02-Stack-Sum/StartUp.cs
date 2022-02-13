using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Stack_Sum
{
    internal class StartUp
    {
        static void Main()
        {
            var stack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                var commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "add")
                {
                    for (int i = 1; i < commands.Length; i++)
                    {
                        stack.Push(int.Parse(commands[i]));
                    }
                }
                else if (commands[0] == "remove")
                {
                    if (stack.Count>int.Parse(commands[1]))
                    {
                        for (int i = 0; i < int.Parse(commands[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
