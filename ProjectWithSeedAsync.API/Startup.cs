using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectWithSeedAsync.Infrastructure.Data;
using System.Reflection;

namespace ProjectWithSeedAsync.API
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureSevices(IServiceCollection services)
        {
            // Add services to the DI container
            services.AddControllers();
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);
            // Add other services like logging, CORS, etc.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });

                // Add other Swagger options here, such as comments, security schemes, etc.
            });

            // You might add other configurations like database context 

            services.ConfigureCors();/*
            services.AddAuthorization();*/
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                c.RoutePrefix = string.Empty; // Optional: Set the root URL of the app to the Swagger UI
            });
            // Middleware setup
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
