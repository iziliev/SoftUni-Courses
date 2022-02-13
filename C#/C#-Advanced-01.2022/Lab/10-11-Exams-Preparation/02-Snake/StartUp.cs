using System;
using System.Linq;

namespace Snake
{
    public class StartUp
    {
        public static char[][] matrix;
        public static int startRow;
        public static int startCol;
        public static int food;
        public static bool isOut = false;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            FillMatrix();

            while (true)
            {
                var direction = Console.ReadLine();

                Move(direction);

                if (food==10)
                {
                    break;
                }

                if (isOut)
                {
                    break;
                }
            }

            if (food==10)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {food}");
            }
            else
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {food}");
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }

        private static void Move(string direction)
        {
            matrix[startRow][startCol] = '.';
            if (direction=="up")
            {
                if (IsInRange(startRow-1,startCol))
                {
                    startRow--;
                    MoveByDirection();
                }
                else
                {
                    isOut = true;
                }
            }
            else if (direction == "down")
            {
                if (IsInRange(startRow + 1, startCol))
                {
                    startRow++;
                    MoveByDirection();
                }
                else
                {
                    isOut = true;
                }
            }
            else if (direction == "left")
            {
                if (IsInRange(startRow, startCol-1))
                {
                    startCol--;
                    MoveByDirection();
                }
                else
                {
                    isOut = true;
                }
            }
            else if (direction == "right")
            {
                if (IsInRange(startRow, startCol + 1))
                {
                    startCol++;
                    MoveByDirection();
                }
                else
                {
                    isOut = true;
                }
            }
        }

        private static void MoveByDirection()
        {
            if (matrix[startRow][startCol] == '*')
            {
                matrix[startRow][startCol] = 'S';
                food++;
            }
            else if (matrix[startRow][startCol] == 'B')
            {
                matrix[startRow][startCol] = '.';
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i].Contains('B'))
                    {
                        startRow = i;
                        startCol = Array.IndexOf(matrix[i], 'B');
                        matrix[startRow][startCol] = 'S';
                        break;
                    }
                }
            }
            else
            {
                matrix[startRow][startCol] = 'S';
            }
        }

        private static bool IsInRange(int row, int col)
        {
            return row>=0&&row<matrix.Length&&col>=0&&col<matrix[row].Length;
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();

                if (matrix[i].Contains('S'))
                {
                    startRow = i;
                    startCol = Array.IndexOf(matrix[i], 'S');
                }
            }
        }
    }
}
