using sc;

namespace SoAt.Application.ScTeller;

// ── Generic combo DTO (code+name pair) ────────────────────────────────────────
/// <summary>
/// Generic dropdown item — ใช้สำหรับ combo ที่มีแค่ code + name
/// เช่น sex (sc.combo.sex), marriage_status (sc.combo.sc_mem_m_ucf_marriage_status)
/// </summary>
public record ComboItemDto(string Code, string? Name);

// ── value-change results (Group B) ────────────────────────────────────────────
/// <summary>ผล lookup คำนำหน้า → เพศ + สถานภาพสมรส (legacy change_prename_code)</summary>
public record PrenameDefaultDto(string? Sex, string? MarriageStatus);

// ── value-change results (Group C — validate hum_id / ชื่อ-สกุล) ──────────────
/// <summary>
/// ผลตรวจเลขบัตร ปชช. (legacy ofValidateHumid):
/// Message=ข้อความแจ้ง (HTML), AllowRegister=สมัครได้หรือไม่ (cpRegisStat),
/// AmlMatch=ตรงรายชื่อ ปปง. (cpCheckPopAML → ไม่ให้ใช้เลขนี้)
/// </summary>
public record HumIdValidationDto(string? Message, bool AllowRegister, bool AmlMatch);

/// <summary>ผลตรวจชื่อ-สกุลซ้ำ (legacy of_validate_name): Message=ข้อความ (HTML), AmlMatch=ตรง ปปง.</summary>
public record NameValidationDto(string? Message, bool AmlMatch);

// ── value-change results (Group D — คำนวณหุ้น) ────────────────────────────────
/// <summary>
/// ผลคำนวณหุ้นส่งรายเดือน (legacy update_share_monthly):
/// ShareMonthly=ค่าหุ้นที่คำนวณได้, MinShare/MaxShare=ขั้นต่ำ/สูงสุด (เฉพาะ MWA, null = ไม่บังคับ)
/// </summary>
public record ShareCalcDto(decimal ShareMonthly, decimal? MinShare, decimal? MaxShare);

// ── value-change results (Group E — tabs) ─────────────────────────────────────
/// <summary>ผล lookup เลขสมาชิก → เลขที่ pad + ชื่อเต็ม (legacy of_validate_membership_no / ofCheckMemno)</summary>
public record MemberLookupDto(string MembershipNo, string? MemberName);

/// <summary>ผล lookup คู่สมรสจากเลขทะเบียน (legacy change_spouse_member_no)</summary>
public record SpouseLookupDto(string? SpouseMemberNo, string? PrenameCode, string? SpouseName, string? SpouseSurname, string? IdCard);

/// <summary>1 แถวรายชื่อ ปปง. (legacy popValidateAML grid: sc_mem_m_member_aml)</summary>
public record AmlMatchDto(int? SeqNo, DateTime? AmlDate, string? AmlFullname, string? AmlId, string? AmlBirth, string? AmlBookno, string? AmlRemark);

// ── Application Form DTOs ─────────────────────────────────────────────────────

public class AppAddressDto
{
    public string? AddressType   { get; set; }  // '0'=ปัจจุบัน '1'=ทะเบียนบ้าน '2'=ที่ทำงาน
    public string? AddressNo     { get; set; }
    public string? Moo           { get; set; }
    public string? Mooban        { get; set; }
    public string? Soi           { get; set; }
    public string? Road          { get; set; }
    public string? Tambol        { get; set; }  // subdistrict code
    public string? DistrictCode  { get; set; }
    public string? ProvinceCode  { get; set; }
    public string? Postcode      { get; set; }
    public string? Telephone     { get; set; }
}

public class AppWorkInfoDto : ISaveRowFilter
{
    public DateTime? WorkingDate         { get; set; }
    public string?   SalaryId            { get; set; }
    public string?   GroupOther          { get; set; }
    public string?   GroupPosition       { get; set; }
    public string?   PositionLong        { get; set; }
    public int?      LevelCode           { get; set; }   // level_code smallint (รหัสระดับเงินเดือน)
    public decimal?  SalaryRateCode      { get; set; }   // salary_rate_code decimal(3,1)
    public decimal?  SalaryAmount        { get; set; }
    public decimal?  AcademicSalary      { get; set; }
    public decimal?  RemunerationAmount  { get; set; }
    public decimal?  SalaryReal          { get; set; }
    public DateTime? EndingcontractDate  { get; set; }

