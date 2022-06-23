using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Basic_Queue_Operations
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

            var queue = new Queue<int>();

            for (int i = 0; i < n[0]; i++)
            {
                queue.Enqueue(inputNum[i]);
            }

            for (int i = 0; i < n[1]; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Contains(n[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
