namespace SoAt.Application.Auth;

public interface IAuthService
{
    /// <summary>ตรวจ user/password แล้วคืน identity — ใช้กับ Blazor Server cookie auth</summary>
    Task<AuthUser?> AuthenticateAsync(LoginCommand command);
}
