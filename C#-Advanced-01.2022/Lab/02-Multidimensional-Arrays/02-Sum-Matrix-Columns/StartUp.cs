using System;
using System.Linq;

namespace _02_Sum_Matrix_Columns
{
    internal class StartUp
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[dimensions[0], dimensions[1]];
            

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                var sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum+=matrix[i, j];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
