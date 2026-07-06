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

namespace SoAt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")!;

        // schema sc_* + si_security_* คุมที่ pgAdmin ทั้งหมด — ไม่มี EF Core/AppDbContext แล้ว
        //   query+CRUD ทุกอย่างผ่าน sc.db (Npgsql/Dapper ตรง)

        // sc.dbFactory — singleton, ทุก service ใช้ create() เพื่อสร้าง sc.db ต่อ request
        services.AddSingleton<sc.dbFactory>(_ => new sc.dbFactory(connectionString));

        // sc.save — central save engine (annotate DTO ด้วย [SaveTable]/[SaveKey]/... แล้วเรียก ofSaveAsync)
        services.AddSingleton<sc.save>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IScAppService, ScAppService>();
        services.AddScoped<IMemberFindService, MemberFindService>();
        services.AddScoped<IFinDailyService, FinDailyService>();
        services.AddScoped<ISctelnewbmaService, SctelnewbmaService>();
        services.AddScoped<IScteldetService, ScteldetService>();

        return services;
    }
}
