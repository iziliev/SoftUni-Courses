using System;

namespace P05_Temp_Conversion
{
    class Temp_Conversion
    {
        static void Main()
        {
            double fahrenheit = double.Parse(Console.ReadLine());
            double celsii = FarenhaitToCelsii(fahrenheit);
            Console.WriteLine($"{celsii:F2}");
        }
        static double FarenhaitToCelsii(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
