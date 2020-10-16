using System;
using Task_3.Entities.Attributes;
using Task_3.Entities.Shapes.Base;

namespace Task_3.Entities.Shapes
{
    class Circle : Shape
    {
        public override int Id { get; set; }

        public override Point TopLeftPosition { get; set; }

        public override Size RectangleSize { get; set; } = null;

        public Circle()
        {
            TopLeftPosition = new Point();
            RectangleSize = new Size(1);
        }
        public Circle(Point center, Radius radius)
        {
            TopLeftPosition = center;
            RectangleSize = radius;
        }

        public override double Perimeter => Math.PI * 2 * RectangleSize.Width;

        public override double Square => Math.PI * RectangleSize.Width * RectangleSize.Width;

      
    }
}
