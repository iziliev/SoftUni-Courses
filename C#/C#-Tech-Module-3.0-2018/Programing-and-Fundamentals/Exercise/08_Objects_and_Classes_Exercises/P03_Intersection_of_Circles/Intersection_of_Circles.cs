using System;
using System.Linq;

namespace P03_Intersection_of_Circles
{
    class Circle
    {
        public double Center { get; set; }
        public double Radius { get; set; }

        public Circle(double r)
        {
            Radius = r;
        }
    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        
        public Point(double x,double y)
        {
            X = x;
            Y = y;
        }
    }

    class Intersection_of_Circles
    {
        static void Main()
        {
            double[] circleOne = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double[] circleTwo = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            
            double x = circleOne[0];
            double y = circleOne[1];
            Point firstPoint = new Point(x, y);
            
            x = circleTwo[0];
            y = circleTwo[1];
            Point secondPoint = new Point(x, y);
            
            double r = circleOne[2];
            Circle circleOnes = new Circle(r);
            
            r = circleTwo[2];
            Circle circleTwos = new Circle(r);


            var distance = DistanceBetweenTwoPoints(firstPoint, secondPoint);
            var check = IsInside(circleOnes, circleTwos, firstPoint, secondPoint);
            if (check == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static double DistanceBetweenTwoPoints(Point firstPoint,Point secondPoint)
        {
            var distance = Math.Sqrt(Math.Pow(secondPoint.X, 2) - Math.Pow(firstPoint.X, 2) + Math.Pow(secondPoint.Y, 2) - Math.Pow(firstPoint.Y, 2));
            return distance;
        }

        public static bool IsInside(Circle circleOnes, Circle circleTwos, Point firstPoint,Point secondPoint)
        {
            var dist = DistanceBetweenTwoPoints(firstPoint, secondPoint);

            if (dist <= circleOnes.Radius + circleTwos.Radius)
            {
                return true;
            }
            return false;
        }
    }
}
