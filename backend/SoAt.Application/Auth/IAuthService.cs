namespace SoAt.Application.Auth;

public interface IAuthService
{
    Task<LoginResult?> LoginAsync(LoginCommand command);
}
