namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_application_type — ประเภทการสมัคร</summary>
public class ScMemMUcfApplicationType
{
    public string   ApplTypeCode  { get; set; } = null!; // PK
    public string?  ApplTypeName  { get; set; }
    public decimal? ApplicationFee { get; set; }
    public string?  MemTypeCode   { get; set; }
}
