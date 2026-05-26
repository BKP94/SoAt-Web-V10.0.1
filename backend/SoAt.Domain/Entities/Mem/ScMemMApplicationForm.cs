namespace SoAt.Domain.Entities.Mem;

/// <summary>
/// sc_mem_m_application_form — ใบสมัครสมาชิก (header)
/// Oracle table: SC_MEM_M_APPLICATION_FORM | PK: application_form_no
/// </summary>
public class ScMemMApplicationForm
{
    public string    ApplicationFormNo { get; set; } = null!; // PK  VARCHAR2(15)
    public DateTime? ApplyDate         { get; set; }
    public string?   PrenameCode       { get; set; }
    public string?   MemberName        { get; set; }
    public string?   MemberSurname     { get; set; }
    public string?   MemberGroupNo     { get; set; }
    public string?   MemType           { get; set; }          // ประเภทสมาชิก
    public DateTime? DateOfBirth       { get; set; }
    public string?   Sex               { get; set; }          // M/F
    public string?   ApplTypeCode      { get; set; }          // ประเภทการสมัคร
    public string?   HumId             { get; set; }          // เลขบัตร ปชช.
    public string?   MarriageStatus    { get; set; }
    public string?   NationalityCode   { get; set; }
    public string?   BloodCode         { get; set; }
    public string?   MobileNumber      { get; set; }
    public string?   Email             { get; set; }
    public string?   Remark            { get; set; }
    public string?   ApproveStatus     { get; set; }          // 0=ไม่อนุมัติ 1=อนุมัติ 2=รออนุมัติ 3=ยกเลิก
    public string?   CancelStatus      { get; set; }          // 0=ปกติ 1=ยกเลิก
    // ข้อมูลภาษาอังกฤษ
    public string?   PrenameEng        { get; set; }
    public string?   NameEng           { get; set; }
    public string?   SurnameEng        { get; set; }
    // บัตรประชาชน
    public DateTime? IdCardDate        { get; set; }
    public DateTime? IdCardEnddate     { get; set; }
    public string?   IdCardNumber      { get; set; }
    public string?   IdCardOrganize    { get; set; }
    // กลุ่มเลือกตั้ง
    public string?   ElectionGroup     { get; set; }
    // audit
    public DateTime? CreatedAt         { get; set; }
    public DateTime? UpdatedAt         { get; set; }
    public string?   CreatedBy         { get; set; }
    public string?   UpdatedBy         { get; set; }
}
