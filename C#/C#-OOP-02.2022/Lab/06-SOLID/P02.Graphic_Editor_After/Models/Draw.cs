using P02.Graphic_Editor_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor_After.Models
{
    public abstract class Draw : IDraw
    {
        public void DrawShape(IShape shape)
        {
            this.DrawShape(shape);
        }
        public abstract void DrawFigure(IShape shape);

    }
}
