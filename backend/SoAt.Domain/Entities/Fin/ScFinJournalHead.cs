namespace SoAt.Domain.Entities.Fin;

/// <summary>
/// sc_fin_journal_head — หัวบัญชีเคาน์เตอร์การเงินรายวัน
/// Oracle table: SC_FIN_JOURNAL_HEAD
/// PK: (branch_fin, journal_date, entry_fin, open_no, fin_book)
/// </summary>
public class ScFinJournalHead
{
    public string   BranchFin      { get; set; } = null!;  // VARCHAR2(6)  สาขา
    public DateTime JournalDate    { get; set; }            // DATE         วันที่บัญชี
    public string   EntryFin       { get; set; } = null!;  // VARCHAR2(16) รหัสเจ้าหน้าที่การเงิน
    public decimal  OpenNo         { get; set; }            // NUMBER       ครั้งที่เปิด
    public string   FinBook        { get; set; } = null!;  // CHAR(1)      '0'=ปกติ
    public decimal? BalanceBegin   { get; set; }            // ยอดยกมา
    public decimal? TotalReceive   { get; set; }            // รับรวม
    public decimal? TotalPayment   { get; set; }            // จ่ายรวม
    public decimal? BalanceForward { get; set; }            // ยอดคงเหลือยกไป
    public string?  MainCounter    { get; set; }            // CHAR(1) '1'=เคาน์เตอร์หลัก
    public string?  CloseDay       { get; set; }            // CHAR(1) '0'=ยังไม่ปิด, '1'=ปิดแล้ว
    public string?  CloseId        { get; set; }            // VARCHAR2(16) ผู้ปิด
    public DateTime? CloseTime     { get; set; }            // เวลาที่ปิด
    public string?  CloseClientId  { get; set; }            // VARCHAR2(3)
}
