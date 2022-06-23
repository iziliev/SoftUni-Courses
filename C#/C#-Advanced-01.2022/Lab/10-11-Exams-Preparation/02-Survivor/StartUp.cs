using System;
using System.Linq;

namespace Survivor
{
    public class StartUp
    {
        public static char[][] matrix;
        public static int playerFind=0;
        public static int opponentFind = 0;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            
            matrix = new char[n][];
            
            FillMatrix();

            var input = string.Empty;
            while ((input=Console.ReadLine())!="Gong")
            {
                var token = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var row = int.Parse(token[1]);
                var col = int.Parse(token[2]);

                if (token[0]== "Find")
                {
                    Move(row, col, "");
                }
                else
                {
                    Move(row, col, token[3]);
                }
            }

            PrintMatrix();

            Console.WriteLine($"Collected tokens: {playerFind}");
            Console.WriteLine($"Opponent's tokens: {opponentFind}");
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ",row));
            }
        }

        private static void Move(int row, int col, string direction)
        {
            if (direction == "")
            {
                if (IsInMatrix(row,col) && matrix[row][col]=='T')
                {
                    matrix[row][col] = '-';
                    playerFind++;
                }
            }
            else
            {
                if (IsInMatrix(row, col))
                {
                    var count = 0;
                    switch (direction)
                    {
                        case "up":
                            for (int i = row; i >= 0; i--)
                            {
                                if (IsInMatrix(i, col) && matrix[i][col] == 'T')
                                {
                                    opponentFind++;
                                    matrix[i][col] = '-';
                                }
                                count++;
                                if (count==4)
                                {
                                    break;
                                }
                            }
                            break;
                        case "down":
                            for (int i = row; i < matrix.Length; i++)
                            {
                                if (IsInMatrix(i, col) && matrix[i][col] == 'T')
                                {
                                    opponentFind++;
                                    matrix[i][col] = '-';
                                }
                                count++;
                                if (count == 4)
                                {
                                    break;
                                }
                            }
                            break;
                        case "left":
                            for (int i = col; i >= 0; i--)
                            {
                                if (IsInMatrix(row, i) && matrix[row][i] == 'T')
                                {
                                    opponentFind++;
                                    matrix[row][i] = '-';
                                }
                                count++;
                                if (count == 4)
                                {
                                    break;
                                }
                            }
                            break;
                        case "right":
                            for (int i = col; i < matrix[row].Length; i++)
                            {
                                if (IsInMatrix(row, i) && matrix[row][i] == 'T')
                                {
                                    opponentFind++;
                                    matrix[row][i] = '-';
                                }
                                count++;
                                if (count == 4)
                                {
                                    break;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row>=0&&row<matrix.Length&&col>=0&&col<matrix[row].Length;
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i]=Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }
        }
    }
}
