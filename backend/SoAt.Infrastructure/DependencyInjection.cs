using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoAt.Application.Auth;
using SoAt.Application.Fin;
using SoAt.Application.Sc;
using SoAt.Application.ScTeller;
using SoAt.Infrastructure.Auth;
using SoAt.Infrastructure.Fin;
using SoAt.Infrastructure.Sc;
using SoAt.Infrastructure.ScTeller;
using SoAt.Infrastructure.Persistence;

namespace SoAt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")!;

        // EF Core — ใช้เฉพาะ Migrations + DatabaseSeeder (ไม่ใช้ใน service queries)
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        // sc.dbFactory — singleton, ทุก service ใช้ create() เพื่อสร้าง sc.db ต่อ request
        services.AddSingleton<sc.dbFactory>(_ => new sc.dbFactory(connectionString));

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IScAppService, ScAppService>();
        services.AddScoped<IFinDailyService, FinDailyService>();
        services.AddScoped<ISctelnewbmaService, SctelnewbmaService>();

        return services;
    }
}
