using Database;
using Services.Calculators;
using Services.Dtos;
using System.Threading.Tasks;
using Utils.Helpers;
using Utils.Validators;

namespace Services.Shapes
{
    public class ShapeService : IShapeService
    {
        private readonly DatabaseContext _context;

        public ShapeService(DatabaseContext context)
        {
            _context = context;

        }
        public async Task<long> CreateAsync(ShapeDto request)
        {
            request.ThrowIfNull(nameof(request));
            request.ThrowIfInvalid();

            var shape = request.NewShapeOrThrowIfInvalid();

            var entity = await _context.AddEntityAsync(shape);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<double> GetAreaByIdAsync(long id)
        {
            var shape = await _context.Shapes.ByIdOrFailAsync(id);

            return new ShapeArea(shape).Area();
        }
    }
}
