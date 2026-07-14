using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoAt.Application.Auth;
using SoAt.Application.Fin;
using SoAt.Application.Sc;
using SoAt.Application.ScKeeping;
using SoAt.Application.ScTeller;
using SoAt.Infrastructure.Auth;
using SoAt.Infrastructure.Fin;
using SoAt.Infrastructure.Sc;
using SoAt.Infrastructure.ScKeeping;
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

        // sc.appUser — ambient current-user ต่อ circuit (แทน legacy sc.app.loginUser Session var)
        //   เซ็ตค่าจาก cookie claims โดย AppUserCircuitHandler ก่อนทุก inbound activity
        services.AddScoped<sc.appUser>();

        // sc.dbFactory — Scoped (เดิม Singleton): inject scoped sc.appUser เพื่อ fallback loginId/loginBr
        //   ให้ create() ที่ไม่ส่ง user (read service ~150 จุด) → programmer log gate + SET LOCAL ทำงานครบ
        //   cache programmer เป็น static ใน dbFactory → ไม่เสีย perf จากการเปลี่ยน lifetime
        services.AddScoped<sc.dbFactory>(sp =>
            new sc.dbFactory(connectionString, sp.GetRequiredService<sc.appUser>()));

        // sc.save — central save engine (annotate DTO ด้วย [SaveTable]/[SaveKey]/... แล้วเรียก ofSaveAsync)
        //   Scoped ตาม dbFactory (inject dbFactory ที่เป็น scoped แล้ว — เลี่ยง captive dependency); _plans เป็น static
        services.AddScoped<sc.save>();

        // ambient current-user hook — เซ็ต sc.appUser จาก claims ต่อ circuit (module ทุกตัวได้ผ่าน AddInfrastructure)
        services.AddScoped<Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler, AppUserCircuitHandler>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IScAppService, ScAppService>();
        services.AddScoped<IMemberFindService, MemberFindService>();
        services.AddScoped<IFinDailyService, FinDailyService>();
        services.AddScoped<ISctelnewbmaService, SctelnewbmaService>();
        services.AddScoped<IScteldetService, ScteldetService>();
        services.AddScoped<ISckepmpmProcessService, SckepmpmProcessService>();

        return services;
    }
}
