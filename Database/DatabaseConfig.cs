using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static class DatabaseConfig
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services
                .AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("Database"));

                    options.ConfigureWarnings(w =>
                    {
                        if (!isDevelopment)
                        {
                            w.Ignore(RelationalEventId.MultipleCollectionIncludeWarning);
                        }
                    });
                });
        }
    }
}