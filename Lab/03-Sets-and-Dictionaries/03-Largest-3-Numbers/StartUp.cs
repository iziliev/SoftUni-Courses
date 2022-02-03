using System;
using System.Linq;

namespace _03_Largest_3_Numbers
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                
            var sortedNumbers = input
                .OrderByDescending(x => x)
                .Take(3)
                .ToArray();

            Console.WriteLine(string.Join(" ",sortedNumbers));

        }
    }
}
