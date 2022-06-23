using System;

namespace Recursive_Factorial
{
    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(Factotial(number));
        }

        private static int Factotial(int number)
        {
            if (number==0)
            {
                return 1;
            }

            return number * Factotial(number-1);
        }
    }
}
