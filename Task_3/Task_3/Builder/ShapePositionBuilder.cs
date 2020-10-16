using Task_3.Entities.Shapes.Base;

namespace Task_3.Builder
{
    public class ShapePositionBuilder<T> where T : Shape
    {
        T _instance;
        public ShapePositionBuilder(T shape)
        {
            _instance = shape;
        }

        public ShapeSizeBuilder<T> SetPosition(int x, int y)
        {
            _instance.TopLeftPosition = new Entities.Attributes.Point(x, y);
            return new ShapeSizeBuilder<T>(_instance);
        }
    }
}