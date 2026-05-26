namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_app_share — การส่งหุ้น</summary>
public class ScMemMAppShare
{
    public string   ApplicationFormNo { get; set; } = null!; // PK / FK
    public decimal? ShareMonthly      { get; set; }          // บาท/เดือน
}
