using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaveratWork
{
    public class StartUp
    {
        public static char[][] matrix;
        public static int beaverRow;
        public static int beaverCol;
        public static Stack<char> woods = new Stack<char>();
        public static int woodsCount;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            matrix = new char[n][];

            FillMatrix();

            var direction = string.Empty;
            while ((direction = Console.ReadLine()) != "end" && woodsCount>0)
            {
                Move(direction);
            }

            if (woodsCount==0)
            {
                Console.WriteLine($"The Beaver successfully collect {woods.Count} wood branches: {string.Join(", ",woods.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodsCount} branches left.");
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    MoveByGivenDirection(beaverRow - 1, beaverCol, direction);
                    break;
                case "down":
                    MoveByGivenDirection(beaverRow + 1, beaverCol, direction);
                    break;
                case "left":
                    MoveByGivenDirection(beaverRow, beaverCol - 1, direction);
                    break;
                case "right":
                    MoveByGivenDirection(beaverRow, beaverCol + 1, direction);
                    break;
                default:
                    break;
            }
        }

        private static void MoveByGivenDirection(int row, int col, string direction)
        {
            if (IsInMatrix(row, col))
            {
                matrix[beaverRow][beaverCol] = '-';

                if (IsCharIsLower(row,col))
                {
                    woodsCount--;
                    woods.Push(matrix[row][col]);
                    beaverRow=row;
                    beaverCol=col;
                    matrix[row][col] = 'B';
                }
                else if (IsEatFish(row,col))
                {
                    BeaverSwimUnderWater(row, col, direction);
                }
                else
                {
                    beaverRow = row;
                    beaverCol = col;
                    matrix[beaverRow][beaverCol] = 'B';
                }
            }
            else
            {
                if (woods.Count>0)
                {
                    woods.Pop();
                }
            }
        }

        private static void BeaverSwimUnderWater(int row, int col, string direction)
        {
            matrix[row][col] = '-';
            if (direction=="up")
            {
                if (row==0)
                {
                    row = matrix.Length - 1;
                    beaverRow = row;
                    CoolectWoodsAfterUnderwaterSwim(row, col);
                    matrix[beaverRow][beaverCol] = 'B';
                }
                else
                {
                    row = 0;
                    beaverRow = row;
                    CoolectWoodsAfterUnderwaterSwim(row, col);
                    matrix[beaverRow][beaverCol] = 'B';
                }
                
            }
            else if (direction == "down" )
            {
                if (row == matrix.Length - 1)
                {
                    row = 0;
                    beaverRow = row;
                    CoolectWoodsAfterUnderwaterSwim(row, col);
                    matrix[beaverRow][beaverCol] = 'B';
                }
                else
                {
                    row = matrix.Length - 1;
                    beaverRow = row;
                    CoolectWoodsAfterUnderwaterSwim(row, col);
                    matrix[beaverRow][beaverCol] = 'B';
                }
            }
            else if (direction == "left")
            {
                if (col==0)
                {
                    col = matrix[row].Length - 1;
                    beaverCol = col;
                    CoolectWoodsAfterUnderwaterSwim(row, col);
                    matrix[beaverRow][beaverCol] = 'B';
                }
                else
                {
                    col = 0;
                    beaverCol = col;
                    CoolectWoodsAfterUnderwaterSwim(row, col);
                    matrix[beaverRow][beaverCol] = 'B';
                }
            }
            else if (direction == "right")
            {
                if (col == matrix[row].Length - 1)
                {
                    col = 0;
                    beaverCol = col;
                    CoolectWoodsAfterUnderwaterSwim(row, col);
                    matrix[beaverRow][beaverCol] = 'B';
                }
                else
                {
                    col = matrix[row].Length - 1;
                    beaverCol = col;
                    CoolectWoodsAfterUnderwaterSwim(row, col);
                    matrix[beaverRow][beaverCol] = 'B';
                }
            }
        }

        private static void CoolectWoodsAfterUnderwaterSwim(int row, int col)
        {
            if (IsCharIsLower(row, col))
            {
                woods.Push(matrix[row][col]);
                woodsCount--;
            }
        }

        private static bool IsEatFish(int row, int col)
        {
            return matrix[row][col] == 'F';
        }

        private static bool IsCharIsLower(int row, int col)
        {
            return char.IsLower(matrix[row][col]);
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                matrix[i] = string.Join("", input).ToCharArray();

                if (matrix[i].Contains('B'))
                {
                    beaverRow = i;
                    beaverCol = Array.IndexOf(matrix[i], 'B');
                }

                woodsCount += matrix[i].Where(i => char.IsLower(i)).Count();
            }
        }
    }
}
