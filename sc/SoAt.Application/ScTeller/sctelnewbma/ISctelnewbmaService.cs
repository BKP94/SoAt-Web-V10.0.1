namespace SoAt.Application.ScTeller;

public interface ISctelnewbmaService
{
    /// <summary>ดึงใบสมัครตาม application_form_no</summary>
    Task<ApplicationFormDto?> GetApplicationAsync(string applicationFormNo);

    /// <summary>สร้างใบสมัครใหม่ — gen application_form_no อัตโนมัติ</summary>
    Task<ApplicationFormSaveResult> CreateApplicationAsync(ApplicationFormDto dto, string userId, string branchId);

    /// <summary>อัปเดตใบสมัคร (ยังไม่ถูก approve)</summary>
    Task<ApplicationFormSaveResult> UpdateApplicationAsync(string applicationFormNo, ApplicationFormDto dto, string userId);

    /// <summary>
    /// ยกเลิก (void) ใบสมัครพร้อมเหตุผล — legacy pka_mem_newmem.sp_docno_cancel.
    /// ยกเลิกได้เฉพาะสถานะ "รออนุมัติ" (approve_status='2') ที่ยังไม่ถูกยกเลิก (cancel_status='0')
    /// </summary>
    Task<ApplicationFormSaveResult> CancelApplicationAsync(string applicationFormNo, string cancelReason, string userId, string branchId);

    /// <summary>ค้นหาใบสมัครที่บันทึกไว้ (popOpen) ตามเงื่อนไข filter</summary>
    Task<List<ApplicationSummaryDto>> SearchApplicationsAsync(ApplicationSearchFilter filter);

    // ── value-change lookups (Group B) ─────────────────────────────────────────

    /// <summary>คำนำหน้า → ค่า default เพศ + สถานภาพสมรส (legacy change_prename_code)</summary>
    Task<PrenameDefaultDto> GetPrenameDefaultAsync(string prenameCode);

    /// <summary>กลุ่มสมาชิก → กลุ่มช่วยเลือกตั้ง (legacy change_member_group_no, pka_election.fp_help_election)</summary>
    Task<string?> GetElectionHelpGroupAsync(string memberGroupNo);

    /// <summary>วันเกิด → ข้อความอายุ (legacy change_date_of_birth, pka_lon_reqsrv.fp_calc_agetext)</summary>
    Task<string?> CalcAgeTextAsync(DateTime dateOfBirth);

    /// <summary>อำเภอ → รหัสไปรษณีย์ default (legacy change_district_code auto-fill post_code)</summary>
    Task<string?> GetDistrictPostCodeAsync(string districtCode);

    // ── value-change validation (Group C) ──────────────────────────────────────

    /// <summary>ตรวจเลขบัตร ปชช. ว่าสมัครได้หรือไม่ (legacy ofValidateHumid: เคยเป็นสมาชิก/ลาออก/รออนุมัติ/ค้ำ/ปปง.)</summary>
    Task<HumIdValidationDto> ValidateHumIdAsync(string humId, DateTime applyDate);

    /// <summary>ตรวจชื่อ-สกุล ว่าซ้ำในระบบหรือตรง ปปง. (legacy of_validate_name)</summary>
    Task<NameValidationDto> ValidateNameAsync(string memName, string memSurname);

    // ── value-change calculation (Group D) ─────────────────────────────────────

    /// <summary>
    /// คำนวณหุ้นส่งรายเดือนจากเงินเดือน/ค่าหุ้น (legacy update_share_monthly).
    /// itemChange = "salary_amount" (เงินเดือนเปลี่ยน → คำนวณหุ้นใหม่) | "share_monthly" (กรอกหุ้นเอง → min/max MWA)
    /// </summary>
    Task<ShareCalcDto> UpdateShareMonthlyAsync(string memType, string memberGroupNo, string itemChange, decimal shareMonthly, decimal sumSalary);

    // ── value-change lookups (Group E — tabs) ──────────────────────────────────

    /// <summary>เลขสมาชิก → pad zeros + ดึงชื่อเต็ม (legacy of_validate_membership_no). คืน null ถ้าไม่พบทะเบียน</summary>
    Task<MemberLookupDto?> LookupMemberAsync(string membershipNo);

    /// <summary>เลขทะเบียนคู่สมรส → ดึงข้อมูลคู่สมรส (legacy change_spouse_member_no). คืน null ถ้าไม่พบ</summary>
    Task<SpouseLookupDto?> LookupSpouseAsync(string membershipNo);

    /// <summary>รายชื่อ ปปง. ที่ตรง (legacy popValidateAML). popType = "popName" (ชื่อ-สกุล) | "popHumID" (เลขบัตร)</summary>
    Task<List<AmlMatchDto>> GetAmlMatchesAsync(string popType, string name, string surname, string humId);
}
