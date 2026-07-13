using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Extensions;
using SoAt.Infrastructure;
using scEstate.Components;

var builder = WebApplication.CreateBuilder(args);

// ── Blazor Server ───────────────────────────────────────────────
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ── DevExpress Blazor (theme link อยู่ที่ App.razor, ค่าจาก appsettings "DevExpress:Theme") ──
//   25.2 ใช้ Bootstrap 5 เป็น default ตัวเดียว (BootstrapVersion option ถูก deprecated แล้ว)
builder.Services.AddDevExpressBlazor();

// ── Backend services (sc.dbFactory, AppDbContext, application services) ──
//   module ไม่รัน deployers — scCenter เป็นคน deploy DB
builder.Services.AddInfrastructure(builder.Configuration);

// ── Shared cookie auth — อ่าน cookie ที่ scCenter เซ็น (key ring เดียวกัน) ──
var keysDir = builder.Configuration["DataProtection:KeyRingPath"];
if (string.IsNullOrEmpty(keysDir))
    keysDir = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SoAt", "keys");
Directory.CreateDirectory(keysDir);
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysDir))
    .SetApplicationName("SoAt");

var scCenterUrl = builder.Configuration["ScCenter:Url"] ?? "http://localhost:5100";
var cookieHours = builder.Configuration.GetValue("Auth:CookieExpireHours", 8);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name       = "SoAt.Auth";
        options.Cookie.HttpOnly   = true;
        options.ExpireTimeSpan    = TimeSpan.FromHours(cookieHours);
        options.SlidingExpiration = true;

        // ยังไม่ login → เด้งไปหน้า login ของ scCenter พร้อม returnUrl กลับมา module
        options.Events.OnRedirectToLogin = ctx =>
        {
            var returnUrl = ctx.Request.GetEncodedUrl();
            ctx.Response.Redirect($"{scCenterUrl}/?returnUrl={Uri.EscapeDataString(returnUrl)}");
            return Task.CompletedTask;
        };
    });

// ทั้ง module ต้อง login ก่อน (fallback policy)
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// ── Init sc core library ────────────────────────────────────────
// file sink: logs\scEstate-{yyyyMMdd}.txt ที่ root solution (ตาม legacy sc\log.cs เขียน {pathSolution}\logs)
sc.log.init(app.Services.GetRequiredService<ILoggerFactory>(),
    builder.Environment.ApplicationName,
    Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "logs")));
sc.app.init(builder.Configuration);

// ── HTTP pipeline ───────────────────────────────────────────────
// Sub-path hosting: IIS sub-application sets PathBase automatically.
// "PathBase" config is for testing sub-path outside IIS (dev/YARP); empty = root.
var pathBase = builder.Configuration["PathBase"];
if (!string.IsNullOrEmpty(pathBase))
    app.UsePathBase(pathBase);

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

// ── Logout endpoint (cookie sign-out — ใช้ key ring ร่วม) ───────
app.MapPost("/logout", async (HttpContext http) =>
{
    await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect($"{scCenterUrl}/");
}).AllowAnonymous();

app.Run();
