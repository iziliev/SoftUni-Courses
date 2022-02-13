using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    public class StartUp
    {
        public static void Main()
        {
            var lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var wearts = 0;
            var flowers = 0;
            while (lilies.Count>0&&roses.Count>0)
            {
                var currentLilie = lilies.Peek();
                var currentRose = roses.Peek();
                if (currentLilie+currentRose == 15)
                {
                    wearts++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (currentLilie+currentRose>15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    flowers += currentLilie + currentRose;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            var moreWearts = flowers / 15;
            wearts+=moreWearts;

            if (wearts>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wearts} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wearts} wreaths more!");
            }
        }
    }
}
