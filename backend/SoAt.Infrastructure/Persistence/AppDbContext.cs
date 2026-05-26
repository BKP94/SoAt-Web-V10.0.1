using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SoAt.Domain.Entities.Common;
using SoAt.Domain.Entities.Fin;
using SoAt.Domain.Entities.System;

namespace SoAt.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SiSecurityApp> SiSecurityApps => Set<SiSecurityApp>();
    public DbSet<SiSecurityUser> SiSecurityUsers => Set<SiSecurityUser>();

    // ── Common ───────────────────────────────────────────────────────────────
    public DbSet<ScComMBranch> ScComMBranches => Set<ScComMBranch>();

    // ── Finance module ────────────────────────────────────────────────────────
    public DbSet<ScFinMConstant>   ScFinMConstants   => Set<ScFinMConstant>();
    public DbSet<ScFinJournalHead> ScFinJournalHeads => Set<ScFinJournalHead>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply explicit configurations first (ToTable / HasColumnName in each *Configuration.cs)
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Apply snake_case as fallback for anything not explicitly named
        // Matches Oracle convention: sc_mem_m_membership_registered, membership_no, etc.
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
