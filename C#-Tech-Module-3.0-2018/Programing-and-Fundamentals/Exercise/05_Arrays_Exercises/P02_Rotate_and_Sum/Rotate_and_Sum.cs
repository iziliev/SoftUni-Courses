using System;
using System.Linq;

namespace P02_Rotate_and_Sum
{
    class Rotate_and_Sum
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int rotation = int.Parse(Console.ReadLine());

            int[] sumArray = new int[array.Length];
            int[] rotatedArray = new int[array.Length];

            for (int i = 0; i < rotation; i++)
            {
                int last = array[array.Length - 1];
                for (int j = 0; j < rotatedArray.Length-1; j++)
                {
                    rotatedArray[j + 1] = array[j];
                }
                rotatedArray[0] = last;

                for (int l = 0; l < rotatedArray.Length; l++)
                {
                    array[l] = rotatedArray[l];
                }

                for (int k = 0; k < sumArray.Length; k++)
                {
                    sumArray[k] += rotatedArray[k];
                }
            }
            Console.WriteLine(String.Join(' ',sumArray));
        }
    }
}
