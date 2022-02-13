using System;
using System.Collections.Generic;
using System.Linq;

namespace Bee
{
    public class StartUp
    {
        public static char[][] matrix;
        public static int startRow;
        public static int startCol;
        public static int flowers;
        public static bool isOut = false;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            matrix = new char[n][];

            FillMatrix();
            var direction = string.Empty;

            while ((direction=Console.ReadLine())!="End")
            {
                MoveBee(direction);

                if (isOut)
                {
                    break;
                }
                
            }

            if (isOut)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (flowers<5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
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

        private static void MoveBee(string direction)
        {
            matrix[startRow][startCol] = '.';
            if (direction=="up")
            {
                if (IsInRange(startRow-1,startCol))
                {
                    var place = WhatIsOnThisMoveInMatrix(startRow - 1, startCol);
                    startRow--;
                    switch (place)
                    {
                        case "empty":
                            matrix[startRow][startCol] = 'B';
                            break;
                        case "flower":
                            matrix[startRow][startCol] = 'B';
                            flowers++;
                            break;
                        case "bonus":
                            matrix[startRow][startCol] = '.';
                            MoveBee("up");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isOut= true;
                    matrix[startRow][startCol] = '.';
                }
                
            }
            else if (direction == "down")
            {
                if (IsInRange(startRow + 1, startCol))
                {
                    var place = WhatIsOnThisMoveInMatrix(startRow + 1, startCol);
                    startRow++;
                    switch (place)
                    {
                        case "empty":
                            matrix[startRow][startCol] = 'B';
                            break;
                        case "flower":
                            matrix[startRow][startCol] = 'B';
                            flowers++;
                            break;
                        case "bonus":
                            matrix[startRow][startCol] = '.';
                            MoveBee("down");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isOut = true;
                    matrix[startRow][startCol] = '.';
                }
            }
            else if (direction == "left")
            {
                if (IsInRange(startRow, startCol-1))
                {
                    var place = WhatIsOnThisMoveInMatrix(startRow, startCol-1);
                    startCol--;
                    switch (place)
                    {
                        case "empty":
                            matrix[startRow][startCol] = 'B';
                            break;
                        case "flower":
                            matrix[startRow][startCol] = 'B';
                            flowers++;
                            break;
                        case "bonus":
                            matrix[startRow][startCol] = '.';
                            MoveBee("left");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isOut = true;
                    matrix[startRow][startCol] = '.';
                }
            }
            else if (direction == "right")
            {
                if (IsInRange(startRow, startCol+1))
                {
                    var place = WhatIsOnThisMoveInMatrix(startRow, startCol+1);
                    startCol++;
                    switch (place)
                    {
                        case "empty":
                            matrix[startRow][startCol] = 'B';
                            break;
                        case "flower":
                            matrix[startRow][startCol] = 'B';
                            flowers++;
                            break;
                        case "bonus":
                            matrix[startRow][startCol] = '.';
                            MoveBee("right");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isOut = true;
                    matrix[startRow][startCol] = '.';
                }
            }
        }

        private static string WhatIsOnThisMoveInMatrix(int row, int col)
        {
            if (matrix[row][col]=='.')
            {
                return "empty";
            }
            else if (matrix[row][col] == 'f')
            {
                return "flower";
            }

            return "bonus";
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

                if (matrix[i].Contains('B'))
                {
                    startRow=i;
                    startCol = Array.IndexOf(matrix[i], 'B');
                }
            }
        }
    }
}
