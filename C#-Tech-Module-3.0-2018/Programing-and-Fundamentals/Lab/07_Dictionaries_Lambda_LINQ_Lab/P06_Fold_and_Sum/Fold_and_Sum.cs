using System;
using System.Linq;

namespace P06_Fold_and_Sum
{
    class Fold_and_Sum
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = input.Length / 4;
            int[] leftPart = new int[k];
            int[] rightPart = new int[k];

            int[] firstPart = new int[k * 2];
            int[] secondPart = new int[k*2];

            leftPart = input.Take(k).Reverse().ToArray();
            rightPart = input.Skip(k * 3).Take(k).Reverse().ToArray();

            firstPart = leftPart.Concat(rightPart).ToArray();
            secondPart = input.Skip(k).Take(k * 2).ToArray();

            var sum = firstPart.Select((x, index) => x + secondPart[index]);
            Console.WriteLine(string.Join(" ",sum));
        }
    }
}
