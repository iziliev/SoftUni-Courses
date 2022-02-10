using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Pokemon_Dont_Go
{
    class Pokemon_Dont_Go
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> removeNums = new List<int>();

            while (numbers.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int num = 0;

                if (index < 0)
                {
                    num = numbers[0];
                    numbers[0] = numbers[numbers.Count - 1];

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= num)
                        {
                            numbers[i] += num;
                        }
                        else
                        {
                            numbers[i] -= num;
                        }
                    }
                    removeNums.Add(num);
                }
                else if (index > numbers.Count - 1)
                {
                    num = numbers[numbers.Count - 1];
                    numbers[numbers.Count - 1] = numbers[0];

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= num)
                        {
                            numbers[i] += num;
                        }
                        else
                        {
                            numbers[i] -= num;
                        }
                    }
                    removeNums.Add(num);
                }
                else
                {
                    num = numbers[index];

                    removeNums.Add(num);

                    numbers.RemoveAt(index);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= num)
                        {
                            numbers[i] += num;
                        }
                        else
                        {
                            numbers[i] -= num;
                        }
                    }
                }
            }
            Console.WriteLine(removeNums.Sum());
        }       
    }
}