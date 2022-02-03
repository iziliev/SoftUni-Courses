using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_Cups_and_Bottles
{
    class StartUp
    {
        static void Main()
        {
            var cupCapacity = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Reverse());

            var bottleWater = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Reverse());

            var waste = 0;

            while (bottleWater.Count > 0 && cupCapacity.Count > 0)
            {
                var currentCup = cupCapacity.Pop();
                var currentBottle = bottleWater.Dequeue();

                if (currentCup > currentBottle)
                {
                    currentCup -= currentBottle;
                    cupCapacity.Push(currentCup);
                }
                else
                {
                    waste += currentBottle - currentCup;
                }
            }

            if (bottleWater.Count>0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottleWater)}");
                Console.WriteLine($"Wasted litters of water: {waste}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupCapacity)}");
                Console.WriteLine($"Wasted litters of water: {waste}");
            }
        }
    }
}
