namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_province — จังหวัด</summary>
public class ScMemMUcfProvince
{
    public string  ProvinceCode { get; set; } = null!; // PK
    public string? ProvinceName { get; set; }
}
