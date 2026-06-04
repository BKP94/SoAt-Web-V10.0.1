using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SoAt.Infrastructure;
using scCenter.Components;

var builder = WebApplication.CreateBuilder(args);

// ── Blazor Server ───────────────────────────────────────────────
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ── DevExpress Blazor (theme link อยู่ที่ App.razor, ค่าจาก appsettings "DevExpress:Theme") ──
//   25.2 ใช้ Bootstrap 5 เป็น default ตัวเดียว (BootstrapVersion option ถูก deprecated แล้ว)
builder.Services.AddDevExpressBlazor();

// ── Backend services (sc.dbFactory, AppDbContext, application services) ──
builder.Services.AddInfrastructure(builder.Configuration);

// ── Shared cookie auth (ข้าม app ได้: scCenter + module — ดู CLAUDE.md) ──
//   key ring ใช้ร่วมกันทุก app + cookie ชื่อเดียว → module อ่าน cookie ที่ scCenter เซ็นได้
var keysDir = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SoAt", "keys");
Directory.CreateDirectory(keysDir);
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysDir))
    .SetApplicationName("SoAt");

var cookieHours = builder.Configuration.GetValue("Auth:CookieExpireHours", 8);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name       = "SoAt.Auth";
        options.Cookie.HttpOnly   = true;
        // SameSite=Lax + Secure ตามสกีม → ปลอดภัยและไม่เด้ง warning เมื่อรันผ่าน HTTPS,
        //   ส่วน dev (http://localhost) ยังส่ง cookie ได้ปกติ
        options.Cookie.SameSite     = SameSiteMode.Lax;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.LoginPath         = "/login";
        options.LogoutPath        = "/logout";
        options.AccessDeniedPath  = "/login";
        options.ExpireTimeSpan    = TimeSpan.FromHours(cookieHours);
        options.SlidingExpiration = true;
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// antiforgery cookie — Secure ตามสกีมเช่นกัน (แก้ DevTools issue เรื่อง SameSite/HTTPS)
builder.Services.AddAntiforgery(o =>
{
    o.Cookie.SameSite     = SameSiteMode.Lax;
    o.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
});

var app = builder.Build();

// ── Init sc core library ────────────────────────────────────────
sc.log.init(app.Services.GetRequiredService<ILoggerFactory>());
sc.app.init(builder.Configuration);

// ── Database startup: EF migrations (app tables) → seeder (idempotent) ──
//   schema sc_* คุมที่ pgAdmin | scCenter เป็น host หลัก (module app ไม่รัน startup นี้)
using (var scope = app.Services.CreateScope())
{
    var db     = scope.ServiceProvider.GetRequiredService<SoAt.Infrastructure.Persistence.AppDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    // schema ของธุรกิจ (sc_*) จัดการที่ pgAdmin โดยตรง — ไม่มี SQL deployers แล้ว
    //   EF Migrations = table ของแอปเอง (si_security_*) | Seeder = ย้ายข้อมูลจาก Oracle (idempotent)
    await db.Database.MigrateAsync();
    await SoAt.Infrastructure.Persistence.DatabaseSeeder.SeedAsync(db, builder.Configuration);
}

// ── HTTP pipeline ───────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ── Logout endpoint (cookie sign-out) ───────────────────────────
app.MapPost("/logout", async (HttpContext http) =>
{
    await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/");
});

app.Run();
