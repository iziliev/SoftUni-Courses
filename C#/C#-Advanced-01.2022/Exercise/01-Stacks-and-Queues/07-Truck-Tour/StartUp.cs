using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Truck_Tour
{
    class StartUp
    {
        static void Main()
        {
            //FIRST
            //----------------------------------------
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray());
            }

            var index = 0;

            while (true)
            {
                var tempFuel = 0;
                var isCompleed = true;
                foreach (var item in queue)
                {
                    if (tempFuel + item[0] - item[1] < 0)
                    {
                        index++;
                        queue.Enqueue(queue.Dequeue());
                        isCompleed = false;
                        break;
                    }

                    tempFuel += item[0] - item[1];

                }
                if (isCompleed)
                {
                    Console.WriteLine(index);
                    break;
                }
            }

            // SECOND
            //----------------------------------------
            //var n = int.Parse(Console.ReadLine());

            //var queue = new Queue<int[]>();
            //var list = new List<int[]>();

            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine()
            //        .Split()
            //        .Select(int.Parse)
            //        .ToArray();

            //    queue.Enqueue(input);
            //    list.Add(input);
            //}

            //var tempFuel = 0;
            //var tempIndex = 0;
            //var isCompleeted = true;

            //while (queue.Count > 0)
            //{
            //    if (tempFuel + queue.Peek()[0] - queue.Peek()[1] >= 0)
            //    {
            //        tempFuel += queue.Peek()[0] - queue.Peek()[1];
            //        queue.Dequeue();
            //    }
            //    else
            //    {
            //        tempIndex++;
            //        tempFuel = 0;
            //        queue.Clear();

            //        foreach (var item in list)
            //        {
            //            queue.Enqueue(item);
            //        }

            //        for (int i = 0; i < tempIndex; i++)
            //        {
            //            queue.Enqueue(queue.Dequeue());
            //        }
            //    }

            //    if (queue.Count==0)
            //    {
            //        isCompleeted = true;
            //        break;
            //    }
            //}

            //if (isCompleeted)
            //{
            //    Console.WriteLine($"{tempIndex}");
            //}
        }
    }
}
