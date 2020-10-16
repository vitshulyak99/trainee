using System;
using Task_3.Entities;
using Task_3.Entities.Attributes;
using Task_3.Entities.Shapes;
using Task_3.UserInterface;

/*
 * Задание 3.

Создайте класс Point { x: int; y: int}

Создайте базовый класс Shape с базовыми свойствами ind Id, Point topLeftPosition,и методами Size rectangleSize, double GetSquare и double GetPerimiter
Создайте класссы-имплементации Shape: 
Rectangle c конструктором (Point topLeftPosition, Size size), 
Circle  с конструктором () Point: center, Radius: r) 
IsoscelesTriangle (равнобедренный треугольник) с конструктором (Point topLeftPosition, int base, int height )

Создайте Generic класс ShapeTransformer, где T должен иметь тип Shape
Класс ShapeTransformer должен иметь методы:
Shape AddShapeSize(Shape shape, int addition) - прибавляет к Size/Radius/base-height указанное число
Shape ReduceShapeSize(Shape shape, int subsraction) - отнимает от Size/Radius/base-height указанное число
Shape IncreaseShapeSize(Shape shape, int multiplier) - умножает Size/Radius/base-height на указанное число
Shape DecreaseShapeSize(Shape shape, int delimeter) - делит Size/Radius/base-height на указанное число
Position MoveShape(Shape shape, Point deltaPosition) прибавляет deltaPosition к текущей позиции, числа внутри deltaPosition могут быть отрицательными

Также должны быть следующие события
ShapePerimeterIsTooBig //срабатывает, если после AddShapeSize GetPerimeter возвращает число, больше 100
ShapePerimeterIsTooSmall //срабатывает, если после RemoveShapeSize GetMerimeter возвращает число, меньше 10
ShapeSquareIsTooBig //срабатывает, если после IncreaseShapeSize GetSquare возвращает число, больше 500
ShapeSquareIsTooSmall //срабатывает, если после DecreaseShapeSize GetSquare возвращает число, меньше 50
ShapeMovedToOutOfBounds //срабатывает, если после перемещения SHape x или y меньше 0 или больше 1000. Если такое случилось - то x или y становятся 0 или 1000


Создать класс ShapeArtboard
В нём нужно будет хранить список Shape и совершать операции с этими Shape

Создать меотды для добавления Shape (пользователь вводит ShapeId, Shape type, Другие нужные параметры), удаления Shape, ResizeShape (работа с AddShapeSize/ReduceSHapeSize), ScaleShape (работа с IncreaseShapeSize/DecreaseShapeSize), MoveShape

Создайте класс UI. Весь ввод-вывод информации, а также парсинг значений, осуществлять в нём

После каждой завершённой операции выводить список Shape на экран, в формате "[ShapeType] shape with [ShapeId] has following parameters: Position - [Position,] Size - [Size], Perimeter - [Perimeter], Square - [Square]
Операция может проходить в несколько этапов ввода информации. 

Меню примерно такое:

0 - Exit
1 - Add Shape
2 - Remove Shape
3 - Resize shape
4 - Scale Shape
5 - Move Shape
*/
namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {

            UI ui = new UI(new ShapeArtboard());

            ui.Menu();

        }
    }
}
