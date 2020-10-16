using System;
using System.Text.RegularExpressions;

namespace Task_3.Parser
{
    class StringParser
    {
        public StringParser()
        {

        }

        public ParseResult ParseAdd(string line="")
        {
            ParseResult result = new ParseResult();

            if (line == "")
                throw new Exception("String for parse is empty");
            else
            {
                int indexType = 0,
                    indexPosition = 1,
                    indexSize = 2;

                var commands = line.Split(' ');

                if (!commands[indexType].StartsWith("t:")) throw new ArgumentException("invalid input string", "t:type");

                var type = commands[indexType].Split(':')[1];
                
                if(line.Contains("p:"))
                    (result.Ox, result.Oy) = GetPositionOrSize(commands[1]);
                else
                {
                    result.Ox = 0;
                    result.Oy = 0;
                    indexSize--;
                }

                switch (type)
                {
                    case "R":
                        {
                            result.Type = Entities.Shapes.ShapeType.Rectangle;

                            if (commands[indexSize].StartsWith("s:"))
                            {
                                (result.Width, result.Height) = GetPositionOrSize(commands[indexSize]);
                            }
                            else
                                throw new ArgumentException("invalid size value");

                            
                        }
                        break;
                    case "IT":
                        {
                            result.Type = Entities.Shapes.ShapeType.IsoscelesTriangle;

                            if (commands[indexSize].StartsWith("its:"))
                            {
                                
                                (result.Base, result.Height) = GetPositionOrSize(commands[indexSize]); 
                            }
                            else
                                throw new ArgumentException("invalid size value");

                        }
                        break;
                    case "C":
                        {
                            result.Type = Entities.Shapes.ShapeType.Circle;

                            if (commands[indexSize].StartsWith("r:"))
                            {
                                
                                result.Radius = GetSingleNumber(commands[indexSize]);
                                
                            }
                            else
                                throw new ArgumentException("invalid size value");

                        }
                        break;
                    default: break;
                }


            }

            return result;
        }

        internal int ParseRemove(string line)
        {
            var valid = new Regex(@"^id:\d+$").IsMatch(line);

            if (valid)
            {
                return GetSingleNumber(line);
            }
            else throw new ArgumentException("invalid parameter", nameof(line));
        }

        internal (int id,int val) ParseResizeScale(string line)
        {
            var valid = new Regex(@"^id:\d+\s(rs|sc):-?\d+").IsMatch(line);

            if (valid)
            {
                var args = line.Split(' ');

                return (GetSingleNumber(args[0]), GetSingleNumber(args[1]));
            }
            else throw new ArgumentException("invalid parameter",nameof(line));
        }

        internal (int id , (int x, int y) point) ParseMove(string line)
        {
            var valid = new Regex(@"^id:\d+\smv:-?\d+,-?\d+").IsMatch(line);
            if (valid)
            {
                var args = line.Split(' ');

                return (GetSingleNumber(args[0]), GetPositionOrSize(args[1]));
            }
            else throw new ArgumentException("invalid parameter", nameof(line));
        }

        private (int x,int y) GetPositionOrSize(string s)
        {
            var position = s.Split(':')[1].Split(',');

            return (int.Parse(position[0]) , int.Parse(position[1]));
        }

        private int GetSingleNumber(string s)
        {
            var single = s.Split(':')[1];

            return int.Parse(single);

        }
    }
}
