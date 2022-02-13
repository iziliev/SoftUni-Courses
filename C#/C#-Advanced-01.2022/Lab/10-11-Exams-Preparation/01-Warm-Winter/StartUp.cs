using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Warm_Winter
{
    public class StartUp
    {
        public static void Main()
        {
            var hats = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var scarfs = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var setsPrice = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                var currentHat = hats.Peek();
                var currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    setsPrice.Add(currentHat + currentScarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentScarf > currentHat)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {setsPrice.Max()}");
            Console.WriteLine(String.Join(" ", setsPrice));

        }
    }
}
