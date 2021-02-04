using Models.Shapes;
using Utils.Enums;
using Utils.Exceptions;

namespace Services.Calculators
{
    public class ShapeArea : IShapeArea
    {
        private readonly Shape _shape;
        public ShapeArea(Shape shape)
        {
            _shape = shape;
        }

        public double Area()
        {
            switch (_shape.Type)
            {
                case ShapeType.Triangle:
                    return new TriangleArea(_shape).Area();
                case ShapeType.Circle:
                    return new CircleArea(_shape).Area();
                default:
                    throw new BadRequestException();

            }
        }
    }
}
