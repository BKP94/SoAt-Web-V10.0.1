using Microsoft.AspNetCore.Mvc;
using SoAt.Application.Auth;

namespace SoAt.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await authService.LoginAsync(command);
        if (result is null)
            return Unauthorized(new { message = "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง" });

        return Ok(result);
    }
}
