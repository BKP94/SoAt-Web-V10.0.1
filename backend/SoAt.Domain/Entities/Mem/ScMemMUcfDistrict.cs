namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_district — อำเภอ/เขต</summary>
public class ScMemMUcfDistrict
{
    public string  DistrictCode  { get; set; } = null!; // PK
    public string? DistrictName  { get; set; }
    public string? ProvinceCode  { get; set; }          // FK → province
    public string? PostCode      { get; set; }          // รหัสไปรษณีย์ default ของอำเภอ
}
