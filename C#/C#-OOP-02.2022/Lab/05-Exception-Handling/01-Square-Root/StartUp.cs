using System;

namespace _01_Square_Root
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine(SquareRoot());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        private static double SquareRoot()
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                throw new ArgumentException("Invalid number.");
            }

            return Math.Sqrt(n);
        }
    }
}
