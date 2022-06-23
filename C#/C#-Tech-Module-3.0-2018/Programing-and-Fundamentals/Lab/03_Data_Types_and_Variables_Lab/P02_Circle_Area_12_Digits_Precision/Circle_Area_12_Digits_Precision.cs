namespace P02_Circle_Area_12_Digits_Precision
{
    using System;
    class Circle_Area_12_Digits_Precision
    {
        static void Main()
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine($"{0:F12}",Math.PI*r*r);
        }
    }
}
