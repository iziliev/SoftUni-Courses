namespace P12_Test_Numbers
{
    using System;
    class Test_Numbers
    {
        static void Main()
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int key = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            for (int i = numberOne; i >= 1; i--)
            {
                for (int j = 1; j <= numberTwo; j++)
                {
                    
                    if (sum < key)
                    {
                        sum += 3 * (i * j);
                        count++;
                    }
                }
            }
            if (sum>=key)
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {sum} >= {key}");
            }
            else
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
