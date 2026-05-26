namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_group_position — ประเภทงาน</summary>
public class ScMemMUcfGroupPosition
{
    public string  GroupPosition { get; set; } = null!; // PK
    public string? Description   { get; set; }
    public int?    SortOrder     { get; set; }
}
