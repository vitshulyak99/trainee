using System;
using Task_3.Entities.Attributes;
using Task_3.Entities.Shapes.Base;

namespace Task_3.Entities.Shapes
{
    public class IsoscelesTriangle : Shape
    {
        public override int Id { get; set; }

        public override Point TopLeftPosition { get; set; }

        public override Size RectangleSize { get; set; }

        public IsoscelesTriangle()
        {

        }
        public IsoscelesTriangle(Point topLeftPosition, TriangleSize size)
        {
            RectangleSize = size;
        }



        public override double Perimeter => Math.Pow(
                    Math.Pow(RectangleSize.Width / 2, 2) + Math.Pow(RectangleSize.Height, 2),
                    0.5) * 2 + RectangleSize.Width;

        public override double Square => (RectangleSize.Width * RectangleSize.Height) / 2.0;
    }
}
