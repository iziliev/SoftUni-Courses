using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Simple_Text_Editor
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var text = string.Empty;

            var stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "1")
                {
                    stack.Push(text);
                    text = $"{text}{input[1]}";
                }
                else if (input[0] == "2")
                {
                    stack.Push(text);
                    text = text.Substring(0, text.Length - int.Parse(input[1]));
                }
                else if (input[0] == "3")
                {
                    Console.WriteLine(text[int.Parse(input[1]) - 1]);
                }
                else if (input[0] == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}
