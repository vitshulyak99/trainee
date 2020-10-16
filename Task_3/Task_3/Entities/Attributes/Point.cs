/*
Создайте класс Point { x: int; y: int}

для класса Point переопределить операторы
Ponit + Point => (x + x, y + y)
Point * Int
Point + SIze => (x + width, y + height)
Point - Size
 */

namespace Task_3.Entities.Attributes
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x=0, int y=0)
        {
            X = x;
            Y = y;
        }
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator *(Point a, int x)
        {
            return new Point(a.X * x, a.Y * x);
        }

        public static Point operator +(Point point, Size size)
        {
            return new Point(point.X + size.Width, point.Y + size.Height);
        }

        public static Point operator -(Point point, Size size)
        {
            return new Point(point.X - size.Width, point.Y - size.Height);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
