namespace SoAt.Application.ScTeller;

// ── Generic combo DTO (code+name pair) ────────────────────────────────────────
/// <summary>
/// Generic dropdown item — ใช้สำหรับ combo ที่มีแค่ code + name
/// เช่น sex (sc.combo.sex), marriage_status (sc.combo.sc_mem_m_ucf_marriage_status)
/// </summary>
public record ComboItemDto(string Code, string? Name);

// ── Lookup DTOs (สำหรับ dropdown) ─────────────────────────────────────────────

public record MemberTypeDto(string Code, string? Desc, decimal? MaximunShare, string? NotSalary, string? MprocApart);
public record MemberGroupDto(string No, string? Name, string? MemTypeDefault, string? NotSal, string? IngoreDropshrRule);
public record ElectionGroupDto(string Code, string? Name, string? Zone);
public record NationalityDto(string Code, string? Description);
public record BloodDto(string Code, string? Desc);
public record ProvinceDto(string Code, string? Name);
public record DistrictDto(string Code, string? Name, string? ProvinceCode, string? PostCode);
public record SubdistrictDto(string Code, string? Name, string? DistrictCode);
public record ApplicationTypeDto(string Code, string? Name, decimal? Fee, string? MemTypeCode);
public record ConcernDto(string Code, string? RelatedNa);
public record GroupPositionDto(string Code, string? Description, int? SortOrder);
public record PositionDto(string Code, string? Name, int? SortOrder);
public record CoopConfigDto(string CoopNo, int? CountResign, string? AutoApproveNewmem, string? MemTypeOngroup);
public record BankBranchDto(string Code, string? Name, string? BankId);   // cascade by BankId (เหมือน Districts ← Province)

public class SctelnewbmaLookupsDto
{
    public List<ComboItemDto>       Prenames         { get; set; } = [];   // sc.combo.sc_mem_m_ucf_prename
    public List<ComboItemDto>       Sexes            { get; set; } = [];   // sc.combo.sex
    public List<MemberTypeDto>      MemberTypes      { get; set; } = [];
    public List<MemberGroupDto>     MemberGroups     { get; set; } = [];
    public List<ElectionGroupDto>   ElectionGroups   { get; set; } = [];
    public List<NationalityDto>     Nationalities    { get; set; } = [];
    public List<ComboItemDto>       MarriageStatuses { get; set; } = [];   // sc.combo.sc_mem_m_ucf_marriage_status
    public List<BloodDto>           Bloods           { get; set; } = [];
    public List<ProvinceDto>        Provinces        { get; set; } = [];
    public List<DistrictDto>        Districts        { get; set; } = [];
    public List<SubdistrictDto>     Subdistricts     { get; set; } = [];
    public List<ApplicationTypeDto> ApplicationTypes { get; set; } = [];
    public List<ConcernDto>         Concerns         { get; set; } = [];
    public List<GroupPositionDto>   GroupPositions   { get; set; } = [];
    public List<PositionDto>        Positions        { get; set; } = [];
    public CoopConfigDto?           CoopConfig       { get; set; }
    // ── tabs: bankinfo / spouse / share-receive ──────────────────────────────
    public List<ComboItemDto>       Banks            { get; set; } = [];   // sc.combo.sc_acc_m_ucf_bank
    public List<BankBranchDto>      BankBranches     { get; set; } = [];   // sc_acc_m_ucf_bank_branch (cascade ← Banks)
    public List<ComboItemDto>       Occupations      { get; set; } = [];   // sc.combo.sc_mem_m_ucf_ocupation
    public List<ComboItemDto>       OtherSavings     { get; set; } = [];   // sc.combo.sc_mem_m_ucf_othersaving
}

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

