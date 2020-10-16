/*Создайте класс Size {width: int; height: int}
Для метода Size переопределить операторы
Size + Int (=> width + int, height + int)
Size - Int
Size * Int*/
namespace Task_3.Entities.Attributes
{
    public class Size
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public Size(int width = 0, int height = 0)
        {
            Width = width;
            Height = height;
        }

        public static Size operator +(Size size, int val)
        {
            return new Size(size.Width + val, size.Height + val);
        }

        public static Size operator -(Size size, int val)
        {
            return new Size(size.Width - val, size.Height - val);
        }

        public static Size operator *(Size size, int val)
        {
            return new Size(size.Width * val, size.Height * val);
        }

        public static Size operator /(Size size, int val)
        {
            return new Size(size.Width / val, size.Height / val);
        }

        public override string ToString()
        {
            return $"width - {Width}, height - {Height}";
        }
    }
}
