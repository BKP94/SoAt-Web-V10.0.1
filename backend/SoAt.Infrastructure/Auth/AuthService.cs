using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SoAt.Application.Auth;

namespace SoAt.Infrastructure.Auth;

public class AuthService(sc.dbFactory dbFactory, IConfiguration config) : IAuthService
{
    public async Task<LoginResult?> LoginAsync(LoginCommand command)
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
        var token = GenerateToken(user.user_id, branchId, displayName);
        return new LoginResult(token, user.user_id, branchId, displayName);
    }

    private string GenerateToken(string userId, string branchId, string displayName)
    {
        var jwtConfig = config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtConfig["ExpireMinutes"]!));

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim("branch_id", branchId),
            new Claim(ClaimTypes.Name, displayName),
        };

        var token = new JwtSecurityToken(
            issuer: jwtConfig["Issuer"],
            audience: jwtConfig["Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private record UserRow(string user_id, string? user_name, string? branch_id, string? passwords);
}
