using Models.Shapes;
using Services.Dtos;

namespace Services.Facilities
{
    class PolygonFacility : ShapeFacility
    {
        protected override Shape CreateShape(ShapeDto request)
        {
            return new Triangle(
                x: request.X,
                y: request.Y,
                z: request.Z);
        }
    }
}
