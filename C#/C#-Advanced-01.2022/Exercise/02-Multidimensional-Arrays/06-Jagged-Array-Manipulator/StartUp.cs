using System;
using System.Linq;

namespace _06_Jagged_Array_Manipulator
{
    class StartUp
    {
        static void Main()
        {
            var row = int.Parse(Console.ReadLine());

            var matrix = new double[row][];

            for (int i = 0; i < matrix.Length; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(double.Parse)
                    .ToArray();

                matrix[i] = input;
            }

            Analyzing(matrix);

            var inputCommands = string.Empty;

            while ((inputCommands = Console.ReadLine()) != "End")
            {
                var data = inputCommands
                    .Split(' ')
                    .ToArray();

                var commands = data[0];
                var rows = int.Parse(data[1]);
                var cols = int.Parse(data[2]);
                var value = int.Parse(data[3]);

                if (commands == "Add")
                {
                    if (IsInRange(matrix, rows, cols))
                    {
                        matrix[rows][cols] += value;
                    }
                }
                else if (commands == "Subtract")
                {
                    if (IsInRange(matrix, rows, cols))
                    {
                        matrix[rows][cols] -= value;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(double[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(String.Join(" ", matrix[i]));
            }
        }

        private static bool IsInRange(double[][] matrix, int rows, int cols)
        {
            return rows >= 0 && rows < matrix.Length && cols >= 0 && cols < matrix[rows].Length;
        }

        private static void Analyzing(double[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int k = i; k <= i + 1; k++)
                    {
                        for (int j = 0; j < matrix[k].Length; j++)
                        {
                            matrix[k][j] *= 2;
                        }
                    }
                }
                else
                {
                    for (int k = i; k <= i + 1; k++)
                    {
                        for (int j = 0; j < matrix[k].Length; j++)
                        {
                            matrix[k][j] /= 2;
                        }
                    }
                }
            }
        }
    }
}
