using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Max_Sequence_of_Equal_Elements
{
    class Max_Sequence_of_Equal_Elements
    {
        static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> output = new List<int>();

            int count = 1;
            int maxIndex = 0;
            int maxCount = 0;

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] == input[i-1])
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxIndex = i;
                    }
                }
                else
                {
                    count = 1;
                }
            }
            if (maxIndex == 0)
            {
                Console.WriteLine(input[0]);
            }
            else
            {
                for (int i = maxIndex - maxCount + 1; i <= maxIndex; i++)
                {
                    output.Add(input[i]);
                }
                Console.WriteLine(String.Join(" ", output));
            }
        }
    }
}