using SoAt.Application.Auth;

namespace SoAt.Infrastructure.Auth;

public class AuthService(sc.dbFactory dbFactory) : IAuthService
{
    /// <summary>ตรวจ user/password กับ si_security_user — คืน identity สำหรับ cookie auth</summary>
    public async Task<AuthUser?> AuthenticateAsync(LoginCommand command)
    {
        await using var scDb = dbFactory.create();

        var user = await scDb.getOneAsync<UserRow>(
            "SELECT user_id, user_name, branch_id, passwords FROM si_security_user WHERE user_id = {0} AND close_status = '0'",
            command.UserId);

        if (user is null) return null;

        try
        {
            var decrypted = new sc.secure().decrypt(user.passwords ?? "");
            if (command.Password != decrypted) return null;
        }
        catch
        {
            return null;
        }

        var displayName = user.user_name ?? user.user_id;
        var branchId    = !string.IsNullOrWhiteSpace(command.BranchId)
            ? command.BranchId
            : (user.branch_id ?? "");

        return new AuthUser(user.user_id, branchId, displayName);
    }

    private record UserRow(string user_id, string? user_name, string? branch_id, string? passwords);
}
