namespace SoAt.Domain.Entities.Mem;

/// <summary>
/// sc_mem_m_ucf_concern — ความสัมพันธ์
/// Oracle column: conceern_code (typo) → PostgreSQL: concern_code (fixed)
/// </summary>
public class ScMemMUcfConcern
{
    public string  ConcernCode { get; set; } = null!; // PK (Oracle: conceern_code)
    public string? RelatedNa   { get; set; }           // Oracle: related_na
}
