using System;
using System.Collections.Generic;
using System.Linq;

using Task_3.Entities.Shapes.Base;
using Task_3.Transformer;

namespace Task_3.Entities
{
    class ShapeArtboard
    {
        public List<Shape> Shapes { get; } = new List<Shape>();

        public void Add(Shape shape) => Shapes.Add(shape ?? throw new ArgumentNullException(nameof(shape)));

        public void Display(int id) => Console.WriteLine(Shapes.FirstOrDefault(s => s.Id == id));

        public void Display() => Shapes.ForEach(s => Console.WriteLine(s.ToString()));

        internal void Remove(int id)
        {
            var index = Shapes.FindIndex(s => s.Id == id);

            if (index != -1)
            {
                Shapes.RemoveAt(index);
            }
            else
                throw new Exception("Invalid Id");
        }

        internal void Resize(int id, int val)
        {
            var index = Shapes.FindIndex(s => s.Id == id);

            if (index != -1)
            {
                Shapes[index] = val < 0 ?
                     ShapeTransformer<Shape>.ReduceShapeSize(Shapes[index], val) :
                     ShapeTransformer<Shape>.AddShapeSize(Shapes[index], val);
            }
            else
                throw new Exception("Invalid Id");
        }

        internal void Scale(int id, int val)
        {


            var index = Shapes.FindIndex(s => s.Id == id);

            if (index != -1)
            {
                Shapes[index] = val < 0 ?
                    ShapeTransformer<Shape>.DecreaseShapeSize(Shapes[index], val) :
                    ShapeTransformer<Shape>.IncreaseShapeSize(Shapes[index], val);
            }
            else
                throw new Exception("Invalid Id");
        }

        internal void Move(int id, int x, int y)
        {

            var index = Shapes.FindIndex(s => s.Id == id);

            if (index != -1)
            {
                Shapes[index] = ShapeTransformer<Shape>.MoveShape(Shapes[index], new Attributes.Point(x, y));             
            }
            else
                throw new Exception("Invalid Id");

        }


    }
}
