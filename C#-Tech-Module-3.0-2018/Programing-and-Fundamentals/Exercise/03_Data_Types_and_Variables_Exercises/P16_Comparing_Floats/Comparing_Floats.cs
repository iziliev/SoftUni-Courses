namespace P16_Comparing_Floats
{
    using System;
    class Comparing_Floats
    {
        static void Main()
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double differences = Math.Abs(numberA - numberB);
            bool check = false;

            if (differences < eps)
            {
                check = true;
                Console.WriteLine(check);
            }
            else
            {
                Console.WriteLine(check);
            }
        }
    }
}
