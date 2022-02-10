using System;

namespace P03_Last_K_Numbers_Sums_Sequence
{
    class Last_K_Numbers_Sums_Sequence
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            array[0] = 1;
            int count = 1;
            for (int i = 1; i < n; i++)
            {
                int sum = 0;
                if (count <= k)
                {
                    for (int j = 0; j < count; j++)
                    {
                        sum += array[j];
                    }
                    count++;
                }
                else
                {
                    for (int j = i-1; j >= i-k; j--)
                    {
                        sum += array[j];
                    }
                }
                array[i] = sum;
            }
            Console.WriteLine(String.Join(" ",array));
        }
    }
}