using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SoAt.Domain.Entities.Common;
using SoAt.Domain.Entities.Fin;
using SoAt.Domain.Entities.Mem;
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

    // ── Mem module — UCF / Lookup tables ─────────────────────────────────────
    public DbSet<ScMemMUcfPrename>          ScMemMUcfPrenames         => Set<ScMemMUcfPrename>();
    public DbSet<ScMemMUcfMemberType>       ScMemMUcfMemberTypes      => Set<ScMemMUcfMemberType>();
    public DbSet<ScMemMUcfMemberGroup>      ScMemMUcfMemberGroups     => Set<ScMemMUcfMemberGroup>();
    public DbSet<ScMemMUcfElectionGroup>    ScMemMUcfElectionGroups   => Set<ScMemMUcfElectionGroup>();
    public DbSet<ScMemMUcfNationality>      ScMemMUcfNationalities    => Set<ScMemMUcfNationality>();
    public DbSet<ScMemMUcfMarriageStatus>   ScMemMUcfMarriageStatuses => Set<ScMemMUcfMarriageStatus>();
    public DbSet<ScMemMUcfBlood>            ScMemMUcfBloods           => Set<ScMemMUcfBlood>();
    public DbSet<ScMemMUcfProvince>         ScMemMUcfProvinces        => Set<ScMemMUcfProvince>();
    public DbSet<ScMemMUcfDistrict>         ScMemMUcfDistricts        => Set<ScMemMUcfDistrict>();
    public DbSet<ScMemMUcfSubdistrict>      ScMemMUcfSubdistricts     => Set<ScMemMUcfSubdistrict>();
    public DbSet<ScMemMUcfApplicationType>  ScMemMUcfApplicationTypes => Set<ScMemMUcfApplicationType>();
    public DbSet<ScMemMUcfConcern>          ScMemMUcfConcerns         => Set<ScMemMUcfConcern>();
    public DbSet<ScMemMUcfGroupPosition>    ScMemMUcfGroupPositions   => Set<ScMemMUcfGroupPosition>();
    public DbSet<ScMemMUcfPosition>         ScMemMUcfPositions        => Set<ScMemMUcfPosition>();
    public DbSet<ScCntMCoop>                ScCntMCoops               => Set<ScCntMCoop>();

    // ── Mem module — Transaction tables (sctelnewbma) ─────────────────────────
    public DbSet<ScMemMApplicationForm>  ScMemMApplicationForms  => Set<ScMemMApplicationForm>();
    public DbSet<ScMemMAppAddress>       ScMemMAppAddresses      => Set<ScMemMAppAddress>();
    public DbSet<ScMemMAppWorkInfo>      ScMemMAppWorkInfos      => Set<ScMemMAppWorkInfo>();
    public DbSet<ScMemMAppShare>         ScMemMAppShares         => Set<ScMemMAppShare>();
    public DbSet<ScMemMAppMemberRefer>   ScMemMAppMemberRefers   => Set<ScMemMAppMemberRefer>();
    public DbSet<ScMemMAppRecrieveGain>  ScMemMAppRecrieveGains  => Set<ScMemMAppRecrieveGain>();
    public DbSet<ScMemMAppPicture>       ScMemMAppPictures       => Set<ScMemMAppPicture>();
    public DbSet<ScMemMAppSignature>     ScMemMAppSignatures     => Set<ScMemMAppSignature>();

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
