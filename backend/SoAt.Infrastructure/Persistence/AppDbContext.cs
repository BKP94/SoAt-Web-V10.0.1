using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SoAt.Domain.Entities.System;

namespace SoAt.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SiSecurityApp>  SiSecurityApps  => Set<SiSecurityApp>();
    public DbSet<SiSecurityUser> SiSecurityUsers => Set<SiSecurityUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (tableName is not null && !tableName.Contains('_'))
                entity.SetTableName(ToSnakeCase(tableName));

            foreach (var prop in entity.GetProperties())
            {
                var colName = prop.GetColumnName();
                if (colName is not null && !colName.Contains('_'))
                    prop.SetColumnName(ToSnakeCase(colName));
            }
        }

        base.OnModelCreating(modelBuilder);
    }

    public static string ToSnakeCase(string name) =>
        Regex.Replace(name, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
}
