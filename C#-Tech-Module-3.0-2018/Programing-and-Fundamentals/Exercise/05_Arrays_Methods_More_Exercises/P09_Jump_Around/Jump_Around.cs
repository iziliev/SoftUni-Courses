using System;
using System.Linq;

namespace P09_Jump_Around
{
    class Jump_Around
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int start = 0;
            int sum = 0;

            for (int i = 0; i < array.Length; i=start)
            {
                sum += array[i];
                if (i + array[i] > array.Length-1 && i - array[i] < 0)
                {
                    break;
                }
                if (i + array[i] <= array.Length - 1)
                {
                    start += array[i];
                }
                else
                {
                    if (i - array[i] >= 0)
                    {
                        start -= array[i];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
