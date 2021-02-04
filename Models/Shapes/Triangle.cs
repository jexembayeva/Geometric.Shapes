using Models.Shapes;

namespace Services.Facilities
{
    internal class Triangle : Shape
    {
        public Triangle(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}