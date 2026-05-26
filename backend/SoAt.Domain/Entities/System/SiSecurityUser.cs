namespace SoAt.Domain.Entities.System;

public class SiSecurityUser
{
    public string UserId { get; set; } = default!;
    public string? UserName { get; set; }
    public string? BranchId { get; set; }
    public string? Passwords { get; set; }
    public string CloseStatus { get; set; } = "0";
    public string? GroupId { get; set; }
    public string? Programmer    { get; set; }
    public string? AdminMode     { get; set; }
    /// <summary>CHAR(1) '1' = split counter (ไม่ใช่เจ้าหน้าที่การเงินหลัก)</summary>
    public string? CounterSplit  { get; set; }
}
