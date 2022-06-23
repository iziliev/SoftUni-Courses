using System;

namespace P06_Triangle_Area
{
    class Triangle_Area
    {
        static void Main()
        {
            double sideA = double.Parse(Console.ReadLine());
            double heght = double.Parse(Console.ReadLine());
            double area = TriangleArea(sideA, heght);
            Console.WriteLine($"{area:F2}");
        }
        static double TriangleArea(double siteA, double heght)
        {
            return siteA * heght / 2;
        }
    }
}
