using Models.Shapes;
using System;
using Utils.Enums;

namespace Services.Calculators.Base
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
                    throw new ArgumentException();

            }
        }
    }
}
