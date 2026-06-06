using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Extensions;
using SoAt.Infrastructure;
using scFund.Components;

var builder = WebApplication.CreateBuilder(args);

// โ”€โ”€ Blazor Server โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// โ”€โ”€ DevExpress Blazor (theme link เธญเธขเธนเนเธ—เธตเน App.razor, เธเนเธฒเธเธฒเธ appsettings "DevExpress:Theme") โ”€โ”€
//   25.2 เนเธเน Bootstrap 5 เน€เธเนเธ default เธ•เธฑเธงเน€เธ”เธตเธขเธง (BootstrapVersion option เธ–เธนเธ deprecated เนเธฅเนเธง)
builder.Services.AddDevExpressBlazor();

// โ”€โ”€ Backend services (sc.dbFactory, AppDbContext, application services) โ”€โ”€
//   module เนเธกเนเธฃเธฑเธ deployers โ€” scCenter เน€เธเนเธเธเธ deploy DB
builder.Services.AddInfrastructure(builder.Configuration);

// โ”€โ”€ Shared cookie auth โ€” เธญเนเธฒเธ cookie เธ—เธตเน scCenter เน€เธเนเธ (key ring เน€เธ”เธตเธขเธงเธเธฑเธ) โ”€โ”€
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

        // เธขเธฑเธเนเธกเน login โ’ เน€เธ”เนเธเนเธเธซเธเนเธฒ login เธเธญเธ scCenter เธเธฃเนเธญเธก returnUrl เธเธฅเธฑเธเธกเธฒ module
        options.Events.OnRedirectToLogin = ctx =>
        {
            var returnUrl = ctx.Request.GetEncodedUrl();
            ctx.Response.Redirect($"{scCenterUrl}/?returnUrl={Uri.EscapeDataString(returnUrl)}");
            return Task.CompletedTask;
        };
    });

// เธ—เธฑเนเธ module เธ•เนเธญเธ login เธเนเธญเธ (fallback policy)
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// โ”€โ”€ Init sc core library โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€
sc.log.init(app.Services.GetRequiredService<ILoggerFactory>());
sc.app.init(builder.Configuration);

// โ”€โ”€ HTTP pipeline โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€โ”€
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

// โ”€โ”€ Logout endpoint (cookie sign-out โ€” เนเธเน key ring เธฃเนเธงเธก) โ”€โ”€โ”€โ”€โ”€โ”€โ”€
app.MapPost("/logout", async (HttpContext http) =>
{
    await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect($"{scCenterUrl}/");
}).AllowAnonymous();

app.Run();
