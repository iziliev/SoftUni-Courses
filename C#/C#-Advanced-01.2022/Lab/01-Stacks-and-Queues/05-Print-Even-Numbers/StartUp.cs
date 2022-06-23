using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Print_Even_Numbers
{
    internal class StartUp
    {
        static void Main()
        {
            var queue = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var newQueue = new Queue<int>();

            while (queue.Count>0)
            {
                if (queue.Peek()%2==0)
                {
                    newQueue.Enqueue(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
            }

            Console.WriteLine(String.Join(", ",newQueue));
        }
    }
}
