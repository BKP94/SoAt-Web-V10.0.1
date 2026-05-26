namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_prename — คำนำหน้าชื่อ</summary>
public class ScMemMUcfPrename
{
    public string  PrenameCode    { get; set; } = null!; // prename_code PK
    public string? Prename        { get; set; }          // prename
    public string? Sex            { get; set; }          // sex  M/F
    public string? MarriageStatus { get; set; }          // marriage_status
}
