using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    public class StartUp
    {
        public static void Main()
        {
            var tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var valueToBeKilled = int.Parse(Console.ReadLine());

            while (tasks.Count>0&&threads.Count>0)
            {
                var currentThread = threads.Peek();
                var currentTask = tasks.Peek();

                if (currentThread>=currentTask)
                {
                    if (valueToBeKilled == currentTask)
                    {
                        Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                        break;
                    }
                    else
                    {
                        threads.Dequeue();
                        tasks.Pop();
                    }
                }
                else
                {
                    if (valueToBeKilled == currentTask)
                    {
                        Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                        break ;
                    }
                    else
                    {
                        threads.Dequeue();
                    }
                }
            }
            Console.WriteLine(String.Join(" ",threads));
        }
    }
}
