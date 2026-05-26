namespace SoAt.Application.Auth;

/// <param name="BranchId">สาขาที่เลือกตอน login — ถ้าระบุจะ override branch_id ของ user</param>
public record LoginCommand(string UserId, string Password, string? BranchId = null);

public record LoginResult(string Token, string UserId, string BranchId, string DisplayName);
