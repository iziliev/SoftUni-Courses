using System;
using System.Linq;

namespace P02_Ladybugs
{
    class Ladybugs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] field = new int[n];

            int[] burd = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(i=>i>=0 && i<n)
                .ToArray();

            for (int i = 0; i < burd.Length; i++)
            {
                field[burd[i]] = 1;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] data = input.Split(' ');

                int index = int.Parse(data[0]);
                string command = data[1];
                int move = int.Parse(data[2]);

                if (command == "left")
                {
                    move *= -1;
                }

                if (index >= n || index < 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (field[index] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                field[index] = 0;

                var nexIndex = index;

                while (true)
                {
                    nexIndex += move;

                    if (nexIndex < 0 || nexIndex >= n)
                    {
                        break;
                    }

                    if (field[nexIndex] == 1)
                    {
                        continue;
                    }

                    field[nexIndex] = 1;
                    break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
