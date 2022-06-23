namespace P06_Interval_of_Numbers
{
    using System;
    class Interval_of_Numbers
    {
        static void Main()
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            int maxNumber = Math.Max(numberOne, numberTwo);
            int minNumber = Math.Min(numberOne, numberTwo);

            for (int i = minNumber; i <= maxNumber; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
