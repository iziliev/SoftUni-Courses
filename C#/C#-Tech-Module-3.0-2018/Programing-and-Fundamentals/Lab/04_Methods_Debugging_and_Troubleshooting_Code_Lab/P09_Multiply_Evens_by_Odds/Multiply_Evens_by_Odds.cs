using System;

namespace P09_Multiply_Evens_by_Odds
{
    class Multiply_Evens_by_Odds
    {
        static void Main()
        {
            int numbers = int.Parse(Console.ReadLine());
            int number = Math.Abs(numbers);
            long result = SumEvenDigits(number) * SumOddDigits(number);
            Console.WriteLine(Math.Abs(result));
        }
        static int SumEvenDigits(int number)
        {
            int even = 0;
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    even += digit;
                }
                number /= 10;
            }
            return even;
        }
        static int SumOddDigits(int number)
        {
            int odd = 0;
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    odd += digit;
                }
                number /= 10;
            }
            return odd;
        }
    }
}
