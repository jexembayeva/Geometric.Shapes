using Database;
using Services.Dtos;
using Services.Shapes;
using System.Threading.Tasks;
using TestUtils;
using Utils.Enums;
using Xunit;

namespace Services.Test
{
    public class ShapeServiceTest
    {
        [Theory]
        [InlineData(ShapeType.Triangle, false, 10, 20, 15)]
        [InlineData(ShapeType.Triangle, false, 5, 4, 4)]
        [InlineData(ShapeType.Circle, true, null, null, null, 1)]
        [InlineData(ShapeType.Circle, true, null, null, null, 5)]
        [InlineData(ShapeType.Circle, true, null, null, null, 7)]
        public async Task CreateAsync_ValidData_OkAsync(ShapeType type, bool enable, long? x, long? y, long? z, long? radius = null)
        {
            await using var context = new SqliteContext();
            var target = new ShapeService(context);

            var request = new ShapeDto
            {
                Type = type,
                RadiusEnabled = enable,
                X = x,
                Y = y,
                Z = z,
                Radius = radius
            };
            var shape = await context.Shapes.ByIdOrFailAsync(await target.CreateAsync(request));

            Assert.Equal(x, shape.X);
            Assert.Equal(y, shape.Y);
            Assert.Equal(z, shape.Z);
            Assert.Equal(radius, shape.Radius);
        }

        [Theory]
        [InlineData(ShapeType.Triangle, false, 7, 6, 8, null, 20.33)]
        [InlineData(ShapeType.Triangle, false, 11, 12, 5, null, 27.5)]
        [InlineData(ShapeType.Circle, true, null, null, null, 1, 3.14)]
        [InlineData(ShapeType.Circle, true, null, null, null, 5, 78.54)]
        [InlineData(ShapeType.Circle, true, null, null, null, 7, 153.94)]
        public async Task GetAreaByIdAsync_ValidData_OkAsync(ShapeType type, bool enable, long? x, long? y, long? z, long? radius, double expected)
        {
            await using var context = new SqliteContext();
            var target = new ShapeService(context);

            var rectangle = new ShapeDto
            {
                Type = type,
                RadiusEnabled = enable,
                X = x,
                Y = y,
                Z = z,
                Radius = radius
            };
            var shapeId = await target.CreateAsync(rectangle);

            var area = await target.GetAreaByIdAsync(shapeId);

            Assert.Equal(expected, area);
        }
    }
}
