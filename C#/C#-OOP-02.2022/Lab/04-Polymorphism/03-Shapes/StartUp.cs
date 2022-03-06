using System;

namespace Shapes
{
    public static class StartUp
    {
        public static void Main()
        {
            var radius = double.Parse(Console.ReadLine());
            Shape circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            Shape rect = new Rectangle(width, height);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine();
            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());
            Console.WriteLine();
            circle.Draw();
            Console.WriteLine();
            rect.Draw();
        }
    }
}
