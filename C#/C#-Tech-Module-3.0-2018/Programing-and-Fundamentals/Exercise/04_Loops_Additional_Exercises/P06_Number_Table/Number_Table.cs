using System;

namespace P06_Number_Table
{
    class Number_Table
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    Console.Write("{0} ",j);
                }
                for (int k = n-1; k > n- i; k--)
                {
                    Console.Write("{0} ", k);
                }
                Console.WriteLine();
            }
        }
    }
}
