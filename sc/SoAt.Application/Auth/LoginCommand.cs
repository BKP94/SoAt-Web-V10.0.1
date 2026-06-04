namespace SoAt.Application.Auth;

/// <param name="BranchId">สาขาที่เลือกตอน login — ถ้าระบุจะ override branch_id ของ user</param>
public record LoginCommand(string UserId, string Password, string? BranchId = null);

/// <summary>Identity ที่ผ่านการตรวจแล้ว — ใช้สร้าง cookie claims ใน Blazor Server</summary>
public record AuthUser(string UserId, string BranchId, string DisplayName);
