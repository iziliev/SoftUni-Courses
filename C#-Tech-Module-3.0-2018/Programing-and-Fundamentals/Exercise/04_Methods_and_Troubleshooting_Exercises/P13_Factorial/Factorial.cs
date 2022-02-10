using System;
using System.Numerics;

namespace P13_Factorial
{
    class Factorial
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
            return result;
        }
    }
}
