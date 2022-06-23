using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Pokemon_Dont_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int index = int.Parse(Console.ReadLine());

            List<int> removed = new List<int>();
            while (input.Count != 0)
            {
                if (index < 0)
                {
                    input[0] = input[input.Count - 1];
                    
                    var removeElement = input[input.Count - 1];
                    removed.Add(removeElement);
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] <= removeElement)
                        {
                            input[i] += removeElement;
                        }
                        else
                        {
                            input[i] -= removeElement;
                        }
                    }
                }

                else if (index > input.Count-1)
                {
                    input[input.Count - 1] = input[0];
                    
                    var removeElement = input[0];
                    removed.Add(removeElement);
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] <= removeElement)
                        {
                            input[i] += removeElement;
                        }
                        else
                        {
                            input[i] -= removeElement;
                        }
                    }
                }

                else
                {
                    var removeElement = input[index];
                    removed.Add(removeElement);
                    input.RemoveAt(index);

                    if (input.Count==0)
                    {
                        continue;

                    }
                    else
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] <= removeElement)
                            {
                                input[i] += removeElement;
                            }
                            else
                            {
                                input[i] -= removeElement;
                            }
                        }
                    }
                }
                
                index = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(removed.Sum());
        }
    }
}
