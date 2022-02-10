using System;
using System.Linq;

namespace P06_Sum_Reversed_Numbers
{
    class Sum_Reversed_Numbers
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] output = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];
                int left = number;
                int reverse = 0;

                while (left > 0)
                {
                    int last = left % 10;
                    reverse = reverse * 10 + last;
                    left = left / 10;
                }
                output[i] = reverse;
            }
            Console.WriteLine(output.Sum());
        }
    }
}
