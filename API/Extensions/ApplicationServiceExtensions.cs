using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {

        // Add the DB contexto to our services list
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite( // This method comes from the EntityFrameworkCore.Sqlite NuGet
                config.GetConnectionString("DefaultConnection")
            );
        });

        // Add the CORS policy to enable the clients to consume the API endpoints
        services.AddCors();

        // JWT configuration
        services.AddScoped<ITokenService, TokenService>();
        // Add this to make the repository injectable
        services.AddScoped<IUserRepository, UserRepository>();
        // Automapper's own configuration
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
