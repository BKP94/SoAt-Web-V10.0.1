namespace SoAt.Domain.Entities.Mem;

/// <summary>
/// sc_mem_m_app_address — ที่อยู่ผู้สมัคร
/// PK: (application_form_no, address_type)
/// address_type: '0'=ปัจจุบัน, '1'=ทะเบียนบ้าน, '2'=ที่ทำงาน
/// </summary>
public class ScMemMAppAddress
{
    public string  ApplicationFormNo { get; set; } = null!;
    public string  AddressType       { get; set; } = null!;
    public string? AddressNo         { get; set; }
    public string? Moo               { get; set; }
    public string? Mooban            { get; set; }
    public string? Soi               { get; set; }
    public string? Road              { get; set; }
    public string? Tambol            { get; set; }           // subdistrict code
    public string? DistrictCode      { get; set; }
    public string? ProvinceCode      { get; set; }
    public string? Postcode          { get; set; }
    public string? Telephone         { get; set; }
}
