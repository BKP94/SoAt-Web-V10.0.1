namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_subdistrict — ตำบล/แขวง</summary>
public class ScMemMUcfSubdistrict
{
    public string  SubdistrictCode { get; set; } = null!; // PK
    public string? SubdistrictName { get; set; }
    public string? DistrictCode    { get; set; }           // FK → district
}
