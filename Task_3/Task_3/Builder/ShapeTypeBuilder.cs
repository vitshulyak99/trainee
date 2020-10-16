
using Task_3.Entities.Shapes.Base;

namespace Task_3.Builder
{
    class ShapeTypeBuilder
    {
        public static ShapePositionBuilder<T> Create<T>() where T:Shape,new() 
        {
            return new ShapePositionBuilder<T>(new T() { Id = Shape.LastID++ });
        }
    }
}
