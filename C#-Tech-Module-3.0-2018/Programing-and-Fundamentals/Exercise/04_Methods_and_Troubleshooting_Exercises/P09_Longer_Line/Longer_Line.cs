﻿using System;

namespace P09_Longer_Line
{
    class Longer_Line
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            if (LineOne(x1,y1,x2,y2) > LineTwo(x3,y3,x4,y4))
            {
                if (Math.Sqrt(x1 * x1 + y1 * y1) > Math.Sqrt(x2 * x2 + y2 * y2))
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
                else
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
            }
            else
            {
                if (Math.Sqrt(x3 * x3 + y3 * y3) > Math.Sqrt(x4 * x4 + y4 * y4))
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
                else
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
            }

        }
        static double LineOne(double x1, double y1, double x2, double y2)
        {
            var powX = Math.Pow((x1 - x2), 2);
            var powY = Math.Pow((y1 - y2), 2);
            var lineOne = Math.Sqrt(powX + powY);
            return lineOne;
        }
        static double LineTwo(double x3, double y3, double x4, double y4)
        {
            var powX = Math.Pow((x4 - x3), 2);
            var powY = Math.Pow((y4 - y3), 2);
            var lineTwo = Math.Sqrt(powX + powY);
            return lineTwo;
        }
    }
}
