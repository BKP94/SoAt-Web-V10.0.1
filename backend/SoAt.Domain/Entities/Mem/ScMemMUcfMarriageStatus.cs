namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_marriage_status — สถานะภาพสมรส</summary>
public class ScMemMUcfMarriageStatus
{
    public string  MarriageStatusCode { get; set; } = null!; // PK
    public string? MarriageStatusName { get; set; }          // column: marriage_status (see config)
}
