using System;

namespace Shapes
{
    public class Rectangle:Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }
        
        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public override double CalculateArea()
        {
            return this.Width* this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Width + this.Height);
        }

        public override void Draw()
        {
                DrawLine(this.Width, '*', '*');
                for (int i = 1; i < this.Height - 1; ++i)
                    DrawLine(this.width, '*', ' ');
                DrawLine(this.width, '*', '*');
            
        }
        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
                Console.Write(mid);
            Console.WriteLine(end);
        }
    }
}
