using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace SoAt.Infrastructure.Persistence;

/// <summary>
/// Deploy PostgreSQL functions จาก Database/Functions/**/*.sql ทุกครั้งที่ start
/// PL team แก้ไข .sql file แล้ว restart API → function อัปเดตทันที
/// ใช้ CREATE OR REPLACE FUNCTION → safe รันซ้ำได้เสมอ
/// </summary>
public static class FunctionDeployer
{
    public static async Task DeployAsync(IConfiguration config, ILogger logger)
    {
        // หา root ของ project (Database/Functions/ อยู่คู่กับ SoAt.API)
        var apiDir      = AppContext.BaseDirectory;
        var projectRoot = FindProjectRoot(apiDir);
        var funcRoot    = Path.Combine(projectRoot, "Database", "Functions");

        if (!Directory.Exists(funcRoot))
        {
            logger.LogWarning("FunctionDeployer: ไม่พบ {Path}", funcRoot);
            return;
        }

        var sqlFiles = Directory.GetFiles(funcRoot, "*.sql", SearchOption.AllDirectories)
                                .OrderBy(f => f)
                                .ToArray();

        if (sqlFiles.Length == 0)
        {
            logger.LogInformation("FunctionDeployer: ไม่มีไฟล์ .sql");
            return;
        }

        var connStr = config.GetConnectionString("DefaultConnection")!;
        await using var conn = new NpgsqlConnection(connStr);
        await conn.OpenAsync();

        foreach (var file in sqlFiles)
        {
            try
            {
                var sql = await File.ReadAllTextAsync(file);
                await using var cmd = new NpgsqlCommand(sql, conn);
                await cmd.ExecuteNonQueryAsync();

                var rel = Path.GetRelativePath(projectRoot, file).Replace('\\', '/');
                logger.LogInformation("FunctionDeployer: ✓ {File}", rel);
            }
            catch (Exception ex)
            {
                var rel = Path.GetRelativePath(projectRoot, file).Replace('\\', '/');
                logger.LogError(ex, "FunctionDeployer: ✗ {File}", rel);
                throw; // หยุดถ้า deploy ไม่ผ่าน
            }
        }
    }

    // หา project root โดย walk up จนเจอ folder "Database"
    private static string FindProjectRoot(string startDir)
    {
        var dir = new DirectoryInfo(startDir);
        while (dir != null)
        {
            if (Directory.Exists(Path.Combine(dir.FullName, "Database")))
                return dir.FullName;
            dir = dir.Parent;
        }
        // fallback: ใช้ working directory
        return Directory.GetCurrentDirectory();
    }
}
