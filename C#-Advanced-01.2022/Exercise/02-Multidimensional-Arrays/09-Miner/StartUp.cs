using System;
using System.Linq;

namespace _09_Miner
{
    class StartUp
    {
        public static int startRow;
        public static int startCol;
        public static int countCoal;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            var command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var isDie = false;

            FillMatrix(matrix);

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == "up")
                {
                    if (IsInMatrix(matrix, startRow - 1, startCol))
                    {
                        if (matrix[startRow - 1, startCol] != 'e')
                        {
                            MovePlayer(matrix, startRow - 1, startCol);
                        }
                        else
                        {
                            Console.WriteLine($"Game over! ({startRow - 1}, {startCol})");
                            isDie = true;
                            return;
                        }
                    }
                }
                if (command[i] == "down")
                {
                    if (IsInMatrix(matrix, startRow + 1, startCol))
                    {
                        if (matrix[startRow + 1, startCol] != 'e')
                        {
                            MovePlayer(matrix, startRow + 1, startCol);
                        }
                        else
                        {
                            Console.WriteLine($"Game over! ({startRow + 1}, {startCol})");
                            isDie = true;
                            return;
                        }
                    }
                }
                if (command[i] == "left")
                {
                    if (IsInMatrix(matrix, startRow, startCol - 1))
                    {
                        if (matrix[startRow, startCol - 1] != 'e')
                        {
                            MovePlayer(matrix, startRow, startCol - 1);
                        }
                        else
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol - 1})");
                            isDie = true;
                            return;
                        }
                    }
                }
                if (command[i] == "right")
                {
                    if (IsInMatrix(matrix, startRow, startCol + 1))
                    {
                        if (matrix[startRow, startCol + 1] != 'e')
                        {
                            MovePlayer(matrix, startRow, startCol + 1);
                        }
                        else
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol + 1})");
                            isDie = true;
                            return;
                        }
                    }
                }

                if (countCoal == 0)
                {
                    break;
                }
            }

            if (countCoal == 0)
            {
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
            }
            else if (countCoal >= 0 && !isDie)
            {
                Console.WriteLine($"{countCoal} coals left. ({startRow}, {startCol})");
            }
        }

        private static void MovePlayer(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] != 'e')
            {
                if (matrix[row, col] == 'c')
                {
                    countCoal--;
                }
                matrix[startRow, startCol] = '*';
                startRow = row;
                startCol = col;
                matrix[startRow, startCol] = 's';
            }
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];

                    if (data[j] == 's')
                    {
                        startRow = i;
                        startCol = j;
                    }
                    if (data[j] == 'c')
                    {
                        countCoal++;
                    }
                }
            }
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}