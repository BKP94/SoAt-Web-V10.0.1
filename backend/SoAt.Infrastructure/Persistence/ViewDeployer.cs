using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace SoAt.Infrastructure.Persistence;

/// <summary>
/// Deploy PostgreSQL views จาก Database/Views/**/*.sql ทุกครั้งที่ start
/// ใช้ CREATE OR REPLACE VIEW → safe รันซ้ำได้เสมอ
/// ต้องรันหลัง TableDeployer (views อ้างอิง tables)
/// </summary>
public static class ViewDeployer
{
    public static async Task DeployAsync(IConfiguration config, ILogger logger)
    {
        var projectRoot = FindProjectRoot(AppContext.BaseDirectory);
        var viewRoot    = Path.Combine(projectRoot, "Database", "Views");

        if (!Directory.Exists(viewRoot))
        {
            logger.LogWarning("ViewDeployer: ไม่พบ {Path}", viewRoot);
            return;
        }

        var sqlFiles = Directory.GetFiles(viewRoot, "*.sql", SearchOption.AllDirectories)
                                .Where(f => !Path.GetFileName(f).Equals(".gitkeep", StringComparison.OrdinalIgnoreCase))
                                .OrderBy(f => f)
                                .ToArray();

        if (sqlFiles.Length == 0)
        {
            logger.LogInformation("ViewDeployer: ไม่มีไฟล์ .sql");
            return;
        }

        var connStr = config.GetConnectionString("DefaultConnection")!;
        await using var conn = new NpgsqlConnection(connStr);
        await conn.OpenAsync();

        int deployed = 0, failed = 0;

        foreach (var file in sqlFiles)
        {
            var rel = Path.GetRelativePath(projectRoot, file).Replace('\\', '/');
            try
            {
                var sql = await File.ReadAllTextAsync(file);
                await using var cmd = new NpgsqlCommand(sql, conn);
                await cmd.ExecuteNonQueryAsync();
                logger.LogInformation("ViewDeployer: ✓ {File}", rel);
                deployed++;
            }
            catch (PostgresException ex) when (ex.SqlState is "23505")
            {
                // type already exists from prior run — silent skip
            }
            catch (Exception ex)
            {
                logger.LogWarning("ViewDeployer: ✗ {File} — {Msg}", rel, ex.Message);
                failed++;
            }
        }

        logger.LogInformation("ViewDeployer: เสร็จ — deployed={D} failed={F}", deployed, failed);
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
