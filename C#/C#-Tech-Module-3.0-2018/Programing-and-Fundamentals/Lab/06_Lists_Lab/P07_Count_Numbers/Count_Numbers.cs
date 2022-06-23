using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Count_Numbers
{
    class Count_Numbers
    {
        static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] array = new int[1001];

            for (int i = 0; i < input.Count; i++)
            {
                array[input[i]]++;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]>0)
                {
                    Console.WriteLine($"{i} -> {array[i]}");
                }
            }
        }
    }
}
