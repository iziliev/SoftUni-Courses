using System;

namespace P04_Number_Pyramid
{
    class Number_Pyramid
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());

            int row = 1;
            int col = 1;

            while (true)
            {
                for (int i = 0; i < row; i++)
                {
                    Console.Write("{0} ", col++);
                    if (col == n+1)
                    {
                        return;
                    }
                }
                row++;
                Console.WriteLine();
            }
        }
    }
}
