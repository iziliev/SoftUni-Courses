using System;

namespace P11_Geometry_Calculator
{
    class Geometry_Calculator
    {
        static void Main()
        {
            string figure = Console.ReadLine();

            if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Console.WriteLine("{0:f2}", Triangle(side, height));
            }
            else if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", Square(side));
            }
            else if (figure == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", Rectangle(width, height));
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", Circle(radius));
            }
        }

        static double Triangle(double side, double height)
        {
            double areaT = (side * height) / 2;
            return areaT;
        }
        static double Square(double side)
        {
            double areaS = side * side;
            return areaS;
        }
        static double Rectangle(double width, double height)
        {
            double areaR = width * height;
            return areaR;
        }
        static double Circle(double radius)
        {
            double areaC = radius * radius * Math.PI;
            return areaC;
        }
    }
}
