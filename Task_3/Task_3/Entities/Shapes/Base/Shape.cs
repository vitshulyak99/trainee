/* 
Создайте базовый класс Shape с базовыми свойствами ind Id, Point topLeftPosition,и методами Size rectangleSize, double GetSquare и double GetPerimiter
Создайте класссы-имплементации Shape: 
Rectangle c конструктором (Point topLeftPosition, Size size), 
Circle  с конструктором () Point: center, Radius: r) 
IsoscelesTriangle (равнобедренный треугольник) с конструктором (Point topLeftPosition, int base, int height )
 */

using System;
using Task_3.Entities.Attributes;

namespace Task_3.Entities.Shapes.Base
{
    public abstract class Shape : ICloneable
    {
        public static int LastID { get; internal set; } = 0;
        abstract public int Id { get; set; }

        abstract public Point TopLeftPosition { get; set; }
       
        abstract public Size RectangleSize { get; set; }

        abstract public double Square { get; }

        abstract public double Perimeter { get; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{GetType().Name} shape with {Id} has following parameters:" +
                $"Position - {TopLeftPosition}, Size - {RectangleSize.ToString()}," +
                $" Perimeter - {Perimeter}, Square - {Square}\n";
        }
    }
}
