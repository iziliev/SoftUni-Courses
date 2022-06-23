using System;
using System.Linq;

namespace P05_Rounding_Numbers_Away_from_Zero
{
    class Rounding_Numbers_Away_from_Zero
    {
        static void Main()
        {
            double[] array = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{array[i]} => {Math.Round(array[i],MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
