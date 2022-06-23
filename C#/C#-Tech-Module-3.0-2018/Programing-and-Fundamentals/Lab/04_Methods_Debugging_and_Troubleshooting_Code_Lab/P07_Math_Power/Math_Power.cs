using System;

namespace P07_Math_Power
{
    class Math_Power
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());
            long sum = NumberPow(number, pow);
            Console.WriteLine(sum);
        }
        static long NumberPow(int number, int pow)
        {
            long result = 1;
            for (int i = 1; i <= pow; i++)
            {
                result *= number;
            }
            return result;
        }
    }
}
