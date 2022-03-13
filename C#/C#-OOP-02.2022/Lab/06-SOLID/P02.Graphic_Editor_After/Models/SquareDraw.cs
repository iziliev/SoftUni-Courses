using P02.Graphic_Editor_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor_After.Models
{
    public class SquareDraw : Draw
    {
        public override void DrawFigure(IShape shape)
        {
            Console.WriteLine("I'm Square");
        }

    }
}
