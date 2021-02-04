using System;
using Utils.Enums;
using Utils.Exceptions;
using Models.Shapes;
using Services.Calculators.Base;

namespace Services.Calculators
{
    public class CircleArea : IShapeArea
    {
        private readonly double radius;
        public CircleArea(Shape shape)
        {
            if (shape.Type == ShapeType.Circle)
            {
                radius = shape.Radius.Value;
            }
            else
            {
                throw new BadRequestException();
            }
        }

        public double Area()
        {
            return Math.Round(Math.PI * radius * radius, 2);
        }
    }
}
