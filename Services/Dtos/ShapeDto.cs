using Models.Attributes;
using Models.Shapes;
using Utils.Attributes;
using Utils.Enums;
using Utils.Exceptions;

namespace Services.Dtos
{
    public class ShapeDto
    {

        [NotDefaultValue]
        public ShapeType Type { get; set; }

        public bool RadiusEnabled { get; set; }

        [NotDefaultValue]
        [RequiredIfRadiusEnabled(nameof(RadiusEnabled))]
        public double? Radius { get; set; }

        [NotDefaultValue]
        [RequiredIfRadiusDisabled(nameof(RadiusEnabled))]
        public double? X { get; set; }

        [NotDefaultValue]
        [RequiredIfRadiusDisabled(nameof(RadiusEnabled))]
        public double? Y { get; set; }

        [NotDefaultValue]
        [RequiredIfRadiusDisabled(nameof(RadiusEnabled))]
        public double? Z { get; set; }

        public Shape NewShapeOrThrowIfInvalid()
        {
            switch (Type)
            {
                case ShapeType.Circle:
                    return new Shape(Radius.Value);

                case ShapeType.Triangle:
                    return new Shape(X.Value, Y.Value, Z.Value);

                default:
                    throw new BadRequestException("Shape type is not valid");

            };
        }
    }
}
