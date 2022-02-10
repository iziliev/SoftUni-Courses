using System;
using System.Linq;

namespace P06_Rectangle_Position
{
    class Rectanle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Widht { get; set; }
        public int Height { get; set; }

        
        
        public int Right => Left + Widht;
        public int Bottom => Top + Height;
    }

    class Rectangle_Position
    {
        static void Main()
        {
            var firstRectangle = Read();
            var secondRectangle = Read();

            if (IsInside(firstRectangle,secondRectangle) == true)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }

        }
        static Rectanle Read()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Rectanle rectangle = new Rectanle();

            rectangle.Top = input[0];
            rectangle.Left = input[1];
            rectangle.Widht = input[2];
            rectangle.Height = input[3];

            return rectangle;
        }

        static bool IsInside(Rectanle firstRectangle,Rectanle secondRectangle)
        {
            if (firstRectangle.Left>=secondRectangle.Left &&
                firstRectangle.Right<=secondRectangle.Right &&
                firstRectangle.Top >= secondRectangle.Top &&
                firstRectangle.Bottom <= secondRectangle.Bottom)
            {
                return true;
            }
            return false;
        }
    }
}
