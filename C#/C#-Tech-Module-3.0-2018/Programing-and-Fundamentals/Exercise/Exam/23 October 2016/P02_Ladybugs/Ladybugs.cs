using System;
using System.Linq;

namespace P02_Ladybugs
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] road = new int[n];

            int[] ladyBugs = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(i=>i>=0 && i<n)
                .ToArray();

            for (int i = 0; i < ladyBugs.Length; i++)
            {
                road[ladyBugs[i]] = 1;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] data = input
                    .Split(' ');

                int index = int.Parse(data[0]);
                string directions = data[1];
                int move = int.Parse(data[2]);

                if (directions == "right")
                {
                    int count = 0;
                    for (int i = index; i < road.Length; i++)
                    {
                        if (road[i] > 0)
                        {
                            if (i + move <= road.Length-1)
                            {
                                if (count != ladyBugs.Length)
                                {
                                    road[i] -= 1;
                                    road[i + move] += 1;
                                    count++;
                                }
                                
                            }
                            else
                            {
                                if (count != ladyBugs.Length)
                                {
                                    road[i] = 0;
                                    count++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    int count = 0;
                    for (int i = index; i >= 0; i--)
                    {
                        if (road[i] > 0)
                        {
                            if (i - move <= road.Length - 1)
                            {
                                if (count != ladyBugs.Length)
                                {
                                    road[i] -= 1;
                                    road[i - move] += 1;
                                    count++;
                                }

                            }
                            else
                            {
                                if (count != ladyBugs.Length)
                                {
                                    road[i] = 0;
                                    count++;
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",road));
        }
    }
}
