
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ProjectWithSeedAsync.API;

namespace MyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Define the startup class that configures services and middleware
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/*using ProjectWithSeedAsync.API;

var builder = WebApplication.CreateBuilder(args);

// Register services and dependencies here
builder.Services.AddControllers();

// Add other services such as Swagger, CORS, etc.
builder.Services.AddSwaggerGen();

// Add application and infrastructure services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();


*/


