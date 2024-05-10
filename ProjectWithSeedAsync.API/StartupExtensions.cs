using Microsoft.EntityFrameworkCore;
using ProjectWithSeedAsync.Domain;
using ProjectWithSeedAsync.Domain.Queries._City;
using ProjectWithSeedAsync.Domain.Queries._Country;
using ProjectWithSeedAsync.Domain.Queries._State;
using ProjectWithSeedAsync.Infrastructure;
using ProjectWithSeedAsync.Infrastructure.Data;
using ProjectWithSeedAsync.Infrastructure.Queries._City;
using ProjectWithSeedAsync.Infrastructure.Queries._Country;
using ProjectWithSeedAsync.Infrastructure.Queries._State;
using System.Reflection;

namespace ProjectWithSeedAsync.API
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CityStateCountryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CityStateCountryConnection") ??
                throw new InvalidOperationException("Connection string 'CityStateCountryConnection' not found ")));
            services.AddTransient<IRepository, BaseRepository>();
            services.AddTransient<IGetCityQuery, GetCityQuery>();
            services.AddTransient<IGetCountryOuery, GetCountryQuery>();
            services.AddTransient<IGetStateQuery, GetStateQuery>();

            return services;
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
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
        }
    }
}
