using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int leghtOfArray = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            var maxArrays = new int[leghtOfArray];

            int currentSeq = 0;
            int maxCurrentSeq = 0;
            int maxSum = 0;
            int minIndex = int.MaxValue;
            
            while (input != "Clone them!")
            {
                int[] array = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int count = 1;
                int maxCount = 0;
                int index = 0;

                if (array.Length == leghtOfArray)
                {
                    currentSeq++;

                    for (int i = 1; i < array.Length; i++)
                    {
                        if (array[i] == array[i-1])
                        {
                            count++;
                        }
                        else
                        {
                            count = 1;
                        }
                        if (maxCount < count)
                        {
                            maxCount = count;
                            index = i;
                        }
                    }

                    int sumOfporedica = 0;

                    for (int i = index-maxCount+1; i <= index; i++)
                    {
                        sumOfporedica += array[i];
                    }

                    if (maxSum < sumOfporedica)
                    {
                        maxSum = sumOfporedica;
                        maxArrays = array;
                        maxCurrentSeq = currentSeq;
                        minIndex = index - maxCount + 1;
                    }

                    else if (maxSum == sumOfporedica)
                    {
                        if (minIndex >= index - maxCount + 1)
                        {
                            maxSum = sumOfporedica;
                            maxArrays = array;
                            maxCurrentSeq = currentSeq;
                        }
                        else
                        {
                            if (maxArrays.Sum() < array.Sum())
                            {
                                maxSum = sumOfporedica;
                                maxArrays = array;
                                maxCurrentSeq = currentSeq;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {maxCurrentSeq} with sum: {maxArrays.Sum()}.");
            Console.WriteLine(String.Join(" ", maxArrays));
        }
    }
}
