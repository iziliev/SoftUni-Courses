using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Change_List
{
    class Change_List
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] commands = Console.ReadLine()
                .Split();

            while (commands[0] != "Odd" && commands[0] != "Even")
            {
                if (commands[0] == "Delete")
                {
                    int number = int.Parse(commands[1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (number == numbers[i])
                        {
                            numbers.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if (commands[0] == "Insert")
                {
                    int number = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);

                    numbers.Insert(index, number);
                }

                commands = Console.ReadLine()
                .Split();
            }

            if (commands[0] == "Odd")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                Console.WriteLine();
            }
            else if (commands[0] == "Even")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
