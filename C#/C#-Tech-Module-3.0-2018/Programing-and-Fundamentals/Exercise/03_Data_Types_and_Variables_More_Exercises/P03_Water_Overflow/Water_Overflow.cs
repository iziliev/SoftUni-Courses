namespace P03_Water_Overflow
{
    using System;
    class Water_Overflow
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int capacity = 255;
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                count += liters;

                if (count > capacity)
                {
                    count -= liters;
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(count);
        }
    }
}
