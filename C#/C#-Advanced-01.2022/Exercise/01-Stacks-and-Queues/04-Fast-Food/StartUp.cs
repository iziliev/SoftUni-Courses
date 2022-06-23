using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Fast_Food
{
    class StartUp
    {
        static void Main()
        {
            var quantityFood = int.Parse(Console.ReadLine());

            var queue = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var maxOrder = queue.Max();

            while (queue.Count > 0 && quantityFood - queue.Peek()>=0)
            {
                quantityFood -= queue.Dequeue();
            }

            Console.WriteLine(maxOrder);

            if (queue.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
            }
        }
    }
}
