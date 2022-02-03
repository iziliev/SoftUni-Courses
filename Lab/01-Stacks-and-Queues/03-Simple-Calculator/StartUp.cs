using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Simple_Calculator
{
    internal class StartUp
    {
        static void Main()
        {
            var expressions = new Stack<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse());

            while (expressions.Count > 1)
            {
                var firstNum = int.Parse(expressions.Pop());
                var operators = expressions.Pop();
                var secondNum = int.Parse(expressions.Pop());

                if (operators == "+")
                {
                    var sum = firstNum + secondNum;

                    expressions.Push(sum.ToString());
                }
                else
                {
                    var sum = firstNum - secondNum;

                    expressions.Push(sum.ToString());
                }
            }

            Console.WriteLine(expressions.Peek());
        }
    }
}
