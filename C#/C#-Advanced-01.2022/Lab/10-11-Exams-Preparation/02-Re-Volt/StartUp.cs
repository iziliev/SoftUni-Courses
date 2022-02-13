using System;

namespace ReVolt
{
    public class StartUp
    {
        public static char[,] matrix;
        public static int startRow;
        public static int startCol;
        public static bool win = false;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            matrix = new char[n, n];

            FillMatrix();

            for (int i = 0; i < m; i++)
            {
                var direction = Console.ReadLine();

                Move(direction);

                if (win)
                {
                    break;
                }
            }

            if (win)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(string direction)
        {
            if (matrix[startRow, startCol] != 'B' && matrix[startRow, startCol] != 'T')
            {
                matrix[startRow, startCol] = '-';
            }
            switch (direction)
            {
                case "up":
                    startRow--;
                    MoveUpDownLeftRight(direction);
                    break;
                case "down":
                    startRow++;
                    MoveUpDownLeftRight(direction);
                    break;
                case "left":
                    startCol--;
                    MoveUpDownLeftRight(direction);
                    break;
                case "right":
                    startCol++;
                    MoveUpDownLeftRight(direction);
                    break;
                default:
                    break;
            }
        }

        private static void MoveUpDownLeftRight(string direction)
        {
            if (IsInMatrix(startRow, startCol))
            {
                if (matrix[startRow, startCol] == 'B')
                {
                    Move(direction);
                    return;
                }
                else if (matrix[startRow, startCol] == 'T')
                {
                    if (direction == "up")
                    {
                        Move("down");
                    }
                    else if (direction == "down")
                    {
                        Move("up");
                    }
                    else if (direction == "left")
                    {
                        Move("right");
                    }
                    else
                    {
                        Move("left");
                    }
                }
                else if (matrix[startRow, startCol] == '-')
                {
                    matrix[startRow, startCol] = 'f';
                }
                else
                {
                    matrix[startRow, startCol] = 'f';
                    win = true;
                }
            }
            else
            {
                if (startRow < 0)
                {
                    startRow = matrix.GetLength(0) - 1;
                }
                else if (startRow >= matrix.GetLength(1))
                {
                    startRow = 0;
                }
                else if (startCol < 0)
                {
                    startCol = matrix.GetLength(1) - 1;
                }
                else
                {
                    startCol = 0;
                }
                if (matrix[startRow, startCol] == 'F')
                {
                    win = true;
                }
                matrix[startRow, startCol] = 'f';
            }
        }
        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];

                    if (input[j] == 'f')
                    {
                        startRow = i;
                        startCol = j;
                    }
                }
            }
        }
    }
}
