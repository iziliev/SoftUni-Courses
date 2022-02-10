using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Longest_Increasing_Subsequence
{
    class Longest_Increasing_Subsequence
    {
        static void Main()
        {
            int[] sequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            
            int[] lenght = new int[sequence.Length];
            int[] previous = new int[sequence.Length];

            int maxLenght = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                lenght[i] = 1;
                previous[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (sequence[j]<sequence[i] && lenght[j]>=lenght[i])
                    {
                        lenght[i] = 1 + lenght[j];
                        previous[i] = j;
                    }
                }
                if (lenght[i]>maxLenght)
                {
                    maxLenght = lenght[i];
                    lastIndex = i;
                }
            }
            var longesSeq = new List<int>();

            for (int i = 0; i < maxLenght; i++)
            {
                longesSeq.Add(sequence[lastIndex]);
                lastIndex = previous[lastIndex];
            }
            longesSeq.Reverse();

            Console.WriteLine($"{{{string.Join(" ",longesSeq)}}}");


        }
    }
}