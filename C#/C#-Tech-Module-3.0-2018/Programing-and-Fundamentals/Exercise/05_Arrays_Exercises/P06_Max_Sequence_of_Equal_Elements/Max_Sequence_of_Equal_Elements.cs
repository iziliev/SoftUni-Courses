using System;
using System.Linq;

namespace P06_Max_Sequence_of_Equal_Elements
{
    class Max_Sequence_of_Equal_Elements
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int count = 1;
            int maxCount = 0;
            int index = 0;

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
                if (count > maxCount)
                {
                    maxCount = count;
                    index = i;
                }
            }

            for (int i = index - maxCount + 1; i <= index; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }
}
