using System;

namespace P05_Fibonacci_Numbers
{
    class Fibonacci_Numbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(number));
        }
        static int Fibonacci(int number)
        {
            int fibonacciOne = 1;
            int fibonacciTwo = 1;
            int fibonacci = 0;
            if (number == 0 || number == 1)
            {
                return fibonacciOne;
            }
            for (int i = 1; i <= number; i++)
            {
                int temp = fibonacciOne + fibonacciTwo;
                fibonacci += temp;
                fibonacciOne = fibonacciTwo;
                fibonacciTwo = temp;
            }
            return fibonacciOne;
        }
    }
}
