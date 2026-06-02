using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace SoAt.Infrastructure.Persistence;

/// <summary>
/// Deploy PostgreSQL tables จาก Database/Tables/**/*.sql ทุกครั้งที่ start
/// ใช้ CREATE TABLE IF NOT EXISTS → safe รันซ้ำได้เสมอ (patch อัตโนมัติถ้า ora2pg ไม่ใส่ IF NOT EXISTS)
/// z_fk_constraints.sql รันหลังสุด (FK ต้องการ table ทั้งหมดมาก่อน)
/// ต้องรันก่อน FunctionDeployer / TriggerDeployer / ViewDeployer
/// </summary>
public static class TableDeployer
{
    private static readonly Regex _createTable = new(
        @"CREATE TABLE\s+(?!IF\s+NOT\s+EXISTS\s)",
        RegexOptions.IgnoreCase | RegexOptions.Compiled
    );

    // Split SQL into individual statements (by semicolon, ignoring those inside strings/comments)
    private static readonly Regex _stmtSplit = new(
        @";\s*(?=(?:[^']*'[^']*')*[^']*$)",
        RegexOptions.Multiline | RegexOptions.Compiled
    );

    public static async Task DeployAsync(IConfiguration config, ILogger logger)
    {
        var projectRoot = FindProjectRoot(AppContext.BaseDirectory);
        var tableRoot   = Path.Combine(projectRoot, "Database", "Tables");

        if (!Directory.Exists(tableRoot))
        {
            logger.LogWarning("TableDeployer: ไม่พบ {Path}", tableRoot);
            return;
        }

        var sqlFiles = Directory.GetFiles(tableRoot, "*.sql", SearchOption.AllDirectories)
                                .Where(f => !f.EndsWith(".gitkeep"))
                                .OrderBy(f => f)
                                .ToArray();

        if (sqlFiles.Length == 0)
        {
            logger.LogInformation("TableDeployer: ไม่มีไฟล์ .sql");
            return;
        }

        var connStr = config.GetConnectionString("DefaultConnection")!;
        await using var conn = new NpgsqlConnection(connStr);
        await conn.OpenAsync();

        int deployed = 0, skipped = 0;

        foreach (var file in sqlFiles)
        {
            var rel     = Path.GetRelativePath(projectRoot, file).Replace('\\', '/');
            var isFkFile = Path.GetFileName(file).StartsWith("z_fk_", StringComparison.OrdinalIgnoreCase);

            if (isFkFile)
            {
                // Execute each FK statement individually so one duplicate doesn't block the rest
                var sql = await File.ReadAllTextAsync(file);
                var stmts = _stmtSplit.Split(sql)
                                      .Select(s => s.Trim())
                                      .Where(s => s.Length > 0 && !s.StartsWith("--"))
                                      .ToArray();
                int fkOk = 0, fkSkip = 0;
                foreach (var stmt in stmts)
                {
                    try
                    {
                        await using var cmd = new NpgsqlCommand(stmt + ";", conn);
                        await cmd.ExecuteNonQueryAsync();
                        fkOk++;
                    }
                    catch (PostgresException ex) when (ex.SqlState is "42710" or "42P07") // duplicate constraint/table
                    {
                        fkSkip++;
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "TableDeployer FK: ✗ {File} — {Stmt}", rel, stmt[..Math.Min(120, stmt.Length)]);
                        // continue — don't stop for FK errors (may resolve after more tables are created)
                    }
                }
                logger.LogInformation("TableDeployer FK: {File} — added={Ok} skipped={Skip}", rel, fkOk, fkSkip);
            }
            else
            {
                var sql = await File.ReadAllTextAsync(file);
                sql = _createTable.Replace(sql, "CREATE TABLE IF NOT EXISTS ");
                var stmts = _stmtSplit.Split(sql)
                                      .Select(s => s.Trim())
                                      .Where(s => s.Length > 0 && !s.StartsWith("--"))
                                      .ToArray();
                int stmtOk = 0, stmtSkip = 0, stmtFail = 0;
                foreach (var stmt in stmts)
                {
                    try
                    {
                        await using var cmd = new NpgsqlCommand(stmt + ";", conn);
                        await cmd.ExecuteNonQueryAsync();
                        stmtOk++;
                    }
                    catch (PostgresException ex) when (ex.SqlState is "42P07" or "42710" or "42701" or "42703" or "42P16" or "23505")
                    {
                        // 42P07=table exists, 42710=constraint exists, 42701=column exists,
                        // 42703=column not found (stale COMMENT), 42P16=multiple PKs (PK already there),
                        // 23505=duplicate (type/enum already exists from prior run)
                        stmtSkip++;
                    }
                    catch (Exception ex)
                    {
                        logger.LogWarning("TableDeployer: ✗ {File} — {Msg}", rel, ex.Message);
                        stmtFail++;
                    }
                }
                if (stmtFail > 0)
                    logger.LogWarning("TableDeployer: {File} — ok={Ok} skip={Skip} fail={Fail}", rel, stmtOk, stmtSkip, stmtFail);
                else if (stmtSkip == stmts.Length)
                { logger.LogDebug("TableDeployer: skip (exists) {File}", rel); skipped++; }
                else
                { logger.LogInformation("TableDeployer: ✓ {File}", rel); deployed++; }
            }
        }

        logger.LogInformation("TableDeployer: เสร็จ — deployed={D} skipped={S}", deployed, skipped);
    }

    private static string FindProjectRoot(string startDir)
    {
        var dir = new DirectoryInfo(startDir);
        while (dir != null)
        {
            if (Directory.Exists(Path.Combine(dir.FullName, "Database")))
                return dir.FullName;
            dir = dir.Parent;
        }
        return Directory.GetCurrentDirectory();
    }
}
