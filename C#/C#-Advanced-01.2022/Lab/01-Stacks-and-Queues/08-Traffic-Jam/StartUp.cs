using System;
using System.Collections.Generic;

namespace _08_Traffic_Jam
{
    internal class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            var input = string.Empty;
            var count = 0;

            while ((input = Console.ReadLine())!="end")
            {
                if (input=="green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count>0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
