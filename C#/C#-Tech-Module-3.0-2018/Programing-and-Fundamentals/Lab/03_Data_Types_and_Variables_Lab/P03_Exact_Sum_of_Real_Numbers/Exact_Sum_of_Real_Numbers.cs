namespace P03_Exact_Sum_of_Real_Numbers
{
    using System;
    class Exact_Sum_of_Real_Numbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0M;

            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());

                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
