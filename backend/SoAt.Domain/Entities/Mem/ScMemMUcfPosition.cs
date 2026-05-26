namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_position — ตำแหน่ง</summary>
public class ScMemMUcfPosition
{
    public string  PositionCode { get; set; } = null!; // PK
    public string? PositionName { get; set; }
    public int?    SortOrder    { get; set; }
}
