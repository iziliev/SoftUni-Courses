using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Distance_Between_Points
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    class Distance_Between_Points
    {
        static void Main()
        {
            var firstPoint = Read();
            var secondPoint = Read();

            var result = Distance(firstPoint,secondPoint);
            Console.WriteLine($"{result:F3}");
        }

        static double Distance(Point firstPoint, Point secondPoint)
        {
            var pointX = firstPoint.X - secondPoint.X;
            var pointY = firstPoint.Y - secondPoint.Y;
            var powPointX = Math.Pow(pointX,2);
            var powPointY = Math.Pow(pointY, 2);

            var distance = Math.Sqrt(powPointX + powPointY);

            return distance;
        }
        static Point Read()
        {
            double[] row = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double x = row[0];
            double y = row[1];
            Point points = new Point(x, y);
            return points;
        }
    }

}
