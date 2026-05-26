using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoAt.Application.Fin;

namespace SoAt.API.Controllers;

[ApiController]
[Route("api/fin")]
[Authorize]
public class FinController(IFinDailyService finDailyService) : ControllerBase
{
    // GET /api/fin/counter-opened
    // Oracle: pka_fin_daily.fp_counter_opened
    [HttpGet("counter-opened")]
    public async Task<IActionResult> GetCounterOpened()
    {
        var userId   = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        var branchId = User.FindFirstValue("branch_id") ?? "";
        var opened   = await finDailyService.IsCounterOpenedAsync(userId, branchId);
        return Ok(new { opened });
    }

    // GET /api/fin/finance-date
    // Oracle: pka_fin_daily.fp_finance_date
    [HttpGet("finance-date")]
    public async Task<IActionResult> GetFinanceDate()
    {
        var date = await finDailyService.GetFinanceDateAsync();
        return Ok(new { financeDate = date });
    }

    // GET /api/fin/session-info
    // Oracle equivalent query ใน scLayout.master.cs:
    //   SELECT fp_counter_opened, counter_split, branch_name, user_name FROM dual
    // ใช้สำหรับ footer ทุกหน้า
    [HttpGet("session-info")]
    public async Task<IActionResult> GetSessionInfo()
    {
        var userId   = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        var branchId = User.FindFirstValue("branch_id") ?? "";

        var info = await finDailyService.GetSessionInfoAsync(userId, branchId);
        if (info is null)
            return Ok(new { counterOpened = false, counterSplit = false, branchName = (string?)null, userName = (string?)null, financeDate = (DateTime?)null });

        return Ok(new
        {
            counterOpened = info.CounterOpened,
            counterSplit  = info.CounterSplit,
            branchName    = info.BranchName,
            userName      = info.UserName,
            financeDate   = info.FinanceDate,
        });
    }
}
