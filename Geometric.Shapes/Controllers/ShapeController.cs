using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Shapes;
using System.Threading.Tasks;

namespace Geometric.Shapes.Controllers
{
    [Route("api/shape")]
    [ApiController]
    public class ShapeController : ControllerBase
    {
        public readonly IShapeService _shapeService;
        public ShapeController(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        [HttpPost]
        public async Task<long> CreateAsync(ShapeDto rectangle)
        {
            return await _shapeService.CreateAsync(rectangle);
        }

        [HttpGet]
        public async Task<double> GetAreaByIdAsync(long id)
        {
            return await _shapeService.GetAreaByIdAsync(id);
        }
    }
}
