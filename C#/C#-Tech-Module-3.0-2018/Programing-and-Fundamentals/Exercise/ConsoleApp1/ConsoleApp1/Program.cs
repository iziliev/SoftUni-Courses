using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int maxCount = -1;
            int minIndex = int.MaxValue;
            int[] array = new int[n];
            int countRow = 0;
            int maxCountRow = -1;

            while (input != "Clone them!")
            {
                int[] data = input.Split(new char[] {'!'},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                countRow++;

                if (data.Length == n)
                {
                    int countOnes = 0;
                    int index = -1;
                    int maxCurrentCount = -1;
                    int minCurrentIndex = -1;

                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i] == 1)
                        {
                            countOnes++;
                            if (countOnes >= maxCurrentCount)
                            {
                                maxCurrentCount = countOnes;
                                index = i;
                            }
                        }
                        else
                        {
                            countOnes = 0;
                        }
                    }

                    minCurrentIndex = index - maxCurrentCount + 1;

                    if (maxCurrentCount >= maxCount)
                    {
                        if (minIndex > minCurrentIndex)
                        {
                            maxCount = maxCurrentCount;
                            array = data;
                            minIndex = minCurrentIndex;
                            maxCountRow = countRow;
                        }
                        else if (minIndex == minCurrentIndex)
                        {
                            if (array.Sum() < data.Sum())
                            {
                                array = data;
                                minIndex = minCurrentIndex;
                                maxCountRow = countRow;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            if (array.Sum() > 0)
            {
                Console.WriteLine($"Best DNA sample {maxCountRow} with sum: {array.Sum()}.");
                Console.WriteLine(string.Join(" ", array));
            }
            else if (maxCount>0)
            {
                Console.WriteLine($"Best DNA sample 1 with sum: 0.");
            }
            else
            {
                Console.WriteLine($"Best DNA sample 0 with sum: 0.");
            }
        }
    }
}
