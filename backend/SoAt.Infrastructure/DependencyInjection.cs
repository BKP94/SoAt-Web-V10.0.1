using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoAt.Application.Auth;
using SoAt.Application.Fin;
using SoAt.Application.Sc;
using SoAt.Infrastructure.Auth;
using SoAt.Infrastructure.Fin;
using SoAt.Infrastructure.Sc;
using SoAt.Infrastructure.Persistence;

namespace SoAt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IDbConnectionFactory>(_ =>
            new NpgsqlConnectionFactory(connectionString!));

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IScAppService, ScAppService>();
        services.AddScoped<IFinDailyService, FinDailyService>();

        return services;
    }
}
