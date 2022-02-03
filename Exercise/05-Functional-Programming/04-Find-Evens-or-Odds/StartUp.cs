using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Find_Evens_or_Odds
{
    public class StartUp
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> IsEven = x => x % 2 == 0;
            Predicate<int> IsOdd = x => x % 2 != 0;

            Action<List<int>, Predicate<int>> printEven
                = (numbers, IsEven)
                => Console.WriteLine(String.Join(" ", numbers.Where(x => IsEven(x))));
            Action<List<int>, Predicate<int>> printOdd
                = (numbers, IsOdd)
                => Console.WriteLine(String.Join(" ", numbers.Where(x => IsOdd(x))));

            var command = Console.ReadLine();

            if (command == "odd")
            {
                printOdd(numbers, IsOdd);
            }
            else
            {
                printEven(numbers, IsEven);
            }
        }
    }
}
