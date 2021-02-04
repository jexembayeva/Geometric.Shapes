using Services.Dtos;
using System.Threading.Tasks;

namespace Services.Shapes
{
    public interface IShapeService
    {
        public Task<long> CreateAsync(ShapeDto rectangle);

        Task<double> GetAreaByIdAsync(long id);
    }
}
