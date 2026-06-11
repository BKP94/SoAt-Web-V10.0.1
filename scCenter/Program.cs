using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoAt.Application.Auth;
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
//   IIS: แต่ละ app pool = คนละ identity → %LOCALAPPDATA% คนละ path → key ring แตก
//   ตั้ง "DataProtection:KeyRingPath" (appsettings.Production.json) ให้ทุก app ชี้ path กลางเดียวกัน
var keysDir = builder.Configuration["DataProtection:KeyRingPath"];
if (string.IsNullOrEmpty(keysDir))
    keysDir = Path.Combine(
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
        // login เป็น popup ที่ landing (/) เท่านั้น — ไม่มีหน้า /login แล้ว
        options.LoginPath         = "/";
        options.LogoutPath        = "/logout";
        options.AccessDeniedPath  = "/";
        options.ExpireTimeSpan    = TimeSpan.FromHours(cookieHours);
        options.SlidingExpiration = true;
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();   // login overlay (Home) อ่าน antiforgery token ตอน prerender

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

// ── Database startup: EF migrations (app tables) ────────────────
//   schema sc_* คุมที่ pgAdmin | scCenter เป็น host หลัก (module app ไม่รัน startup นี้)
//   data ทุกตาราง Oracle→PG ย้ายด้วย Block A migrator แล้ว → ถอด DatabaseSeeder ออก (2026-06-11)
//   ⚠️ si_security_apps/si_security_user = migrator ตั้งใจข้าม (schema app-managed คนละแบบ Oracle)
//      → ถ้า rebuild DB เปล่าจากศูนย์ ต้อง seed auth (user/menu) แยกต่างหาก
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SoAt.Infrastructure.Persistence.AppDbContext>();
    await db.Database.MigrateAsync();   // EF Migrations = table ของแอปเอง (si_security_*)
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

// ── Login endpoint (cookie sign-in) ─────────────────────────────
//   ที่เดียวที่ทำ authenticate + SignInAsync — ใช้โดย login overlay ที่
//   landing (Home). ต้อง POST แบบ form (antiforgery token).
app.MapPost("/auth/login", async (
    HttpContext http,
    IAuthService auth,
    IConfiguration config,
    [FromForm] string userId,
    [FromForm] string password,
    [FromForm] string? branchId,
    [FromForm] string? returnUrl) =>
{
    // กัน open-redirect: อนุญาตเฉพาะ path สัมพัทธ์ หรือ URL ที่อยู่ใน config "Modules" เท่านั้น
    var safeReturn = SafeReturnUrl(returnUrl, config);

    var user = await auth.AuthenticateAsync(new LoginCommand(userId, password, branchId));
    if (user is null)
    {
        var rt = safeReturn is null ? "" : $"&returnUrl={Uri.EscapeDataString(safeReturn)}";
        return Results.Redirect($"/?error=1{rt}");
    }

    var claims = new List<Claim>
    {
        new(ClaimTypes.NameIdentifier, user.UserId),
        new(ClaimTypes.Name, user.DisplayName),
        new("branch_id", user.BranchId),
    };
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    await http.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

    return Results.Redirect(safeReturn ?? "/");
});

// ── Logout endpoint (cookie sign-out) ───────────────────────────
app.MapPost("/logout", async (HttpContext http) =>
{
    await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/");
});

// returnUrl ปลอดภัย: path สัมพัทธ์ ("/...") หรือ absolute URL ที่ตรงกับ module ใน config "Modules"
static string? SafeReturnUrl(string? returnUrl, IConfiguration config)
{
    if (string.IsNullOrWhiteSpace(returnUrl)) return null;
    if (returnUrl.StartsWith('/') && !returnUrl.StartsWith("//")) return returnUrl;   // relative path

    var modules = config.GetSection("Modules").GetChildren().Select(m => m.Value);
    foreach (var url in modules)
    {
        if (string.IsNullOrWhiteSpace(url)) continue;
        if (returnUrl.Equals(url, StringComparison.OrdinalIgnoreCase)
         || returnUrl.StartsWith(url.TrimEnd('/') + "/", StringComparison.OrdinalIgnoreCase))
            return returnUrl;
    }
    return null;   // ไม่อยู่ใน allowlist → ทิ้ง
}

app.Run();
