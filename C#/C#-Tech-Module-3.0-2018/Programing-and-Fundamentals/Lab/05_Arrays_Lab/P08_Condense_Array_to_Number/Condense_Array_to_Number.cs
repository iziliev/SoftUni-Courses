using System;
using System.Linq;

namespace P08_Condense_Array_to_Number
{
    class Condense_Array_to_Number
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] condensed = new int[array.Length - 1];

            while (array.Length != 1)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int sum = array[i] + array[i + 1];
                    condensed[i] = sum;
                }
                array = condensed;
                condensed = new int[array.Length - 1];
            }
            int result = array[0];
            Console.WriteLine(result);
        }
    }
}