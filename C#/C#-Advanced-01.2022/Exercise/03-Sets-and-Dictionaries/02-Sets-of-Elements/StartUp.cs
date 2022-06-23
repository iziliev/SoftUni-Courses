using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Sets_of_Elements
{
    class StartUp
    {
        static void Main()
        {
            var array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < array[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < array[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            var uniqueSet = new HashSet<int>();

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    uniqueSet.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueSet));
        }
    }
}
