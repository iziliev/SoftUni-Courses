using System;

namespace P06_Prime_Checker
{
    class Prime_Checker
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(n));
        }
        static bool IsPrime(long n)
        {
            if (n < 2)
            {
                return false;
            }
            else if (n > 2)
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
