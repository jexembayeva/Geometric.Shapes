using Models.Shapes;
using Services.Dtos;

namespace Services.Facilities
{
    class CircleFacility : ShapeFacility
    {
        protected override Shape CreateShape(ShapeDto request)
        {
            return new Circle(
                radius: request.Radius);
        }
    }
}
