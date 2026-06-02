using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace SoAt.Infrastructure.Persistence;

/// <summary>
/// Deploy PostgreSQL triggers จาก Database/Triggers/**/*.sql ทุกครั้งที่ start
/// แต่ละไฟล์มี 2 statements: CREATE OR REPLACE FUNCTION + CREATE TRIGGER
/// ต้องรันหลัง TableDeployer และ FunctionDeployer
/// </summary>
public static class TriggerDeployer
{
    public static async Task DeployAsync(IConfiguration config, ILogger logger)
    {
        var projectRoot  = FindProjectRoot(AppContext.BaseDirectory);
        var triggerRoot  = Path.Combine(projectRoot, "Database", "Triggers");

        if (!Directory.Exists(triggerRoot))
        {
            logger.LogWarning("TriggerDeployer: ไม่พบ {Path}", triggerRoot);
            return;
        }

        var sqlFiles = Directory.GetFiles(triggerRoot, "*.sql", SearchOption.AllDirectories)
                                .Where(f => !Path.GetFileName(f).Equals(".gitkeep", StringComparison.OrdinalIgnoreCase))
                                .OrderBy(f => f)
                                .ToArray();

        if (sqlFiles.Length == 0)
        {
            logger.LogInformation("TriggerDeployer: ไม่มีไฟล์ .sql");
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
                logger.LogInformation("TriggerDeployer: ✓ {File}", rel);
                deployed++;
            }
            catch (Exception ex)
            {
                logger.LogWarning("TriggerDeployer: ✗ {File} — {Msg}", rel, ex.Message);
                failed++;
            }
        }

        logger.LogInformation("TriggerDeployer: เสร็จ — deployed={D} failed={F}", deployed, failed);
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
