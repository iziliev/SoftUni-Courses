using System;
using System.Linq;

namespace P03_Sum_Min_Max_Average
{
    class Sum_Min_Max_Average
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] num = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                num[i] = number;
            }
            Console.WriteLine($"Sum = {num.Sum()}");
            Console.WriteLine($"Min = {num.Min()}");
            Console.WriteLine($"Max = {num.Max()}");
            Console.WriteLine($"Average = {num.Average()}");
        }
    }
}
