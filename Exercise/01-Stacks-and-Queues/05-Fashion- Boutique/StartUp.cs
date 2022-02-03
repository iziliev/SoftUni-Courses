using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Fashion__Boutique
{
    class StartUp
    {
        static void Main()
        {
            var stack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var rack = int.Parse(Console.ReadLine());

            var currentRack = rack;
            var countBox = 0;

            while (stack.Count>0)
            {
                if (currentRack - stack.Peek() > 0)
                {
                    if (stack.Count==1)
                    {
                        countBox++;
                    }
                    currentRack -= stack.Pop();
                }
                else if (currentRack - stack.Peek() == 0)
                {
                    countBox++;
                    currentRack = rack;
                    stack.Pop();
                }
                else
                {
                    currentRack = rack;
                    countBox++;
                }
            }
            Console.WriteLine(countBox);
        }
    }
}
