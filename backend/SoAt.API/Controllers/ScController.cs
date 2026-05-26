using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SoAt.Application.Sc;

namespace SoAt.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScController(IScAppService scAppService, IConfiguration config) : ControllerBase
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
