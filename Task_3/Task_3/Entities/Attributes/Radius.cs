
namespace Task_3.Entities.Attributes
{
    class Radius : Size
    {
        public Radius(int radius) : base(radius,radius)
        {

        }

        public override string ToString()
        {
            return $"radius - {Width}";
        }
    }
}
