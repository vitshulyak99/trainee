
using Task_3.Entities.Attributes;
using Task_3.Entities.Shapes.Base;

namespace Task_3.Entities.Shapes
{
    class Rectangle : Shape
    {
        public override int Id { get; set; }

        public override Point TopLeftPosition { get; set; }

        public override Size RectangleSize { get; set; }

        public Rectangle()
        {

        }
        public Rectangle(Point topLeftPosition, Size size)
        {
            TopLeftPosition = topLeftPosition;
            RectangleSize = size;
        }

        public override double Perimeter => RectangleSize.Height * 2 + RectangleSize.Width + 2;

        public override double Square => RectangleSize.Width * RectangleSize.Height;
    }
}
