using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoAt.Application.Sc;
using SoAt.Infrastructure.Persistence;

namespace SoAt.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScController(IScAppService scAppService, IConfiguration config, AppDbContext db) : ControllerBase
{
    [HttpGet("apps")]
    public async Task<IActionResult> GetApps([FromQuery] int level = 1)
    {
        var apps = await scAppService.GetAppsAsync(level);
        return Ok(apps);
    }

    [HttpGet("menu")]
    public async Task<IActionResult> GetMenu([FromQuery] string appName)
    {
        var apps = await scAppService.GetMenuAsync(appName);
        return Ok(apps);
    }

    [HttpGet("branches")]
    public async Task<IActionResult> GetBranches()
    {
        var branches = await scAppService.GetBranchesAsync();
        return Ok(branches);
    }

    // ── sync level-3 menu จาก Oracle → PostgreSQL ────────────────────────────
    // GET /api/sc/sync-menu          → seed ถ้ายังไม่มี
    // GET /api/sc/sync-menu?force=true → ลบทิ้งแล้ว seed ใหม่
    [HttpGet("sync-menu")]
    public async Task<IActionResult> SyncMenu([FromQuery] bool force = false)
    {
        await DatabaseSeeder.SeedSecurityAppsLevel3FromOracleAsync(db, config, force);
        var count = await db.SiSecurityApps.CountAsync(a => a.ILevel == 3);
        return Ok(new { message = "done", level3Count = count });
    }

    [HttpGet("dbname")]
    public IActionResult GetDbName()
    {
        var connStr = config.GetConnectionString("DefaultConnection") ?? "";
        var dbName = connStr
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(p => p.Trim().Split('=', 2))
            .Where(p => p.Length == 2 && p[0].Equals("Database", StringComparison.OrdinalIgnoreCase))
            .Select(p => p[1])
            .FirstOrDefault() ?? "unknown";

        return Ok(new { databaseName = dbName.ToUpper() });
    }
}
