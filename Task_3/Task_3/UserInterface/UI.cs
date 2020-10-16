using System;
using Task_3.Parser;
using Task_3.Builder;
using Task_3.Entities.Shapes;
using Task_3.Entities.Shapes.Base;
using Task_3.Entities.Attributes;
using Task_3.Entities;

namespace Task_3.UserInterface
{
    class UI
    {
        ShapeArtboard _board = null;

        public UI(ShapeArtboard board)
        {
            _board = board ?? throw new ArgumentNullException(nameof(board));
        }

        public void Menu()
        {
            bool isEnd = false;
            while (!isEnd)
            {

                DisplayMenu();


                try
                {
                back:
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D0:
                            {
                                isEnd = true;
                            }
                            break;
                        case ConsoleKey.D1:
                            {
                                Add();
                            }
                            break;
                        case ConsoleKey.D2: 
                            {
                                Remove();
                            } break;
                        case ConsoleKey.D3: {
                                Resize();
                                    } break;
                        case ConsoleKey.D4: {
                                Scale();
                            } break;
                        case ConsoleKey.D5: { Console.Clear(); } break;
                        default:
                            {
                                Console.WriteLine("Incorrect input");
                                goto back;
                            }
                    }
                    DisplayAllShapes();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {

                    Wait(5);
                }

            }
        }

        /// <summary>
        /// Wait [x] seconds
        /// </summary>
        private void Wait(double x)
        {
            System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(x)).Wait();
        }

        private void DisplayMenu()
        {
            Console.WriteLine(
                "0 - exit\n" +
                "1 - add\n" + 
                "2 - remove\n" +
                "3 - resize\n" +
                "4 - scale\n" +
                "5 - clear window space");
        }

        private void DisplayAllShapes() => _board.Shapes.ForEach(s => Console.WriteLine(s.ToString()));

        private void ParsingInfoAdd()
        {
            Console.WriteLine(
                "\nall parameters separated by spaces\n" +
                "\npriority t->[p->]->s/r/its\nt:type \\\\t - shape type , type - (R - rectangle, - IT isosceles triangle, C - circle) " +
                "\np:x,y \\\\p - position, x - Ox, y - Oy. Default 0,0 " +
                "\ns:w,h \\\\s - rectangle size, w - width, h - height " +
                "\nr:l \\\\r -radius, l - lenght " +
                "\nits:b,h \\\\it - isosceles triangle " +
                "\n");
        }
        private void ParsingInfoRemove()
        {
            Console.WriteLine("\nid:value");
        }

        private void ParsingInfoResize()
        {
            Console.WriteLine("\nid:number rs:value");
        }

        private void ParsingInfoScale()
        {
            Console.WriteLine("\nid:number sc:value");
        }

        private void ParsingInfoMove()
        {
            Console.WriteLine("\nid:number mv:x,y");
        }

        private void Add()
        {
            ParsingInfoAdd();

            var parser = new StringParser();

            var line = Console.ReadLine();

            var result = parser.ParseAdd(line);
            Shape shape = null;

            switch (result.Type)
            {
                case ShapeType.Circle:
                    {
                        shape = ShapeTypeBuilder.Create<Circle>()
                            .SetPosition(result.Ox, result.Oy)
                            .Build(new Radius(result.Radius ?? throw new ArgumentNullException()));
                    }
                    break;
                case ShapeType.Rectangle:
                    {
                        shape = ShapeTypeBuilder.Create<Rectangle>()
                            .SetPosition(result.Ox, result.Oy)
                            .Build(new Size(result.Width ?? throw new ArgumentNullException(),
                            result.Height ?? throw new ArgumentNullException()));
                    }
                    break;
                case ShapeType.IsoscelesTriangle:
                    {
                        shape = ShapeTypeBuilder.Create<IsoscelesTriangle>()
                            .SetPosition(result.Ox, result.Oy)
                            .Build(new TriangleSize(result.Base ?? throw new ArgumentNullException(),
                            result.Height ?? throw new ArgumentNullException()));
                    }
                    break;
            }

            _board.Add(shape);
        }

        private void Remove()
        {
            ParsingInfoRemove();

            var parser = new StringParser();
            var line = Console.ReadLine();

            var id = parser.ParseRemove(line);

            _board.Remove(id);
        }

        private void Resize() 
        {
            ParsingInfoResize();
            var parser = new StringParser();

            var line = Console.ReadLine();
            var idAndVal = parser.ParseResizeScale(line);

            _board.Resize(idAndVal.id, idAndVal.val);

        }

        private void Scale()
        {
            ParsingInfoScale();

            var parser = new StringParser();

            var line = Console.ReadLine();
            var idAndVal = parser.ParseResizeScale(line);

            _board.Scale(idAndVal.id, idAndVal.val);

        }

        private void Move()
        {
            ParsingInfoMove();
            var parser = new StringParser();

            var line = Console.ReadLine();
            var idAndPoint = parser.ParseMove(line);

            _board.Move(idAndPoint.id, idAndPoint.point.x, idAndPoint.point.y);

        }
    }
}
