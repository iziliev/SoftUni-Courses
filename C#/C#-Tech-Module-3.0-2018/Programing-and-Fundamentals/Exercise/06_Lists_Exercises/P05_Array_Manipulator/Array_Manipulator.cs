using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Array_Manipulator
{
    class Array_Manipulator
    {
        static void Main()
        {
            long[] input = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();

            List<long> result = input.ToList();

            string[] commands = Console.ReadLine()
                .Split(' ');

            while (commands[0] != "print")
            {
                string command = commands[0];
                if (command == "add")
                {
                    int index = int.Parse(commands[1]);
                    long numbers = long.Parse(commands[2]);
                    if (index<0)
                    {
                        index = 0;

                    }
                    else if(index > result.Count)
                    {
                        index = result.Count;
                    }
                    result.Insert(index, numbers);
                }
                else if (command == "addMany")
                {
                    int index = int.Parse(commands[1]);

                    if (index < 0)
                    {
                        index = 0;

                    }
                    else if (index > result.Count)
                    {
                        index = result.Count;
                    }

                    for (int i = 2; i < commands.Length; i++)
                    {
                        long number = long.Parse(commands[i]);

                        result.Insert(index, number);
                        index++;
                    }
                }
                else if (command == "contains")
                {
                    long numbers = long.Parse(commands[1]);

                    Console.WriteLine(result.IndexOf(numbers));
                }
                else if (command == "remove")
                {
                    int index = int.Parse(commands[1]);

                    result.RemoveAt(index);
                }
                else if (command == "shift")
                {
                    long rotations = long.Parse(commands[1]);
                    
                    for (int i = 0; i < rotations; i++)
                    {
                        long temp = result[0];
                        for (int j = 0; j < result.Count - 1; j++)
                        {
                            result[j] = result[j + 1];
                        }
                        result[result.Count - 1] = temp;
                    }
                }
                else if (command == "sumPairs")
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (i + 1 >= result.Count)
                        {
                            break;
                        }
                        var sum = (result[i] + result[i + 1]);
                        result.RemoveRange(i, 2);
                        result.Insert(i, sum);
                    }
                }
                commands = Console.ReadLine()
                .Split(' ');
            }
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}