    // เซฟเฉพาะเมื่อมีข้อมูลงานอย่างน้อย 1 ช่อง (เดิม HasWorkInfo ใน Page)
    public bool ShouldSave() =>
        WorkingDate is not null || !string.IsNullOrWhiteSpace(SalaryId)
        || !string.IsNullOrWhiteSpace(PositionLong) || SalaryAmount is not null
        || !string.IsNullOrWhiteSpace(GroupPosition) || SalaryReal is not null;
}

public class AppMemberReferDto
{
    public int     SeqNo        { get; set; }
    public string? MembershipNo { get; set; }
    public string? MemberName   { get; set; }
    public string? ConcernCode  { get; set; }
}

public class AppRecrieveGainDto
{
    public int       SeqNo        { get; set; }
    public string?   PrenameCode  { get; set; }
    public string?   GainName     { get; set; }
    public string?   GainSurname  { get; set; }
    public string?   ConcernCode  { get; set; }
    public string?   WefType      { get; set; }
    public decimal?  GainPercent  { get; set; }
    public string?   GainIdCard   { get; set; }
    public DateTime? BookDate     { get; set; }
    public int?      OrderNumber  { get; set; }
    public string?   GainAddress  { get; set; }
    public string?   GainTelephone { get; set; }
    public string?   GainDesc     { get; set; }
}

// ── tab: บัญชีธนาคาร (sc_mem_m_app_bank_accno — grid หลายแถว) ──────────────────
public class AppBankAccountDto : ISaveRowFilter
{
    public int      SeqNo         { get; set; }
    public string?  BankId        { get; set; }   // sc_acc_m_ucf_bank
    public string?  BankBranchId  { get; set; }   // sc_acc_m_ucf_bank_branch (cascade ← BankId)
    public string?  BankAccNo     { get; set; }
    public bool     PaidLoan      { get; set; }   // เงินกู้
    public bool     AtmLon        { get; set; }   // ATM เงินกู้
    public bool     AtmDep        { get; set; }   // ATM เงินฝาก
    public bool     PaidDividen   { get; set; }   // เงินปันผล
    public bool     ShareWithdraw { get; set; }   // เงินรอจ่ายคืน
    public bool     KeepMonthly   { get; set; }   // ส่งหักรายเดือน
    public bool     PaidAgent     { get; set; }   // หักชำระตัวแทน
    public bool     PaidSalary    { get; set; }   // เงินเดือน

    // ข้ามแถวว่าง (grid อาจมีแถวเปล่า) — ต้องมีธนาคารหรือเลขบัญชี
    public bool ShouldSave() =>
        !string.IsNullOrWhiteSpace(BankId) || !string.IsNullOrWhiteSpace(BankAccNo);
}

// ── tab: ข้อมูลครอบครัว → คู่สมรส (sc_mem_m_app_spouse_info) ─────────────────────
// (บิดา/มารดา เก็บที่ header sc_mem_m_application_form: Father/Mother)
public class AppSpouseInfoDto : ISaveRowFilter
{
    public string?   SpouseMemberNo   { get; set; }  // ทะเบียน (ถ้าคู่สมรสเป็นสมาชิก)
    public string?   PrenameCode      { get; set; }
    public string?   SpouseName       { get; set; }
    public string?   SpouseSurname    { get; set; }
    public string?   OccupationCode   { get; set; }
    public decimal?  SalaryAmount     { get; set; }
    public decimal?  SalaryCalloan    { get; set; }  // เงินเดือนร่วมกู้
    public DateTime? DateOfBirth      { get; set; }
    public string?   PositionCode     { get; set; }
    public string?   IdCard           { get; set; }
    public string?   TaxId            { get; set; }
    // สถานที่ทำงาน(คู่สมรส) — column ชื่อ workname (ไม่มี underscore)
    [SaveColumn("workname")]
    public string?   WorkName         { get; set; }
    public string?   WorkAddress      { get; set; }
    public string?   WorkMoo          { get; set; }
    public string?   WorkSoi          { get; set; }
    public string?   WorkRoad         { get; set; }
    public string?   WorkProvinceCode { get; set; }
    public string?   WorkDistrictCode { get; set; }
    public string?   WorkTambol       { get; set; }
    public string?   WorkPostcode     { get; set; }
    public string?   WorkTelephone    { get; set; }

