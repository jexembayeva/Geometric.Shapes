using Models.Base;
using Utils.Attributes;
using Utils.Enums;

namespace Models.Shapes
{
    public class Shape : BaseModel
    {
        protected Shape()
        {

        }

        public Shape(double radius)
        {
            Type = ShapeType.Circle;
            Radius = radius;
        }

        public Shape(double x, double y, double z)
        {
            Type = ShapeType.Triangle;
            X = x;
            Y = y;
            Z = z;
        }

        [NotDefaultValue]
        public ShapeType Type { get; set; }

        public double? Radius { get; set; }

        [NotDefaultValue]
        public double? X { get; set; }

        [NotDefaultValue]
        public double? Y { get; set; }

        [NotDefaultValue]
        public double? Z { get; set; }
    }
}
