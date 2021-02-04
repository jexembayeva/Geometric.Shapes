using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Shapes;

namespace Geometric.Shapes.Config
{
    public class ServiceRegistration
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IShapeService, ShapeService>();
        }
    }
}
