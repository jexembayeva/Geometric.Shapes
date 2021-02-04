using Models.Shapes;
using System;
using Utils.Enums;
using Utils.Exceptions;

namespace Services.Calculators
{
    public class TriangleArea : IShapeArea
    {
        private readonly double x;

        private readonly double y;

        private readonly double z;
        public TriangleArea(Shape shape)
        {
            if (shape.Type == ShapeType.Triangle)
            {
                x = shape.X.Value;
                y = shape.Y.Value;
                z = shape.Z.Value;
            }
            else
            {
                throw new BadRequestException();
            }
        }

        public double Area()
        {
            var s = (x + y + z) / 2;

            return Math.Round(Math.Sqrt(s * (s - x) * (s - y) * (s - z)), 2);
        }
    }
}
