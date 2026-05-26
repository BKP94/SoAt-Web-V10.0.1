namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_app_member_refer — สมาชิกอ้างอิง</summary>
public class ScMemMAppMemberRefer
{
    public string  ApplicationFormNo { get; set; } = null!; // PK part 1
    public int     SeqNo             { get; set; }           // PK part 2
    public string? MembershipNo      { get; set; }
    public string? MemberName        { get; set; }
    public string? ConcernCode       { get; set; }
}