public class AppWorkInfoDto
{
    public DateTime? WorkingDate         { get; set; }
    public string?   SalaryId            { get; set; }
    public string?   GroupOther          { get; set; }
    public string?   GroupPosition       { get; set; }
    public string?   PositionLong        { get; set; }
    public string?   LevelCode           { get; set; }
    public string?   SalaryRateCode      { get; set; }
    public decimal?  SalaryAmount        { get; set; }
    public decimal?  AcademicSalary      { get; set; }
    public decimal?  RemunerationAmount  { get; set; }
    public decimal?  SalaryReal          { get; set; }
    public DateTime? EndingcontractDate  { get; set; }
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
public class AppBankAccountDto
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
}

// ── tab: ข้อมูลครอบครัว → คู่สมรส (sc_mem_m_app_spouse_info) ─────────────────────
// (บิดา/มารดา เก็บที่ header sc_mem_m_application_form: Father/Mother)
public class AppSpouseInfoDto
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
    // สถานที่ทำงาน(คู่สมรส)
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
}

// ── tab: ข้อมูลการส่งหุ้น/โอน → ข้อมูลการรับโอน (sc_mem_m_app_own_info) ───────────
public class AppOwnInfoDto
{
    public string?   OtherSaving  { get; set; }  // โอนมาจาก(ที่เดิม) — sc_mem_m_ucf_othersaving
    public DateTime? FirstDate    { get; set; }  // วันที่เป็นสมาชิก(ที่เดิม)
    public decimal?  OwnTotalLoan { get; set; }  // หนี้สิน(ที่เดิม)
    public string?   MatiDetail   { get; set; }  // มติที่ประชุม
}

/// <summary>DTO ครอบคลุม header + ทุก sub-table ของ sctelnewbma</summary>
public class ApplicationFormDto
{
    // ── header (sc_mem_m_application_form) ────────────────────────────────────
    public string?   ApplicationFormNo { get; set; }
    public DateTime? ApplyDate         { get; set; }
    public string?   PrenameCode       { get; set; }
    public string?   MemberName        { get; set; }
    public string?   MemberSurname     { get; set; }
    public string?   MemberGroupNo     { get; set; }
    public string?   MemType           { get; set; }
    public DateTime? DateOfBirth       { get; set; }
    public string?   Sex               { get; set; }
    public string?   ApplTypeCode      { get; set; }
    public string?   HumId             { get; set; }   // เลขบัตร ปชช.
    public string?   MarriageStatus    { get; set; }
    public string?   NationalityCode   { get; set; }
    public string?   BloodCode         { get; set; }
    public string?   MobileNumber      { get; set; }
    public string?   Email             { get; set; }
    public string?   Remark            { get; set; }
    public string?   ApproveStatus     { get; set; }
    public string?   CancelStatus      { get; set; }
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

    // ── sub-tables ─────────────────────────────────────────────────────────────
    public AppAddressDto?            AddressCurrent   { get; set; }  // address_type='0'
    public AppAddressDto?            AddressHome      { get; set; }  // address_type='1'
    public AppAddressDto?            AddressWork      { get; set; }  // address_type='2'
    public AppWorkInfoDto?           WorkInfo         { get; set; }
    public decimal?                  ShareMonthly     { get; set; }
    public List<AppMemberReferDto>   MemberRefers     { get; set; } = [];
    public List<AppRecrieveGainDto>  RecrieveGains    { get; set; } = [];
    public string?                   PictureBase64    { get; set; }   // base64 ของรูป
    public string?                   SignatureBase64  { get; set; }   // base64 ของลายเซ็น
    // ── tabs (PanTabs): บัญชีธนาคาร / คู่สมรส / รับโอน ───────────────────────────
    public List<AppBankAccountDto>   BankAccounts     { get; set; } = [];  // sc_mem_m_app_bank_accno
    public AppSpouseInfoDto?         SpouseInfo       { get; set; }        // sc_mem_m_app_spouse_info
    public AppOwnInfoDto?            OwnInfo          { get; set; }        // sc_mem_m_app_own_info
}

/// <summary>Response หลังสร้าง/บันทึกใบสมัคร</summary>
public record ApplicationFormSaveResult(string ApplicationFormNo, string Message);
