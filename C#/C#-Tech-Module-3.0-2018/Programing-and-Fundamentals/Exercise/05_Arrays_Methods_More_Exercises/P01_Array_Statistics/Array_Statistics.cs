using System;
using System.Linq;

namespace P01_Array_Statistics
{
    class Array_Statistics
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine($"Min = {array.Min()}");
            Console.WriteLine($"Max = {array.Max()}");
            Console.WriteLine($"Sum = {array.Sum()}");
            Console.WriteLine($"Average = {array.Average()}");
        }
    }
}
