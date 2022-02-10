using System;
using System.Numerics;

namespace P14_Factorial_Trailing_Zero
{
    class Factorial_Trailing_Zero
    {
        static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine(Factorials(number));
        }
        static BigInteger Factorials(BigInteger number)
        {
            BigInteger result = 1;

            for (BigInteger i = 1; i <= number; i++)
            {
                result *= i;
            }
            int count = 0;
            BigInteger lastDigits = 0;
            while (result % 10 == 0)
            {
                lastDigits = result % 10;
                count++;
                result /= 10;
            }
            return count;
        }
    }
}
