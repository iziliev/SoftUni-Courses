using System;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        public static void Main()
        {
            var box = new Box<int>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }

            var swapIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.Swap(swapIndexes[0], swapIndexes[1]);

            Console.WriteLine(box);
        }
    }
}
