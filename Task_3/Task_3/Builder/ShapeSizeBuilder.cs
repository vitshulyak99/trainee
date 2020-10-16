using Task_3.Entities.Attributes;
using Task_3.Entities.Shapes.Base;

namespace Task_3.Builder
{
    public class ShapeSizeBuilder<T> where T : Shape
    {
        T _instance;

        public ShapeSizeBuilder(T instance)
        {

            _instance = instance;
        }


        public T Build<U>(U sizeParam) where U : Size
        {
            _instance.RectangleSize = sizeParam;
            return _instance;
        }
    }
}



