using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Closest_Two_Points
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

    class Closest_Two_Points
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Point> listOfPoints = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                var point = ReadPoint();

                listOfPoints.Add(point);
            }

            var minDistance = double.MaxValue;

            Point firstMinPoint = null;
            Point secondMinPoint = null;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    var firstPoint = listOfPoints[i];
                    var secondPoint = listOfPoints[j];

                    var currentDistance = Distance(firstPoint, secondPoint);

                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        firstMinPoint = firstPoint;
                        secondMinPoint = secondPoint;
                    }
                }
            }
            Console.WriteLine($"{minDistance:F3}");

            Console.WriteLine($"({firstMinPoint.X}, {firstMinPoint.Y})");
            Console.WriteLine($"({secondMinPoint.X}, {secondMinPoint.Y})");
        }

        static double Distance(Point firstPoint, Point secondPoint)
        {
            var pointX = firstPoint.X - secondPoint.X;
            var pointY = firstPoint.Y - secondPoint.Y;
            var powPointX = Math.Pow(pointX, 2);
            var powPointY = Math.Pow(pointY, 2);

            var distance = Math.Sqrt(powPointX + powPointY);

            return distance;
        }

        static Point ReadPoint()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double x = input[0];
            double y = input[1];

            Point points = new Point(x, y);

            return points;
        }
    }
}