    // เซฟเฉพาะเมื่อมีข้อมูลคู่สมรสจริง (เดิม HasSpouseInfo ใน service)
    public bool ShouldSave() =>
        !string.IsNullOrWhiteSpace(SpouseName)     || !string.IsNullOrWhiteSpace(SpouseSurname)
        || !string.IsNullOrWhiteSpace(SpouseMemberNo) || !string.IsNullOrWhiteSpace(IdCard)
        || DateOfBirth is not null || SalaryAmount is not null || SalaryCalloan is not null;
}

// ── tab: ข้อมูลการส่งหุ้น/โอน → ข้อมูลการรับโอน (sc_mem_m_app_own_info) ───────────
public class AppOwnInfoDto : ISaveRowFilter
{
    public string?   OtherSaving  { get; set; }  // โอนมาจาก(ที่เดิม) — sc_mem_m_ucf_othersaving
    public DateTime? FirstDate    { get; set; }  // วันที่เป็นสมาชิก(ที่เดิม)
    public decimal?  OwnTotalLoan { get; set; }  // หนี้สิน(ที่เดิม)
    public string?   MatiDetail   { get; set; }  // มติที่ประชุม

    // เซฟเฉพาะเมื่อมีข้อมูลรับโอนจริง (เดิม HasOwnInfo ใน service)
    public bool ShouldSave() =>
        !string.IsNullOrWhiteSpace(OtherSaving) || FirstDate is not null
        || OwnTotalLoan is not null || !string.IsNullOrWhiteSpace(MatiDetail);
}

/// <summary>DTO ครอบคลุม header + ทุก sub-table ของ sctelnewbma
/// — annotate ด้วย sc.save attribute แล้ว save ผ่าน sc.save engine (ไม่เขียน SQL save เอง)</summary>
[SaveTable("sc_mem_m_application_form")]
public class ApplicationFormDto
{
    // ── header (sc_mem_m_application_form) ────────────────────────────────────
    [SaveKey(Generator = "GenApplicationFormNo")]
    public string?   ApplicationFormNo { get; set; }
    public DateTime? ApplyDate         { get; set; }
    public string?   PrenameCode       { get; set; }
    [SaveRequired("กรุณากรอกชื่อ")]
    public string?   MemberName        { get; set; }
    [SaveRequired("กรุณากรอกนามสกุล")]
    public string?   MemberSurname     { get; set; }
    public string?   MemberGroupNo     { get; set; }
    [SaveRequired("กรุณาเลือกประเภทสมาชิก")]
    public string?   MemType           { get; set; }
    public DateTime? DateOfBirth       { get; set; }
    [SaveIgnore]                                        // display-only (legacy panHead$age) — ไม่ลง DB
    public string?   AgeText           { get; set; }
    public string?   Sex               { get; set; }
    public string?   ApplTypeCode      { get; set; }
    public string?   HumId             { get; set; }   // เลขบัตร ปชช.
    public string?   MarriageStatus    { get; set; }
    public string?   NationalityCode   { get; set; }
    public string?   BloodCode         { get; set; }
    public string?   MobileNumber      { get; set; }
    public string?   Email             { get; set; }
    public string?   Remark            { get; set; }
    [SaveDefault("2")]
    public string?   ApproveStatus     { get; set; }   // insert: รอตรวจ
    [SaveDefault("0")]
    public string?   CancelStatus      { get; set; }   // insert: ยังไม่ยกเลิก
    // English name
    public string?   PrenameEng        { get; set; }
    public string?   NameEng           { get; set; }
    public string?   SurnameEng        { get; set; }
    // ID card
    public DateTime? IdCardDate        { get; set; }
    public DateTime? IdCardEnddate     { get; set; }
    public string?   IdCardNumber      { get; set; }
    public string?   IdCardOrganize    { get; set; }
    // election
    public string?   ElectionGroup     { get; set; }
    // ครอบครัว: บิดา/มารดา (อยู่ที่ header — tab ข้อมูลครอบครัว)
    public string?   Father            { get; set; }
    public string?   Mother            { get; set; }

