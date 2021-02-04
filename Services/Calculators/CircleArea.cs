using System;
using Utils.Enums;
using Models.Shapes;
using Services.Calculators.Base;
using Utils.Helpers;

namespace Services.Calculators
{
    public class CircleArea : IShapeArea
    {
        private readonly double radius;
        public CircleArea(Shape shape)
        {
            if (shape.Type == ShapeType.Circle)
            {
                shape.Radius.ThrowIfNull(nameof(shape.Radius));

                radius = shape.Radius.Value;
            }
            else
            {
                throw new ArgumentException($"Shape type is not Circle.");
            }
        }

        public double Area()
        {
            return Math.Round(Math.PI * radius * radius, 2);
        }
    }
}
