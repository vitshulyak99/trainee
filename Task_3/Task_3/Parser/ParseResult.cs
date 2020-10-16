using System;
using System.Collections.Generic;
using System.Text;
using Task_3.Entities.Shapes;

namespace Task_3.Parser
{
    class ParseResult
    {
        public ShapeType Type { get; set; }

        public int Ox { get; set; } = 0;

        public int Oy { get; set; } = 0;

        public int? Radius { get; set; }

        public int? Base { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

    }
}
