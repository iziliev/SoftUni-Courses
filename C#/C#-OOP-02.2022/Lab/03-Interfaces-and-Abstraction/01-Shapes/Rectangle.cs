using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }
        
        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        public void Draw()
        {
            Console.WriteLine(new String('*',this.Width));

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if (j==0 || j == this.Width-1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }


            Console.WriteLine(new String('*', this.Width));
        }
    }
}
