namespace SoAt.Domain.Entities.Fin;

/// <summary>
/// sc_fin_m_constant — ค่าคงที่ระบบการเงิน (single-row config)
/// Oracle table: SC_FIN_M_CONSTANT | PK: coop_no
/// </summary>
public class ScFinMConstant
{
    public string CoopNo        { get; set; } = null!;  // PK VARCHAR2(15)
    public DateTime? FinanceDate { get; set; }           // วันที่การเงินปัจจุบัน
}
