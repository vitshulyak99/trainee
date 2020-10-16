
using System;
using Task_3.Entities.Attributes;
using Task_3.Entities.Shapes.Base;

namespace Task_3.Transformer
{
    static class ShapeTransformer<T> where T : Shape
    {
        public static event Action<string> ShapePerimeterIsTooBig = Prnt;

        public static event Action<string> ShapePerimeterIsTooSmall = Prnt;

        public static event Action<string> ShapeSquareIsTooBig = Prnt;

        public static event Action<string> ShapeSquareIsTooSmall = Prnt;

        public static event Action<string> ShapeMovedToOutOfBounds = Prnt;



        public static Shape AddShapeSize(T shape, int val)
        {
            shape.RectangleSize += val;
            CheckPerimeter(shape);

            return shape;
        }

        public static Shape ReduceShapeSize(T shape, int val)
        {
            shape.RectangleSize -= val;
            CheckPerimeter(shape);

            return shape;
        }

        public static Shape IncreaseShapeSize(T shape, int multiplie)
        {
            shape.RectangleSize *= multiplie;
            CheckSquare(shape);

            return shape;
        }

        public static Shape DecreaseShapeSize(T shape, int delimiter)
        {
            shape.RectangleSize /= delimiter;
            CheckSquare(shape);

            return shape;
        }

        public static Shape MoveShape(T shape, Point deltaPoint)
        {
            shape.TopLeftPosition += deltaPoint;
            CheckPosition(shape);

            return shape;
        }

        private static void CheckPosition(T shape)
        {
            int x = shape.TopLeftPosition.X,
                y = shape.TopLeftPosition.Y;

            if (x < 0 || y < 0 || x > 1000 || y > 1000)
            {
                ShapeMovedToOutOfBounds($"Id:{shape.Id} Position:{shape.TopLeftPosition.ToString()} Shape moved out of bounds");
            }
        }

        private static void CheckSquare(T shape)
        {
            var shapeInfo = "Id:" + shape.Id + " Square:" + shape.Square.ToString();

            if (shape.Square < 50)
            {
                ShapeSquareIsTooSmall($"{shapeInfo} Shape square is too small");
            }
            else if (shape.Square > 500)
            {
                ShapeSquareIsTooBig($"{shapeInfo} Shape square is too big");
            }
        }

        private static void CheckPerimeter(T shape)
        {
            var shapeInfo = "Id" + shape.Id + " Perimeter" + shape.Perimeter.ToString();

            if (shape.Perimeter < 10)
            {
                ShapePerimeterIsTooSmall($"{shapeInfo} Shape perimeter is too small");
            }
            else if (shape.Perimeter > 100)
            {
                ShapePerimeterIsTooBig($"{shapeInfo} Shape perimeter is too big");
            }

        }

        private static void Prnt(string s) => Console.WriteLine(s);
    }

}

