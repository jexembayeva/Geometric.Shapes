using System;
using Utils.Enums;
using Models.Shapes;
using Services.Calculators.Base;
using Utils.Helpers;

namespace Services.Calculators
{
    public class TriangleArea : IShapeArea
    {
        private readonly double x;

        private readonly double y;

        private readonly double z;
        public TriangleArea(Shape shape)
        {
            shape.X.ThrowIfNull(nameof(shape.X));
            shape.Y.ThrowIfNull(nameof(shape.Y));
            shape.Z.ThrowIfNull(nameof(shape.Z));

            if (shape.Type == ShapeType.Triangle)
            {
                x = shape.X.Value;
                y = shape.Y.Value;
                z = shape.Z.Value;
            }
            else
            {
                throw new ArgumentException($"Shape type is not Triangle.");
            }
        }

        public double Area()
        {
            var s = (x + y + z) / 2;

            return Math.Round(Math.Sqrt(s * (s - x) * (s - y) * (s - z)), 2);
        }
    }
}
