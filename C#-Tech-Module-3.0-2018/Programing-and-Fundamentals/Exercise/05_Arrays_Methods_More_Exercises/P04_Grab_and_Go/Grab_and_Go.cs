using System;
using System.Linq;

namespace P04_Grab_and_Go
{
    class Grab_and_Go
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            int index = -1;
            long sum = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (n == array[i])
                {
                    index = i;
                    break;
                }
            }
            for (int i = 0; i < index; i++)
            {
                sum += array[i];
            }
            if (index == -1)
            {
                Console.WriteLine("No occurrences were found!");
                return;
            }
            Console.WriteLine(sum);
        }
    }
}
