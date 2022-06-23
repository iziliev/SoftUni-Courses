using System;
using System.Linq;

namespace _06_Jagged_Array_Modification
{
    internal class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i]=Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var command = input.Split(' ');

                var row = int.Parse(command[1]);
                var col = int.Parse(command[2]);
                var value = int.Parse(command[3]);

                if (command[0] == "Add")
                {
                    if (IsInMatrix(matrix,row,col))
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (command[0] == "Subtract")
                {
                    if (IsInMatrix(matrix, row, col))
                    {
                        matrix[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(String.Join(" ", matrix[i]));
            }
        }

        private static bool IsInMatrix(int[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}
