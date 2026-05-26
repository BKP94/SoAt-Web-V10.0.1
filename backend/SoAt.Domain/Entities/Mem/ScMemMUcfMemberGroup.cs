namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_member_group — หน่วยงาน/กลุ่มสมาชิก</summary>
public class ScMemMUcfMemberGroup
{
    public string  MemberGroupNo         { get; set; } = null!; // PK
    public string? MemberGroupName       { get; set; }
    public string? MemTypeDefault        { get; set; }          // ประเภทสมาชิก default ของหน่วยงาน
    public string? NotSal                { get; set; }          // '1' = ไม่มีเงินเดือน
    public string? IngoreDropshrRule     { get; set; }          // '1' = งดส่งหุ้น (Oracle typo kept)
}
