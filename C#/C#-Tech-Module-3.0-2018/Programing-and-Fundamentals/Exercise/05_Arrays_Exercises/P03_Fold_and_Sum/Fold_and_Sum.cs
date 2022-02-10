using System;
using System.Linq;

namespace P03_Fold_and_Sum
{
    class Fold_and_Sum
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = array.Length / 4;

            var arrayLeft = array.Take(k).ToArray();
            var arrayMiddle = array.Skip(k).Take(k * 2).ToArray();
            var arrayRight = array.Skip(k * 3).Take(k).ToArray();

            Array.Reverse(arrayLeft);
            Array.Reverse(arrayRight);

            int[] arraySum = new int[k * 2];

            for (int i = 0; i < k; i++)
            {
                arraySum[i] = arrayLeft[i] + arrayMiddle[i];
                arraySum[i + k] = arrayRight[i] + arrayMiddle[i + k];
            }
            Console.WriteLine(String.Join(' ',arraySum));
        }
    }
}