using System;

namespace _04_Symbol_in_Matrix
{
    internal class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine();   

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var findElement = char.Parse(Console.ReadLine());
            var isFind = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]==findElement)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isFind = true;
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
            }

            if (!isFind)
            {
                Console.WriteLine($"{findElement} does not occur in the matrix ");
            }
        }
    }
}
