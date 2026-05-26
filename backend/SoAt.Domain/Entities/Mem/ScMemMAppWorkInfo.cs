namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_app_work_info — ข้อมูลการทำงาน</summary>
public class ScMemMAppWorkInfo
{
    public string    ApplicationFormNo    { get; set; } = null!; // PK / FK
    public DateTime? WorkingDate          { get; set; }
    public string?   SalaryId             { get; set; }          // รหัสเลขพนักงาน
    public string?   GroupOther           { get; set; }
    public string?   GroupPosition        { get; set; }          // ประเภทงาน
    public string?   PositionLong         { get; set; }          // ตำแหน่ง
    public string?   LevelCode            { get; set; }
    public string?   SalaryRateCode       { get; set; }
    public decimal?  SalaryAmount         { get; set; }
    public decimal?  AcademicSalary       { get; set; }          // เงินประจำตำแหน่ง
    public decimal?  RemunerationAmount   { get; set; }          // เงินอื่นๆ
    public decimal?  SalaryReal           { get; set; }          // เงินเดือนรวม
    public DateTime? EndingcontractDate   { get; set; }
}
