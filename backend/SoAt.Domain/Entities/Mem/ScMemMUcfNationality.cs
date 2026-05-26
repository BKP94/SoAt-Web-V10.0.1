namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_nationality — สัญชาติ</summary>
public class ScMemMUcfNationality
{
    public string  NationalityCode        { get; set; } = null!; // PK
    public string? NationalityDescription { get; set; }
}