    // ── sub-tables (child ของ sc.save — ParentKey=application_form_no) ───────────
    // 3 address → table เดียว (address_type อยู่บน model) → engine ลบทีเดียวตอน update
    [SaveTable("sc_mem_m_app_address", ParentKey = "application_form_no")]
    public AppAddressDto?            AddressCurrent   { get; set; }  // address_type='0'
    [SaveTable("sc_mem_m_app_address", ParentKey = "application_form_no")]
    public AppAddressDto?            AddressHome      { get; set; }  // address_type='1'
    [SaveTable("sc_mem_m_app_address", ParentKey = "application_form_no")]
    public AppAddressDto?            AddressWork      { get; set; }  // address_type='2'

    [SaveTable("sc_mem_m_app_work_info", ParentKey = "application_form_no")]
    public AppWorkInfoDto?           WorkInfo         { get; set; }

    // scalar → table แยก sc_mem_m_app_share (column share_monthly)
    [SaveTable("sc_mem_m_app_share", ParentKey = "application_form_no")]
    public decimal?                  ShareMonthly     { get; set; }

    [SaveTable("sc_mem_m_app_member_refer", ParentKey = "application_form_no", SeqColumn = "seq_no")]
    public List<AppMemberReferDto>   MemberRefers     { get; set; } = [];
    [SaveTable("sc_mem_m_app_recrieve_gain", ParentKey = "application_form_no", SeqColumn = "seq_no")]
    public List<AppRecrieveGainDto>  RecrieveGains    { get; set; } = [];

    [SaveIgnore] public string?      PictureBase64    { get; set; }   // base64 → byte[] ด้วย hook (service)
    [SaveIgnore] public string?      SignatureBase64  { get; set; }   // base64 → byte[] ด้วย hook (service)

    // ── tabs (PanTabs): บัญชีธนาคาร / คู่สมรส / รับโอน ───────────────────────────
    // flag เก็บ char(1) '0'/'1' → BoolAs01
    [SaveTable("sc_mem_m_app_bank_accno", ParentKey = "application_form_no", SeqColumn = "seq_no", BoolAs01 = true)]
    public List<AppBankAccountDto>   BankAccounts     { get; set; } = [];
    [SaveTable("sc_mem_m_app_spouse_info", ParentKey = "application_form_no")]
    public AppSpouseInfoDto?         SpouseInfo       { get; set; }
    [SaveTable("sc_mem_m_app_own_info", ParentKey = "application_form_no")]
    public AppOwnInfoDto?            OwnInfo          { get; set; }
}

/// <summary>Response หลังสร้าง/บันทึกใบสมัคร</summary>
public record ApplicationFormSaveResult(string ApplicationFormNo, string Message);

// ── ค้นหา/เปิดใบสมัคร (popOpen) ────────────────────────────────────────────────

/// <summary>เงื่อนไขค้นหาใบสมัคร (popOpen) — null/ว่าง = ไม่กรอง field นั้น</summary>
public class ApplicationSearchFilter
{
    public string? ApplicationFormNo { get; set; }
    public string? MemberName        { get; set; }
    public string? MemberSurname     { get; set; }
    public string? MemberGroup       { get; set; }   // เลขหน่วย/ชื่อหน่วย (LIKE)
    public string? ApproveStatus     { get; set; }   // 0/1/2 = approve_status, 3 = ยกเลิก (cancel_status='1')
}

/// <summary>1 แถวในตารางผลค้นหา (popOpen) — สรุปหัวใบสมัคร</summary>
public class ApplicationSummaryDto
{
    public string?   ApplicationFormNo { get; set; }
    public DateTime? ApplyDate         { get; set; }
    public string?   MemberName        { get; set; }   // คำนำหน้า + ชื่อ + สกุล
    public string?   MemberGroup       { get; set; }   // เลขหน่วย - ชื่อหน่วย
    public string?   ApproveStatus     { get; set; }   // 0/1/2/3 (3 = ยกเลิก)
}
