using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using SoAt.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);

var jwtConfig = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig["Issuer"],
            ValidAudience = jwtConfig["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtConfig["Key"]!)),
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        var origins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? [];
        policy.WithOrigins(origins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Init sc core library
sc.log.init(app.Services.GetRequiredService<ILoggerFactory>());
sc.app.init(builder.Configuration);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Startup order:
//   1. EF Core migrations  — create/update si_security_* tables
//   2. Deployers            — create Oracle-migrated tables, functions, triggers, views
//   3. Seeder               — seed data (Oracle tables must exist before seeder checks them)
using (var scope = app.Services.CreateScope())
{
    var db     = scope.ServiceProvider.GetRequiredService<SoAt.Infrastructure.Persistence.AppDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    await db.Database.MigrateAsync();
    await SoAt.Infrastructure.Persistence.TableDeployer.DeployAsync(builder.Configuration, logger);
    await SoAt.Infrastructure.Persistence.FunctionDeployer.DeployAsync(builder.Configuration, logger);
    await SoAt.Infrastructure.Persistence.TriggerDeployer.DeployAsync(builder.Configuration, logger);
    await SoAt.Infrastructure.Persistence.ViewDeployer.DeployAsync(builder.Configuration, logger);
    await SoAt.Infrastructure.Persistence.DatabaseSeeder.SeedAsync(db, builder.Configuration);
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
