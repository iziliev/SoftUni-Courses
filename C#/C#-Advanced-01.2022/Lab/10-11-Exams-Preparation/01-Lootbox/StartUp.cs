using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    public class StartUp
    {
        public static void Main()
        {
            var firstBox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var secondBox = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var claimedItems = new List<int>();

            while (firstBox.Count>0&&secondBox.Count>0)
            {
                var currentFirst = firstBox.Peek();
                var currentSecond = secondBox.Peek();

                if ((currentFirst+currentSecond)%2==0)
                {
                    claimedItems.Add(currentFirst+currentSecond);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            if (firstBox.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count==0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            var sum = claimedItems.Sum();
            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
