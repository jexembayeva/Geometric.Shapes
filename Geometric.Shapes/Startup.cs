using Database;
using Geometric.Shapes.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web;

namespace Geometric.Shapes
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews();

            DatabaseConfig.Setup(services, Configuration, Environment.IsDevelopment());

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(SwaggerConfig.Apply);

            ServiceRegistration.Setup(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(SwaggerConfig.ApplyUI);

        }
    }
}
