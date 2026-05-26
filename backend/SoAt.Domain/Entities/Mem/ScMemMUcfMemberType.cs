namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_member_type — ประเภทสมาชิก</summary>
public class ScMemMUcfMemberType
{
    public string   MemTypeCode   { get; set; } = null!; // PK
    public string?  MemTypeDesc   { get; set; }
    public decimal? MaximunShare  { get; set; }          // maximun_share (Oracle typo kept)
    public string?  NotSalary     { get; set; }          // '1' = ไม่มีเงินเดือน
    public string?  MprocApart    { get; set; }          // '1' = งดส่งหุ้น
}
