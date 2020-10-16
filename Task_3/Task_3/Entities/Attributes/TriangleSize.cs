using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Entities.Attributes
{
   public class TriangleSize : Size
    {
        public TriangleSize(int @base = 6, int height = 4) : base(@base, height)
        {
        }

        public override string ToString()
        {
            return $"base - {Width}, height - {Height}";
        }
    }
}
