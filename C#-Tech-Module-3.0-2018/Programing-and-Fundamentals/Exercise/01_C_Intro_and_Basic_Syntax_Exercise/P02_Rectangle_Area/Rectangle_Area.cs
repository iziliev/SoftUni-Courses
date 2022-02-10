namespace P02_Rectangle_Area
{
    using System;
    class Rectangle_Area
    {
        static void Main()
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());

            double area = sideA * sideB;

            Console.WriteLine($"{area:F2}");
        }
    }
}
