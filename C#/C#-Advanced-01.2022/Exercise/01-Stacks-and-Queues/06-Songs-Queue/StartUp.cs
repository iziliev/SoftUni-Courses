using System;
using System.Collections.Generic;

namespace _06_Songs_Queue
{
    class StartUp
    {
        static void Main()
        {
            var queue = new Queue<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)); ;

            var input = string.Empty;

            while ((input = Console.ReadLine())!="")
            {
                if (queue.Count==0)
                {
                    break;
                }

                if (input.Contains("Add"))
                {
                    var song = input.Substring(4, input.Length - 5+1);

                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if (input == "Play")
                {
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
