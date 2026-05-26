using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoAt.Application.ScTeller;

namespace SoAt.API.Controllers;

/// <summary>
/// ระบบเจ้าหน้าที่ประจำหน่วย (scTeller)
/// Route ตรงตาม legacy folder: api/scTeller/{page}
/// </summary>
[ApiController]
[Route("api/scTeller")]
[Authorize]
public class ScTellerController(ISctelnewbmaService sctelnewbmaService) : ControllerBase
{
    // ── sctelnewbma — สมัครสมาชิก ─────────────────────────────────────────────

    // GET /api/scTeller/sctelnewbma/lookups
    // ดึง dropdown ทั้งหมดสำหรับหน้าสมัครสมาชิก
    [HttpGet("sctelnewbma/lookups")]
    public async Task<IActionResult> GetLookups()
    {
        var result = await sctelnewbmaService.GetLookupsAsync();
        return Ok(result);
    }

    // GET /api/scTeller/sctelnewbma/{appNo}
    // ดึงใบสมัครตามเลขที่
    [HttpGet("sctelnewbma/{appNo}")]
    public async Task<IActionResult> GetApplication(string appNo)
    {
        var result = await sctelnewbmaService.GetApplicationAsync(appNo);
        if (result is null) return NotFound(new { message = $"ไม่พบใบสมัครเลขที่ {appNo}" });
        return Ok(result);
    }

    // POST /api/scTeller/sctelnewbma
    // สร้างใบสมัครใหม่
    [HttpPost("sctelnewbma")]
    public async Task<IActionResult> CreateApplication([FromBody] ApplicationFormDto dto)
    {
        var userId   = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        var branchId = User.FindFirstValue("branch_id") ?? "";
        var result = await sctelnewbmaService.CreateApplicationAsync(dto, userId, branchId);
        return CreatedAtAction(nameof(GetApplication), new { appNo = result.ApplicationFormNo }, result);
    }

    // PUT /api/scTeller/sctelnewbma/{appNo}
    // อัปเดตใบสมัคร
    [HttpPut("sctelnewbma/{appNo}")]
    public async Task<IActionResult> UpdateApplication(string appNo, [FromBody] ApplicationFormDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        try
        {
            var result = await sctelnewbmaService.UpdateApplicationAsync(appNo, dto, userId);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
