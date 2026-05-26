namespace SoAt.Domain.Entities.Mem;

/// <summary>
/// sc_cnt_m_coop — config สหกรณ์ (single-row)
/// Oracle table: SC_CNT_M_COOP | PK: coop_no
/// เก็บเฉพาะ columns ที่ sctelnewbma ใช้
/// </summary>
public class ScCntMCoop
{
    public string  CoopNo             { get; set; } = null!; // PK
    public int?    CountResign        { get; set; }          // max รอบลาออกที่อนุญาต
    public string? AutoApproveNewmem  { get; set; }          // '1' = auto approve
    public string? MemTypeOngroup     { get; set; }          // '1' = ประเภทสมาชิก lock ตามหน่วยงาน
}
