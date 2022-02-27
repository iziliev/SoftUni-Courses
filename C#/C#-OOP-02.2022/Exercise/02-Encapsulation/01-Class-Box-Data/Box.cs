using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string exeption = " cannot be zero or negative.";

        private double lenght;
        private double width ;
        private double height ;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get 
            { 
                return lenght; 
            }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException($"{this.Length.GetType().Name}{exeption}");
                }
                lenght = value; 
            }
        }
        public double Width
        {
            get 
            { 
                return width; 
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{this.Width.GetType().Name}{exeption}");
                }
                width = value; 
            }
        }
        public double Height
        {
            get 
            { 
                return height; 
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{this.Height.GetType().Name}{exeption}");
                }
                height = value; 
            }
        }
        public double SurfaceArea()
        {
            return 2 * this.lenght * this.width + 2 * this.lenght * this.Height + 2 * this.Height * this.width;
        }
        public double LateralSurfaceArea()
        {
            return 2 * this.lenght * this.Height + 2 * this.Height * this.width;
        }
        public double Volume()
        {
            return this.lenght * this.Height * this.Width;
        }
    }
}
