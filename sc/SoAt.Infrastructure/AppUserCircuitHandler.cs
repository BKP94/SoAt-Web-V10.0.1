using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace SoAt.Infrastructure;

/// <summary>
/// เซ็ต sc.appUser (ambient current-user ต่อ circuit) จาก cookie claims —
/// แทน legacy sc.app.loginUser (Session var). ทำก่อนทุก inbound activity (event/render batch)
/// ผ่าน CreateInboundActivityHandler → รับประกันว่า dbFactory.create() ที่ไม่ส่ง loginId
/// จะ fallback มาใช้ user นี้ได้ทันเวลา แม้เรียกใน event handler.
///
/// ผล: programmer log gate (sc.log file sink) + SET LOCAL app.login_* ทำงานกับ query ทุกชนิด
/// (select/insert/update/delete/pkProcedure/pkFunction) โดยไม่ต้อง threading userId ผ่าน ~150 signature
///
/// register: services.AddScoped&lt;CircuitHandler, AppUserCircuitHandler&gt;() (ทำใน AddInfrastructure)
/// AuthenticationStateProvider + sc.appUser เป็น scoped → instance เดียวต่อ circuit
/// </summary>
public sealed class AppUserCircuitHandler(AuthenticationStateProvider auth, sc.appUser user) : CircuitHandler
{
    public override Func<CircuitInboundActivityContext, Task> CreateInboundActivityHandler(
        Func<CircuitInboundActivityContext, Task> next)
        => async context =>
        {
            if (!user.Loaded)
                await LoadFromClaimsAsync();
            await next(context);
        };

    private async Task LoadFromClaimsAsync()
    {
        var state = await auth.GetAuthenticationStateAsync();
        var principal = state.User;
        if (principal.Identity?.IsAuthenticated == true)
        {
            user.Id = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            user.Br = principal.FindFirst("branch_id")?.Value;
            user.Loaded = true;   // เซ็ตครั้งเดียวต่อ circuit (1 circuit = 1 user)
        }
        // ยังไม่ authenticated → ไม่ mark Loaded เพื่อให้ retry activity ถัดไป
    }
}
