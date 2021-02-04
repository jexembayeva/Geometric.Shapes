using Models.Shapes;
using Services.Dtos;

namespace Services.Facilities
{
    abstract class ShapeFacility
    {
        public Shape GetShape(ShapeDto request)
        {
            Shape shape = CreateShape(request);
            return shape;
        }

        protected abstract Shape CreateShape(ShapeDto request);
    }
}
