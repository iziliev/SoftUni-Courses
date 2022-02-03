using System;
using System.Collections.Generic;

namespace _06_Supermarket
{
    internal class StartUp
    {
        static void Main()
        {
            var queue = new Queue<string>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (queue.Count>0)
                    {
                        Console.WriteLine($"{queue.Dequeue()}");
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
