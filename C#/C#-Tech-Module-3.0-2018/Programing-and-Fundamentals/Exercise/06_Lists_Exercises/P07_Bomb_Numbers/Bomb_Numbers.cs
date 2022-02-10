using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Bomb_Numbers
{
    class Bomb_Numbers
    {
        static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] bomb = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bomb[0];
            int detronation = bomb[1];

            for (int i = 0; i < input.Count; i++)
            {
                if (bombNumber == input[i])
                {
                    int maxIndex = 0;
                    int minIndex = 0;

                    if (i + detronation >= input.Count - 1)
                    {
                        maxIndex = input.Count - 1;
                    }
                    else
                    {
                        maxIndex = detronation + i;
                    }
                    if (i - detronation <= 0)
                    {
                        minIndex = 0;
                    }
                    else
                    {
                        minIndex = i - detronation;
                    }
                    input.RemoveRange(minIndex, maxIndex-minIndex+1);
                    i--;
                }
            }
            Console.WriteLine(input.Sum());
        }
    }
}
