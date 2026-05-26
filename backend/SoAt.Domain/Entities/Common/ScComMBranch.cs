namespace SoAt.Domain.Entities.Common;

/// <summary>
/// sc_com_m_branch — ข้อมูลสาขา/สำนักงาน
/// Oracle table: SC_COM_M_BRANCH | PK: branch_id
/// </summary>
public class ScComMBranch
{
    public string  BranchId       { get; set; } = null!;  // PK VARCHAR2(6)
    public string? BranchName     { get; set; }            // ชื่อสาขา VARCHAR2(100)
    public string? BaseStatus     { get; set; }            // CHAR(1) '1'=สาขาหลัก
    public string? PosttoFin      { get; set; }            // CHAR(1) '1'=ผ่านระบบการเงิน
    public string? AccountControl { get; set; }            // VARCHAR2(8)
    public string? Picture2file   { get; set; }            // CHAR(1)
    public string? FinanceBranch  { get; set; }            // VARCHAR2(6) สาขาการเงินที่สังกัด
}
