using System;
using System.Collections.Generic;

namespace _07_Hot_Potato
{
    internal class StartUp
    {
        static void Main()
        {
            var queue = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            var turns = int.Parse(Console.ReadLine());

            var count = 1;

            while (queue.Count > 1)
            {
                if (count == turns)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                    count = 1;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                    count++;
                }
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
