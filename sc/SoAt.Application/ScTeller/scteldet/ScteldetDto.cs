namespace SoAt.Application.ScTeller;

// ════════════════════════════════════════════════════════════════════════════
//  scteldet — ประวัติสมาชิก (Member Profile Viewer) DTOs
//  อ้างอิง legacy C:\SoAt_PEAN\scTeller\scteldet  (read-only viewer, ไม่มี Save)
//  Dapper MatchNamesWithUnderscores = true → property PascalCase ↔ column snake_case
// ════════════════════════════════════════════════════════════════════════════

// ── Page model (เจ้าของที่ Page.razor — ส่ง reference ร่วมลงทุก tab) ───────────
/// <summary>
/// state กลางของหน้า scteldet — Page.razor ถือตัวเดียว ส่งลง child ผ่าน [Parameter] (reference ร่วม).
/// tab อ่าน <see cref="MembershipNo"/> แล้ว re-query service เมื่อค่าเปลี่ยน (OnParametersSetAsync).
/// </summary>
public class ScteldetModel
{
    public string? MembershipNo { get; set; }
    public ScteldetHeaderDto? Header { get; set; }
    public List<TabGroupDto> Groups { get; set; } = new();
}

// ── Dynamic tab metadata (si_security_apps) ───────────────────────────────────
/// <summary>1 แท็บใน navbar (legacy si_security_apps i_level=5 = tab). s_url → ชื่อ component</summary>
public record TabItemDto(int TabId, int ParentId, string? Text, string? Url, int Sequence);

/// <summary>1 กลุ่มแท็บ (legacy si_security_apps i_level=4 = group) + แท็บลูก</summary>
public class TabGroupDto
{
    public int GroupId { get; set; }
    public string? GroupText { get; set; }
    public int Sequence { get; set; }
    public List<TabItemDto> Tabs { get; set; } = new();
}

// ── Header (panHead.ascx dsHead) ──────────────────────────────────────────────
/// <summary>
/// ข้อมูลหัวสมาชิก (legacy dsHead) — viewer read-only.
/// computed field ที่อิง Oracle pkg: fp_get_member_name / fp_calc_agetext* / fp_calc_member_retire
/// / fp_get_insure_approve / fp_get_member_address_* / fpa_mobile_get_active / fp_get_bank_div (migrate แล้วใน PG)
/// insurance_cost = STUB 0 (fp_get_insure_cost ยังไม่ migrate). cram (ฌาปนกิจ) = STUB (federation 3 Oracle DB)
/// </summary>
public class ScteldetHeaderDto
{
    public string MembershipNo { get; set; } = "";
    public string? MemberName { get; set; }
    public string? EngName { get; set; }
    public string? MemType { get; set; }
    public string? MemberGroupNo { get; set; }
    public string? MemberGroupName { get; set; }
    public string? MemberStatusCode { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? AgeMemText { get; set; }
    public DateTime? ResignationApproveDate { get; set; }
    public DateTime? ApproveDate { get; set; }
    public string? AgeLifeText { get; set; }
    public DateTime? RetireDate { get; set; }      // fp_calc_member_retire คืนวันที่เกษียณ
    public string? Sex { get; set; }
    public string? BloodCode { get; set; }
    public string? IdCard { get; set; }
    public string? DepositAccountId { get; set; }
    public string? Remark { get; set; }
    public decimal? InsuranceCost { get; set; }    // STUB 0
    public decimal? InsurancePay { get; set; }
    public string? OtherCode { get; set; }
    public string? MarriageStatus { get; set; }
    public string? MobileNumber { get; set; }
    public decimal? SalaryAmount { get; set; }
    public string? SalaryId { get; set; }
    public string? Address { get; set; }
    public string? AddressT { get; set; }
    public decimal? ShareStock { get; set; }
    public decimal? ShareAmount { get; set; }
    public decimal? PeriodRecrieve { get; set; }
    public DateTime? FirstDate { get; set; }
    public string? AgetextMemberFirstDate { get; set; }
    public string? PositionLong { get; set; }
    public decimal? TotalLoanInt { get; set; }
    public decimal? OtherAmount { get; set; }
    public string? MethodRecieveDividend { get; set; }
    public decimal? AcademicSalary { get; set; }
    public string? ResignCode { get; set; }
    public DateTime? DeadDate { get; set; }
    public string? RetireId { get; set; }
    public string? RetireText { get; set; }
    public string? Email { get; set; }
    public string? AccNoRecDiv { get; set; }
    public string? Cram { get; set; }              // STUB — ฌาปนกิจ federation
    public string? DropStatus { get; set; }
    public string? ElectionGroup { get; set; }
    public string? AgeMem60 { get; set; }
}

// ── Tab 1: ครอบครัว (u_tabpg_mem_spouse_info) ────────────────────────────────
public record ParentInfoDto(string? Father, string? Mother);

public class SpouseInfoDto
{
    public string? SpouseMemberNo { get; set; }
    public string? PrenameCode { get; set; }
    public string? SpouseName { get; set; }
    public string? SpouseSurname { get; set; }
    public string? OccupationCode { get; set; }
    public decimal? SalaryAmount { get; set; }
    public decimal? SalaryCalloan { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PositionCode { get; set; }
    public string? IdCard { get; set; }
    public string? TaxId { get; set; }
    public string? Workname { get; set; }
    public string? WorkAddress { get; set; }
    public string? WorkMoo { get; set; }
    public string? WorkSoi { get; set; }
    public string? WorkRoad { get; set; }
    public string? WorkTambol { get; set; }
    public string? WorkDistrictCode { get; set; }
    public string? WorkProvinceCode { get; set; }
    public string? WorkPostcode { get; set; }
    public string? WorkTelephone { get; set; }
}

// ── Tab 2: การทำงาน (u_tabpg_mem_detail_work_info) ───────────────────────────
public class WorkMainDto
{
    public string? MembershipNo { get; set; }
    public string? PositionLong { get; set; }
    public string? EmployeeStatus { get; set; }
    public DateTime? EndingcontractDate { get; set; }
    public string? KeepingGroupNo { get; set; }
    public string? LevelCode { get; set; }
    public string? SalaryRateCode { get; set; }
    public decimal? SalaryAmount { get; set; }
    public decimal? AcademicSalary { get; set; }
    public DateTime? WorkingDate { get; set; }
    public string? GroupPosition { get; set; }
    public string? RetireStatus { get; set; }
    public DateTime? RetireDate { get; set; }
    public string? OccupationCode { get; set; }
    public decimal? RemunerationAmount { get; set; }
    public string? SalaryId { get; set; }
    public string? DepartmentCode { get; set; }
    public decimal? SalaryReal { get; set; }
}

public class WorkAddressDto
{
    public string? MembershipNo { get; set; }
    public string? WorkAddress { get; set; }
    public string? WorkMoo { get; set; }
    public string? WorkSoi { get; set; }
    public string? WorkRoad { get; set; }
    public string? WorkTambol { get; set; }
    public string? WorkProvinceCode { get; set; }
    public string? WorkDistrictCode { get; set; }
    public string? WorkPostcode { get; set; }
    public string? WorkTelephone { get; set; }
}

// ── Tab 3: สมาชิกโอนมา (u_tabpg_mem_own) ─────────────────────────────────────
public class OwnInfoDto
{
    public string? MembershipNo { get; set; }
    public decimal? OtherSaving { get; set; }
    public decimal? OwnTotalLoan { get; set; }
    public string? MatiDetail { get; set; }
    public DateTime? FirstDate { get; set; }
}

// ── Tab 4: ผู้รับผลประโยชน์ (u_tabpg_mem_detail_gain_detail) ──────────────────
public class GainDetailDto
{
    public string? MembershipNo { get; set; }
    public string? ChangeDocNo { get; set; }
    public string? Condition1 { get; set; }
    public decimal? OrderNumber { get; set; }
    public string? GainName { get; set; }
    public string? RelatedNa { get; set; }
    public DateTime? BookDate { get; set; }
    public string? GainAddress { get; set; }
    public decimal? GainPercent { get; set; }
    public string? GainIdCard { get; set; }
    public string? GainTelephone { get; set; }
    public string? GainStatusDesc { get; set; }
    public string? GainStatus { get; set; }      // '1' = ยกเลิก → row สีแดง
    public decimal? RecNo { get; set; }
    public DateTime? RecDate { get; set; }
}

// ── Tab 5: ปันผลเฉลี่ยคืน (u_tabpg_mem_detail_devidend_detail) ────────────────
public record DevidendYearDto(int AccountYear);   // account_year + 543 (พ.ศ.)

public class DevidendHeadDto
{
    public int? AccountYear { get; set; }
    public decimal? Dividend { get; set; }
    public string? DropDividend { get; set; }
    public decimal? AverageReturn { get; set; }
    public string? DropAverage { get; set; }
    public string? GroupPayCode { get; set; }
    public decimal? TotalInterest { get; set; }
    public decimal? TotalPay { get; set; }
    public decimal? FullInterest { get; set; }
    public string? BankAccNo { get; set; }
    public decimal? ShareRate { get; set; }       // *100
    public decimal? LonintRate { get; set; }      // *100
    public decimal? DivavrSeize { get; set; }
    public decimal? DivavrByshare { get; set; }
    public decimal? TotalMoneyReward { get; set; }
    public string? DropMoneyReward { get; set; }
    public decimal? SomtobAmount { get; set; }
    public string? BankCode { get; set; }
}

public record GotintDto(string? GotInt);          // unpivot m01..m12 → 12 แถว

public class DividendDetailDto
{
    public int? AccountYear { get; set; }
    public decimal? PreSeqNo { get; set; }
    public DateTime? PreOperateDate { get; set; }
    public string? PreItemType { get; set; }
    public decimal? PreShareValue { get; set; }
    public string? CalPreDate { get; set; }
    public decimal? PreDayCount { get; set; }
    public decimal? PreDividend { get; set; }
}

public class DevidendPaymentDto
{
    public int? AccountYear { get; set; }
    public string? MembershipNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? GroupPayCode { get; set; }
    public decimal? ItemAmount { get; set; }
    public string? BankCode { get; set; }
    public string? BankBranch { get; set; }
    public string? BankAccNo { get; set; }
    public string? PostStatus { get; set; }
    public DateTime? PostDate { get; set; }
    public string? PostRefno { get; set; }
    public string? AccountType { get; set; }
    public string? LoanContractNo { get; set; }
    public decimal? PrincipalAmount { get; set; }
    public decimal? InterestAmount { get; set; }
    public decimal? Balance { get; set; }
    public DateTime? InterestTo { get; set; }
    public string? ExtStatus { get; set; }
    public decimal? PostAmount { get; set; }
    public string? IspTypeCode { get; set; }
}

// ── Tab 6: ปันผลรวม (u_tabpg_mem_detail_devidend_detail_all) ──────────────────
public class DevidendAllDto
{
    public int? AccountYear { get; set; }
    public decimal? ShareRate { get; set; }
    public string? DropDividend { get; set; }     // 'งด' / '' → non-empty = row สีแดง
    public decimal? Dividend { get; set; }
    public decimal? LonintRate { get; set; }
    public string? DropAverage { get; set; }
    public decimal? AverageReturn { get; set; }
    public decimal? TotalMoneyReward { get; set; }
    public decimal? Expense { get; set; }
    public string? MemberGroupNo { get; set; }
    public string? MoneyTypeName { get; set; }
    public decimal? ItemAmount { get; set; }
    public string? BankCode { get; set; }
    public string? BankAccNo { get; set; }
    public decimal? Total { get; set; }
}

// ── Tab 7: บัญชีธนาคาร (u_tabpg_mem_bankinfo) ────────────────────────────────
public class BankInfoDto
{
    public string? MembershipNo { get; set; }
    public string? BankId { get; set; }
    public string? BankAccNo { get; set; }
    public string? PaidLoan { get; set; }
    public string? PaidDividen { get; set; }
    public string? ShareWithdraw { get; set; }
    public string? AtmLon { get; set; }
    public string? AtmDep { get; set; }
    public string? BankBranchId { get; set; }
    public string? MustcollLoan { get; set; }
    public decimal? SeqNo { get; set; }
    public string? PaidAgent { get; set; }
    public string? PaidSalary { get; set; }
}

// ── Tab 8: ATM (u_tabpg_mem_detail_atm) ──────────────────────────────────────
public class AtmDto
{
    public string? DepositAccountNo { get; set; }
    public string? BankCode { get; set; }
    public decimal? ApproveAmount { get; set; }
    public decimal? WithdrawableAmount { get; set; }
    public string? ModifyStatus { get; set; }
    public string? DropStatus { get; set; }
    public string? MembershipNo { get; set; }
    public string? NewSendStatus { get; set; }
    public string? CloseStatus { get; set; }
    public string? CurrentAccount { get; set; }
    public decimal? SeqNo { get; set; }
    public DateTime? DateRegis { get; set; }
}

// ── Tab 9: เบอร์มือถือ (u_tabpg_mem_mobile_number) ───────────────────────────
public class MobileDto
{
    public string? MembershipNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? BankId { get; set; }
    public string? MobileNumber { get; set; }
    public string? CloseStatus { get; set; }
    public string? MobileLon { get; set; }
    public string? MobileDep { get; set; }
    public string? MobileTrans { get; set; }
    public string? CloseStatusCb { get; set; }
    public string? MobileLonCb { get; set; }
    public string? MobileDepCb { get; set; }
    public string? MobileTransCb { get; set; }
    public string? EntryId { get; set; }
    public DateTime? EntryDate { get; set; }
    public string? EntryBr { get; set; }
}

// ── Tab 10: ประวัติสัมมนา (u_tabpg_mem_surminar) ─────────────────────────────
public class SurminarDto
{
    public string? MembershipNo { get; set; }
    public decimal? SeqNo { get; set; }
    public DateTime? Operate { get; set; }
    public string? Remark { get; set; }
}

// ════════════════════════════════════════════════════════════════════════════
//  G2 "สิทธิ/สวัสดิการ" DTOs (legacy u_tabpg_mem_* — read-only grids)
// ════════════════════════════════════════════════════════════════════════════

// ── G2 Tab 1: สวัสดิการ (u_tabpg_mem_detail_welfare — view_tel_mem_wef) ───────
public class WelfareDto
{
    public string? WefType { get; set; }
    public string? WefDesc { get; set; }
    public DateTime? OperateDate { get; set; }
    public decimal? TotalReceive { get; set; }
    public string? ApproveStatus { get; set; }
    public DateTime? ApproveDate { get; set; }
    public string? WefDetail { get; set; }
}

// ── G2 Tab 2: สมาคมฌาปนกิจ (u_tabpg_mem_detail_smk — sc_mem_m_member_cremation) ─
public class SmkDto
{
    public string? CremType { get; set; }    // 01=ครูไทย, 02=ชุมนุม (static combo)
    public string? CremMemno { get; set; }
}

// ── G2 Tab 3: ประกัน (u_tabpg_mem_detail_insurance_detail — sc_mem_m_insure) ──
public class InsureDto
{
    public string? MembershipNo { get; set; }
    public string? InsuranceNo { get; set; }
    public string? InsuranceType { get; set; }
    public string? RefContract { get; set; }
    public string? InsuranceDetail { get; set; }
    public decimal? InsuranceApprove { get; set; }
    public decimal? InsuranceBalance { get; set; }
    public decimal? InsurancePeriod { get; set; }
    public decimal? InsurancePeriodAmount { get; set; }
    public double?  LastPeriod { get; set; }
    public string? CancelStatus { get; set; }       // 0=ปกติ, 1=งดเก็บ (static combo)
    public decimal? PendingAmount { get; set; }
    public decimal? InsuranceArrearOld { get; set; }
    public decimal? InsuranceArrearPending { get; set; }
    public string? InsuranceStatus { get; set; }     // 0=ปกติ, 1=จบสัญญา (static combo)
    public DateTime? BeginingOfContract { get; set; }
    public decimal? InsuranceCost { get; set; }
    public DateTime? StartKeepDate { get; set; }
    public decimal? AdvanAmount { get; set; }
}

// ── G2 Tab 4-7: ผู้รับเงินสงเคราะห์ 1-4 (u_tabpg_mem_recipient_ss1..4) ────────
// ss1-3 = sc_mem_m_member_crem_gain (crem_type '01'/'02'/'03')
// ss4   = view_tel_det_crem_gain_04 (alias gaint_surname → gain_surname ให้ตรง DTO)
public class CremGainDto
{
    public decimal? SeqNo { get; set; }
    public string? Prename { get; set; }
    public string? GainName { get; set; }
    public string? GainSurname { get; set; }
    public string? RelatedNa { get; set; }
    public string? IdCard { get; set; }
    public string? AddressGain { get; set; }
    public string? EntryId { get; set; }
    public DateTime? EntryDate { get; set; }
}

// ── G2 Tab 8: ผู้ค้ำ/ผู้ใช้ค้ำ (u_tabpg_mem_member_refer) ─────────────────────
public class MemberReferDto
{
    public string? MembershipNoRef { get; set; }
    public string? MemberName { get; set; }
    public string? ConceernCode { get; set; }       // combo sc_mem_m_ucf_concern
    public string? EntryId { get; set; }
    public string? ReferStatus { get; set; }         // 0=ปกติ, 1=ยกเลิก → row แดง
    public string? MemberStatusCode { get; set; }    // 0=เป็นสมาชิก, 3=ลาออก → row แดง
    public string? CancelId { get; set; }
    public decimal? SeqNo { get; set; }
}

// ══════════════════════════════════════════════════════════════════════════════
// G3 "เงินกู้/หุ้น" 5 tabs
// ══════════════════════════════════════════════════════════════════════════════

// ── G3 Tab 1: รายละเอียดเงินกู้ (u_tabpg_mem_detail_loan_detail) ───────────────
// view_tel_det_lon (tran_to_coll!='1') UNION ALL คำขอ (sc_lon_m_loan_request)
// + JOIN sc_lon_m_rule (color_red/green/blue) + special-loan flag (get_loan_special_paid)
public class LoanDetailDto
{
    public string? MembershipNo { get; set; }
    public string? LoanContractNo { get; set; }
    public DateTime? BeginingOfContract { get; set; }
    public decimal? LoanApproveAmount { get; set; }
    public decimal? LoanInstallmentAmount { get; set; }    // จำนวนงวด
    public decimal? PeriodPaymentAmount { get; set; }
    public DateTime? LastCalcintDate { get; set; }
    public DateTime? LastAccessDate { get; set; }
    public string? TranToColl { get; set; }
    public decimal? LastPeriod { get; set; }
    public decimal? PrincipalBalance { get; set; }
    public decimal? YearTotalInterest { get; set; }
    public decimal? InterestArrear { get; set; }
    public string? LoanType { get; set; }
    public string? CloseStatus { get; set; }
    public string? AtmStatus { get; set; }
    public string? LoanLooping { get; set; }
    public string? LoanGroup { get; set; }            // 0=ปกติ,1=รับภาระหนี้,2=คำขอรอนุมัติ
    public string? LoanGroupCode { get; set; }        // '03' = เงินกู้พิเศษ
    public string? PayLoanPeriod { get; set; }        // '1' = รับเงินเป็นงวด
    public string? DropPaymentStatus { get; set; }    // combo loan_drop_status
    public string? AtmBalance { get; set; }           // "วงเงินที่กด ATM" / "คำขอ"
    public decimal? PendingAmount { get; set; }
    // ── สีตามประเภทเงินกู้ (sc_lon_m_rule RGB) + flag เงินกู้พิเศษจ่ายไม่ครบ ──
    public double? ColorRed { get; set; }
    public double? ColorGreen { get; set; }
    public double? ColorBlue { get; set; }
    public bool? SpecialUnpaid { get; set; }          // loan_group_code='03' & pay_period & approve > special_paid
}

// ── G3 Tab 2: หุ้นค้ำ (u_tabpg_mem_detail_share_coll) — sc_fund_mem ────────────
public class ShareCollDto
{
    public string? LoanContractNo { get; set; }
    public DateTime? OpenDay { get; set; }
    public decimal? PricipalBalance { get; set; }     // (sic) วงเงินกู้ — sc_fund_mem.pricipal_balance
    public decimal? PrincipalBalance { get; set; }    // หนี้คงเหลือ — sc_lon_m_loan_card.principal_balance
    public decimal? TotalBalance { get; set; }        // ยอดกองทุน
    public string? CloseStatus { get; set; }          // decode 1→C; combo fund_close_status; !='0' → row แดง
    public string? PaidReturnMethod { get; set; }     // combo sc_fund_ucf_return_method
    public DateTime? ReturnDate { get; set; }
    public string? FundLoanNo { get; set; }           // (sic alias) = fund_name
    public DateTime? LastAccessDate { get; set; }
}

// ── G3 Tab 3: สถานะหุ้น (u_tabpg_mem_detail_share_state) — header + grid ───────
public class ShareStateHeadDto
{
    public decimal? ShareStock { get; set; }          // ทุนเรือนหุ้น
    public decimal? ShareAmount { get; set; }         // หุ้นรายเดือน
    public decimal? PeriodRecrieve { get; set; }      // งวดล่าสุด
    public decimal? PendingAmt { get; set; }          // หุ้นเรียกเก็บ
    public string? KeepingStatus { get; set; }        // decode → ประมวลผลแล้ว/ยังไม่ประมวล
    public string? DropStatus { get; set; }           // decode → งดเก็บ/ปกติ
    public decimal? BeginBalance { get; set; }        // หุ้นยกมาต้นปี
    public decimal? PendingArrear { get; set; }       // หุ้นค้างเรียกเก็บ
}

public class ShareStateDto
{
    public decimal? SeqNo { get; set; }
    public DateTime? DivDate { get; set; }            // วันที่คิดปันผล
    public DateTime? OperateDate { get; set; }        // วันที่ทำรายการ (fpb_get_share_operate_date)
    public string? DocNo { get; set; }
    public string? ItemType { get; set; }             // รหัส ("XS" → font เขียว)
    public decimal? Period { get; set; }
    public string? ShareValueDecr { get; set; }       // pre-formatted (to_char) "ถอน"
    public string? ShareValueIncr { get; set; }       // pre-formatted (to_char) "เพิ่ม"
    public decimal? ShareAmount { get; set; }
    public decimal? ShareStock { get; set; }          // คงเหลือ
    public string? Remark { get; set; }
    public string? EntryId { get; set; }
    public DateTime? EntryDate { get; set; }
    public string? CancelStatus { get; set; }         // combo cancel_status
    public decimal? SignFlag { get; set; }            // < 0 → font แดง
}

// ── G3 Tab 4: งดส่งเงินกู้ (u_tabpg_mem_detail_drop_loan) — sc_mem_m_member_drop_loan ──
public class DropLoanDto
{
    public string? LoanType { get; set; }             // combo sc_lon_m_rule
}

// ── G3 Tab 5: หลักประกัน (u_tabpg_mem_detail_coll_detail) — sctel.getCalcCollUsed ──
//   "สัญญาที่สมาชิกคนนี้ไปค้ำให้คนอื่น" — 3 union (ปกติ / ภาระแทน / คำขอรออนุมัติ)
public class CollDetailDto
{
    public string? LoanContractNo { get; set; }       // เลขที่สัญญา
    public decimal? LoanOrder { get; set; }            // # (running seq ในกลุ่ม — window)
    public string? MembershipNo { get; set; }          // ทะเบียนผู้กู้
    public string? MemberName { get; set; }            // ชื่อ-สกุลผู้กู้
    public decimal? ShareStock { get; set; }           // ทุนเรือนหุ้น
    public decimal? PrincipalBalance { get; set; }     // ยอดคงเหลือ
    public decimal? UsedAmount { get; set; }           // วงเงินค้ำ
    public string? CollCurrent { get; set; }           // สถานะ combo coll_current (W/P/T/F/A)
    public string? LoanCode { get; set; }              // ลูกหนี้ combo sc_lon_m_ucf_loan_code
    public decimal? SumArr { get; set; }               // ต้นค้าง
    public decimal? SumInterrest { get; set; }         // ดอกค้าง
    // ── coloring (เลียน gv_detail_HtmlRowPrepared / ofSetLoanColor) ──
    public string? LoanGroup { get; set; }             // 0=ปกติ,1=ภาระแทน,2=คำขอ (group '2' → พื้นขาว font แดง)
    public string? LoanType { get; set; }
    public double? ColorRed { get; set; }              // sc_lon_m_rule RGB
    public double? ColorGreen { get; set; }
    public double? ColorBlue { get; set; }
    public string? MemberStatusCode { get; set; }      // สถานะผู้กู้ — !='0' → พื้นแดง (เมื่อ loan_code='0')
    // ── ported ไว้ครบแม้ viewer ไม่แสดง (faithful: เอามาก่อน) ──
    public decimal? ReqAmount { get; set; }            // = used_amount
    public decimal? CollUseAmount { get; set; }        // นับคนค้ำ (fp_get_count_coll / fp_get_count_collin_req)
    public decimal? CollEvaluateBalance { get; set; }  // post-calc C# (ไม่แสดง) — balance หาร จำนวนคนค้ำ
}

// ════════════════════════════════════════════════════════════════════════════
//  G4 "เรียกเก็บ" (3 tabs)  legacy parent i_menu_id 2005
// ════════════════════════════════════════════════════════════════════════════

// ── G4 Tab 1: การจ่ายเงิน (u_tabpg_mem_detail_money_payment) — sc_com_m_receipt + _item ──
//   1 ใบเสร็จ = หลายรายการ; ฟิลด์ระดับใบเสร็จ (money_name/bank_name/money_trans/buy_share/
//   total_payment/money_return) โชว์เฉพาะแถวแรก (decode getrow=1 → null แถวถัดไป)
//   money_type display = money_name + "(" + bank_name + ")" เฉพาะเมื่อมี bank_name (เลียน HtmlDataCellPrepared)
public class MoneyPaymentDto
{
    public string? ReceiptNo { get; set; }             // เลขที่ใบเสร็จ
    public DateTime? ReceiptDate { get; set; }         // วันที่ใบเสร็จ
    public DateTime? TransDate { get; set; }           // วันที่โอน (cheque_date)
    public string? MoneyName { get; set; }             // ชื่อประเภทเงิน (แถวแรก)
    public string? BankName { get; set; }              // ชื่อย่อ ธ. ที่ทำชำระ (แถวแรก)
    public decimal? MoneyTrans { get; set; }           // เงินโอนชำระ (แถวแรก)
    public decimal? BuyShare { get; set; }             // ซื้อหุ้น (แถวแรก)
    public decimal? GetRow { get; set; }               // ลำดับแถวในใบเสร็จ (window)
    public string? LoanContractNo { get; set; }        // เลขที่สัญญา (substr description 1..15)
    public decimal? PrincipalAmount { get; set; }      // เงินต้น
    public decimal? InterestAmount { get; set; }       // ดบ.
    public decimal? ItemAmount { get; set; }           // จำนวนเงิน
    public decimal? TotalPayment { get; set; }         // รวมชำระ (แถวแรก)
    public decimal? MoneyReturn { get; set; }          // เงินรอจ่ายคืน (แถวแรก)
}

// ── G4 Tab 2: เรียกเก็บรายเดือน (u_tabpg_mem_detail_monthly_return) — sc_kep_t_monthly_receive(+_det) ──
//   receive_year เก็บเป็น ค.ศ. → SQL +543 ให้เป็น พ.ศ.; ppm_date/ppm_amout จาก correlated subquery บน sc_com_m_receipt
public class MonthlyReturnDto
{
    public int? ReceiveYear { get; set; }              // ปี (พ.ศ.)
    public int? ReceiveMonth { get; set; }             // เดือน combo monthThLong2
    public string? MembershipNo { get; set; }
    public decimal? SeqNo { get; set; }
    public decimal? MoneyAmount { get; set; }          // ยอดเรียกเก็บ
    public decimal? MoneyAmountNot { get; set; }       // ยอดที่เก็บได้
    public decimal? UnkeepAmount { get; set; }         // ยอดที่เก็บไม่ได้ (filter > 0) — DarkRed
    public DateTime? PpmDate { get; set; }             // ตามมาชำระ (วันที่)
    public decimal? PpmAmout { get; set; }             // ตามมาชำระ(บาท) — สะกดตาม legacy
    public decimal? UnkeepReal { get; set; }           // คงค้าง — DarkRed
    public string? ReasonReturn { get; set; }          // เหตุผลการคืน
    public string? PpmStatus { get; set; }             // สถานะ combo kep_ppm_status (0/1)
}

// ── G4 Tab 2 popup: รายละเอียดใบเสร็จคืน (popMonthlyReturn) — banded grid เรียกเก็บ/เก็บได้/เก็บไม่ได้ ──
public class MonthlyReturnDetailDto
{
    public decimal? ReceiveSeq { get; set; }           // ซ่อน
    public string? KeepingTypeCode { get; set; }       // รหัส
    public string? ReceiveDescription { get; set; }    // รายการ
    public decimal? Period { get; set; }               // งวด
    public decimal? KeepingP { get; set; }             // ยอดเรียกเก็บ - เงินต้น (principal_of_loan)
    public decimal? KeepingI { get; set; }             // ยอดเรียกเก็บ - ดอกเบี้ย (interest)
    public decimal? KeepingA { get; set; }             // ยอดเรียกเก็บ - รวม (money_amount)
    public decimal? IncomeP { get; set; }              // ยอดเก็บได้ - เงินต้น (principal_not)
    public decimal? IncomeI { get; set; }              // ยอดเก็บได้ - ดอกเบี้ย (interest_not)
    public decimal? IncomeA { get; set; }              // ยอดเก็บได้ - รวม (money_amount_not)
    public decimal? UnkeepP { get; set; }              // ยอดเก็บไม่ได้ - เงินต้น (keeping_p − income_p)
    public decimal? UnkeepI { get; set; }              // ยอดเก็บไม่ได้ - ดอกเบี้ย
    public decimal? UnkeepA { get; set; }              // ยอดเก็บไม่ได้ - รวม
}

// ── G4 Tab 3: หักผ่านธนาคาร (u_tabpg_mem_detail_month_giro_detail) — sc_kep_monthly_giro_file ──
public class GiroYearDto { public int? ReceiveYear { get; set; } }   // ปี (พ.ศ. = +543) สำหรับ combo

public class GiroDetailDto
{
    public string? UserId { get; set; }
    public decimal? MoneyAmount { get; set; }          // ยอดเรียกเก็บประจำเดือน
    public decimal? PaidAmount { get; set; }           // ยอดหัก ณ ที่จ่าย
    public decimal? GiroAmount { get; set; }           // ยอดหักจากธนาคาร
    public decimal? Balance { get; set; }              // ยอดคงเหลือ
    public string? ReceiptStatus { get; set; }         // สถานะ (raw)
    public string? MembershipNo { get; set; }
    public int? ReceiveYear { get; set; }              // ค.ศ. (raw)
    public int? ReceiveMonth { get; set; }
    public decimal? SeqNo { get; set; }
}

// ════════════════════════════════════════════════════════════════════════════
//  G5 การเงิน/เงินฝาก (3 tabs) — legacy scteldet/tabs/u_tabpg_mem_detail_*
// ════════════════════════════════════════════════════════════════════════════

// ── G5 Tab 1: รายละเอียดเงินฝาก (u_tabpg_mem_detail_dept_detail) — sc_dep_m_creditor + _rule ──
//   close_status='C' → แถวสีแดง; deposit_balance_t แสดง "ปิดบัญชี" เมื่อ close_status='C'
//   ปุ่ม 🔍 / dbl-click → popup popDeptDetail (key = deposit_account_no ดิบ)
public class DepositListDto
{
    public string? DepositAccountNo { get; set; }          // key ดิบ → ส่งเข้า popup
    public string? DepositAccountNo2 { get; set; }         // เลขบัญชี (fp_form_depno)
    public string? DepositAccountName { get; set; }        // ชื่อบัญชี
    public string? DepositTypeCode { get; set; }
    public DateTime? DepositOpenedDate { get; set; }       // วันที่เปิดบัญชี
    public string? DepositType { get; set; }               // ประเภท (code-ชื่อ)
    public decimal? MonthlyDepositAmount { get; set; }     // หักรายเดือน (decode monthly_deposit_status)
    public decimal? DepositBalance { get; set; }           // (ซ่อน) — รวมยอด
    public decimal? WithdrawableAmount { get; set; }       // ยอดที่ถอนได้ (ซ่อน) — รวมยอด
    public decimal? ChequePendingAmount { get; set; }      // ยอดเช็ครอเคลียริ่ง (ซ่อน) — รวมยอด
    public decimal? DepositStandsecurityAmount { get; set; } // อายัดเงินฝาก (decode sequester_status)
    public decimal? LoanHoldingAmount { get; set; }        // ยอดค้ำเงินกู้
    public decimal? DepositBalanceT { get; set; }          // ยอดคงเหลือ (display "ปิดบัญชี" ถ้า close)
    public DateTime? LastCalcintDate { get; set; }         // วันที่คิดดอกเบี้ยล่าสุด
    public decimal? AccumulateInterest { get; set; }       // ดอกเบี้ยสะสม
    public string? CloseStatus { get; set; }               // 'C' = ปิดบัญชี → สีแดง
    public string? OfficerId { get; set; }                 // ผู้ทำรายการ (raw)
}

// ── G5 Tab 2: ข้อมูลเครดิต (u_tabpg_mem_detail_credit) — sc_mem_m_member_credit ──
public class CreditDto
{
    public string? MembershipNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? CreditCode { get; set; }                // รหัส → combo sc_mem_m_ucf_credit_management
    public string? CreditDesc { get; set; }                // รายละเอียด
    public string? CreditDetail { get; set; }              // subquery (legacy เก็บไว้ ไม่แสดงใน grid)
}

// ── G5 Tab 3: เงินรอจ่ายคืน (u_tabpg_mem_detail_money_return) — sc_fin_money_return ──
//   return_status=0 → แถวสีแดง; request_status='1' → เลือกแถว
public class MoneyReturnDto
{
    public string? MembershipNo { get; set; }
    public decimal? ItemNo { get; set; }
    public DateTime? OperateDate { get; set; }             // วันที่รายการ
    public decimal? MoneyReturn { get; set; }              // เงินคืน
    public string? ReturnMethod { get; set; }              // ระบบการคืน (subquery return_desc)
    public string? RequestMethod { get; set; }             // วิธีจ่ายคืน → combo sc_com_m_ucf_money_type
    public string? Refno1 { get; set; }                    // เลขที่อ้างอิง
    public string? Remark { get; set; }                    // หมายเหตุ
    public string? RequestBankid { get; set; }             // ธ.จ่ายคืน → combo sc_acc_m_ucf_bank
    public string? RequestBankac { get; set; }             // บช.จ่ายคืน
    public string? ReturnStatus { get; set; }              // การจ่ายคืน (0=รอจ่าย/1=จ่ายแล้ว) — 0 = แดง
    public string? RequestStatus { get; set; }             // เลือก (checkbox) — '1' = select
    public string? CancelStatus { get; set; }
    public string? PaidId { get; set; }                    // ผู้จ่าย (raw)
    public DateTime? TransDate { get; set; }               // วันที่โอน (cheque_date)
    public string? TransBank { get; set; }                 // ธนาคารโอน
    public string? ReturnDesc { get; set; }                // ประเภท
    public DateTime? ReturnDate { get; set; }              // วันที่คืน (fpb_fin_get_money_return_date)
}

// ── G5 popup popDeptDetail Tab 1: ข้อมูลเงินฝาก (u_tabpg_dept_detail_main) — sc_dep_m_creditor ──
public class DepositMainDto
{
    public string? MembershipNo { get; set; }              // ทะเบียน
    public string? MemberName { get; set; }                // ชื่อ-ชื่อสกุล (fp_get_member_name)
    public string? DepositTypeCode { get; set; }           // ประเภท ("code ชื่อ")
    public string? DepositAccountNo { get; set; }          // เลขที่บัญชี
    public string? DepositAccountName { get; set; }        // ชื่อบัญชี
    public string? PassbookNo { get; set; }                // สมุดคู่ฝาก
    public DateTime? DepositOpenedDate { get; set; }       // วันที่บัญชี
    public string? DepositObjective { get; set; }          // เพื่อ
    public decimal? DepositBalance { get; set; }           // ยอดคงเหลือ
    public decimal? WithdrawableAmount { get; set; }       // ยอดที่ถอนได้
    public decimal? WithdrawCount { get; set; }            // ถอน/เดือน
    public decimal? AccumulateInterest { get; set; }       // ด/บ สะสม
    public string? Remark { get; set; }                    // ข้อกำหนด
    public string? MonthlyIntStatus { get; set; }          // จ่าย ด/บ รายเดือน ('1' = ติ๊ก)
    public string? MonthlyDepositStatus { get; set; }      // การฝากเงินรายเดือน ('1' = ติ๊ก)
    public decimal? MonthlyDepositAmount { get; set; }     // จำนวนเงิน (ฝากรายเดือน)
    public DateTime? FroceCloseDate { get; set; }          // วันที่บังคับปิด (สะกดตาม legacy)
}

// ── G5 popup popDeptDetail Tab 2: การเคลื่อนไหว (u_tabpg_dept_detail_dept_detail) — sc_dep_m_creditor_item ──
//   default focus = แถวสุดท้าย; C_WAMOUNT (ถอน) = สีแดง; form ล่างตามแถวที่ focus
public class DepositMovementDto
{
    public decimal? SeqNo { get; set; }                    // ลำดับ
    public DateTime? OperateDate { get; set; }             // วันที่ทำรายการ
    public string? ReferToDepositDocNo { get; set; }       // อ้างอิง
    public string? ItemType { get; set; }
    public string? OfficerId { get; set; }                 // ผู้ทำรายการ → combo si_security_user (form ล่าง)
    public DateTime? LastAccessDate { get; set; }          // วันที่ทำรายการ (datetime, form ล่าง)
    public string? PrintCode { get; set; }                 // ประเภท
    public string? PrintCodeDesc { get; set; }             // print_code - desc (form ล่าง)
    public string? DepositItemDescription { get; set; }
    public decimal? CWamount { get; set; }                 // ถอน (sign_flag=-1) — สีแดง
    public decimal? CDamount { get; set; }                 // ฝาก (sign_flag=1)
    public decimal? TotalBalance { get; set; }             // คงเหลือ
}

// ── G5 popup popDeptDetail Tab 3: ภาระค้ำประกัน (u_tabpg_dept_detail_dept_detail_coll) — sc_lon_m_contract_coll ──
public class DepositCollDto
{
    public string? LoanContractNo { get; set; }            // เลขสัญญา
    public string? MembershipNo { get; set; }
    public string? MemberName { get; set; }                // ชื่อสมาชิก ("ทะเบียน - คำนำหน้าชื่อสกุล")
    public decimal? LoanApproveAmount { get; set; }        // วงเงินกู้
    public decimal? PrincipalBalance { get; set; }         // ยอดคงเหลือ
    public decimal? UsedAmount { get; set; }               // ยอดค้ำประกัน — รวมยอด
}

// ══ G6 "รายละเอียดอื่น" 6 tabs ═══════════════════════════════════════════════

// ── G6 Tab 1: สถานะสมาชิก (u_tabpg_mem_detail_status_detail — sc_mem_m_member_special) ──
//   row สีแดงเมื่อ debtor_code = '39' หรือ '๓๙'
public class StatusDetailDto
{
    public string? DebtorCode { get; set; }                // รหัส (combo sc_mem_m_ucf_debtor)
    public string? DebtorDesc { get; set; }                // รายละเอียดรหัส
    public string? DeptorDetail { get; set; }              // รายละเอียด (สะกดตาม legacy)
    public decimal? SeqNo { get; set; }
}

// ── G6 Tab 2: สถานะธุรการ (u_tabpg_mem_admstatus — sc_mem_m_membership_registered, single row) ──
//   checkbox '1'=ติ๊ก; ช่อง resolved-text default '[ไม่ระบุ]'; msg = KTM stub ''
public class AdmstatusDto
{
    public string? DropLoanemerStatus { get; set; }        // งดกู้ ฉ. ทั้งหมด
    public string? DropLoannormalStatus { get; set; }      // งดกู้ ส. ทั้งหมด
    public string? DropLoanspecStatus { get; set; }        // งดกู้ พ. ทั้งหมด
    public string? CollactelralStatus { get; set; }        // งดค้ำประกัน
    public string? ForceKeeping { get; set; }              // เรียกเก็บหนี้เมื่อลาออก
    public string? AdjPayroll { get; set; }                // แต่งสลิปเงินเดือน
    public string? AttLoanPermit { get; set; }             // ถูกลดทอนสิทธิกู้
    public string? ReceiptSendHome { get; set; }           // ส่งใบเสร็จที่บ้าน
    public string? ShareSequester { get; set; }            // อายัดหุ้น
    public string? CremStatus { get; set; }                // ส่งหักฌาปนกิจ
    public string? RepresentStatus { get; set; }           // ผู้แทน
    public string? CommitteeStatus { get; set; }           // กรรมการ
    public string? OfficialStatus { get; set; }            // เจ้าหน้าที่
    public string? AgentStatus { get; set; }               // ตัวแทนหักเงิน
    public string? InspectorStatus { get; set; }           // ผู้ตรวจสอบกิจการ
    public string? CollResign { get; set; }                // หลักประกันบกพร่อง
    public string? ReferKeep { get; set; }                 // ฝากเก็บได้เมื่อลาออก
    public string? ShareRemain { get; set; }               // คงค่าหุ้น
    public string? InternalAuditor { get; set; }           // ผู้ตรวจสอบภายใน
    public string? AdvisorPresident { get; set; }          // ที่ปรึกษาประธาน
    public string? RepresentivePosition { get; set; }      // ผู้แทนโดยตำแหน่ง
    public string? AdvisorCoop { get; set; }               // ที่ปรึกษาสหกรณ์
    public string? LonRestruc { get; set; }                // ปรับโครงสร้างหนี้
    // resolved-text (sub-select แก้ค่า)
    public string? DocPlaceStatus { get; set; }            // สถานที่ส่งเอกสาร
    public string? BranchId { get; set; }                  // สาขา (SQL มี แต่ UI ไม่แสดง)
    public string? DebtorCode { get; set; }                // โนติส
    public string? OtherSavingMember { get; set; }         // เป็นสมาชิกสอ.อื่น
    public string? ShareloanCode { get; set; }             // สถานะหุ้นหนี้
    public string? OtherCode { get; set; }                 // เกรดสมาชิก
    public string? OtherStatus { get; set; }               // สถานะอื่นๆ
    public string? Msg { get; set; }                       // ข้อความ (fp_get_msg_level_loan → stub '')
}

// ── G6 Tab 3: บันทึกหมายเหตุ (u_tabpg_mem_comment_log — sc_mem_m_member_memo) ──
public class CommentLogDto
{
    public string? MembershipNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? MemoCode { get; set; }                  // รหัส (combo sc_mem_m_ucf_memo)
    public string? MemoDetail { get; set; }                // รายละเอียด
    public DateTime? EntryDate { get; set; }               // วันที่บันทึก
    public string? EntryId { get; set; }                   // ผู้บันทึก (combo si_security_user)
    public string? EntryBr { get; set; }
    public string? EntryPc { get; set; }
    public decimal? MemoAmount { get; set; }
    public DateTime? OperateDate { get; set; }
    public string? DropEmer { get; set; }                  // งด ฉ
    public string? DropNorm { get; set; }                  // งด ส
    public string? DropSpec { get; set; }                  // งด พ
    public string? DropColl { get; set; }                  // งด ค้ำ
    public string? LonRestruc { get; set; }                // ปรับฯ
}

// ── G6 Tab 4: ทุนการศึกษา (u_tabpg_mem_detail_sch_detail — sc_sch_mem_regis) ──
//   row สีแดงเมื่อ approve_status = '0'
public class SchDetailDto
{
    public decimal? ReceiveYear { get; set; }              // ปีที่รับทุน (+543 พ.ศ. ใน SQL)
    public string? RequestmentNo { get; set; }             // KeyField
    public string? ReceiverType { get; set; }              // ประเภททุน (combo receiver_type)
    public string? SchDesc { get; set; }                   // ระดับชั้น
    public string? IdCard { get; set; }                    // บัตร ปชช. (mask)
    public string? SchName { get; set; }                   // ผู้รับทุน
    public decimal? SchReceive { get; set; }               // จำนวนเงิน
    public string? ApproveStatus { get; set; }             // สถานะ (combo approve_status)
    public string? PaymentTypeCode { get; set; }           // การรับเงิน (CASE-resolved)
    public string? PaymentName { get; set; }               // หมายเหตุ (CASE-resolved)
}

// ── G6 Tab 5: อายัด (u_tabpg_mem_detail_sequester — sc_mem_m_membership_sequester) ──
//   row highlighted เมื่อ sqter_share/div/aver/other/deed_status = '1'
public class SequesterDto
{
    public string? MembershipNo { get; set; }
    public decimal? SeqNo { get; set; }                    // ลำดับ
    public string? SqterStatus { get; set; }               // สถานะ (0=ปกติ/1=ยกเลิก)
    public string? SqterShare { get; set; }                // หุ้น
    public string? SqterDiv { get; set; }                  // ปันผล
    public string? SqterAver { get; set; }                 // เฉลี่ยคืน
    public string? SqterOther { get; set; }                // เงินอื่นๆ
    public string? DeedStatus { get; set; }                // อายัดโฉนด
    public DateTime? BeginDate { get; set; }               // วันที่เริ่ม
    public DateTime? EndDate { get; set; }                 // วันที่ถอนอายัด
    public string? MoneyTypeId { get; set; }               // กลุ่มการอายัด (SZE/REV/180)
    public string? Department { get; set; }                // หน่วยงานที่นำส่งเงิน
    public string? Court { get; set; }                     // ศาล
    public string? NumberOfCase { get; set; }              // หมายเลขคดี
    public string? Plaintiff { get; set; }                 // โจทย์
    public string? Defendant { get; set; }                 // จำเลย
    public string? AddressDesc { get; set; }               // ที่อยู่
    public string? Remark { get; set; }                    // รายละเอียด
    public string? Condition { get; set; }                 // เงื่อนไข
    public decimal? FeeAmount { get; set; }                // ค่าธรรมเนียม
    public string? ChequeNo { get; set; }                  // เลขเช็ค
    public string? PrenameGroup { get; set; }              // หัวหน้าหน่วย
}

// ── G6 Tab 6: ดำเนินคดี (u_tabpg_mem_detail_law_prosec — sc_law_prosecutions) grid + popup ──
public class LawProsecDto
{
    public string? ProsecNo { get; set; }                  // เลขที่แฟ้ม (KeyField)
    public string? CancelStatus { get; set; }              // สถานะ (0=ปกติ/1=ยกเลิกแล้ว)
    public DateTime? OperateDate { get; set; }             // วันส่งคดี
    public string? MemberMain { get; set; }
    public DateTime? ProsecDate { get; set; }              // วันที่ฟ้อง
    public string? MembermainName { get; set; }
    public decimal? AllPrincipalBalance { get; set; }      // ตง. ก่อนฟ้อง
    public decimal? AllInterestArrear { get; set; }        // ดบ. ก่อนฟ้อง
    public decimal? AllAssetAmount { get; set; }           // ทุนทรัพย์ฟ้อง
    public string? Lawyer { get; set; }                    // ทนาย
    public string? Remark { get; set; }
    public string? CourtName { get; set; }                 // ศาลที่รับฟ้อง
    public string? ResignCode { get; set; }                // สาเหตุพ้นสภาพ (combo sc_mem_m_ucf_resign_cause)
}

// ══ popup ดำเนินคดี (popLaw) 11 sub-tabs ═════════════════════════════════════

// sub 1: ค่าธรรมเนียม/ประกัน (deposit_collection — sc_law_tadnen_kadee_fee) grid
public class LawDepositCollectionDto
{
    public string? ProsecNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? InsuranceType { get; set; }             // ประเภท (combo sc_mem_m_insure_rule)
    public DateTime? InsuranceDate { get; set; }           // วันที่
    public decimal? FeeAmount { get; set; }                // จำนวนเงิน
    public string? Remark { get; set; }                    // หมายเหตุ
    public string? CancelStatus { get; set; }              // สถานะ (0=ปกติ/1=ยกเลิก)
    public string? InsuranceNo { get; set; }               // เลขอ้างอิง
    public decimal? Total { get; set; }                    // คงเหลือ (fp_proc_bal_fee → inline subquery)
}

// sub 2: จำเลย (collateral_detail — sc_law_prosec_defendants) grid
public class LawCollateralDetailDto
{
    public string? ProsecNo { get; set; }
    public decimal? SeqNo { get; set; }
    public decimal? ItemOrder { get; set; }                // ลำดับการฟ้อง
    public string? MembershipNo { get; set; }              // เลขทะเบียน
    public string? DefendantName { get; set; }             // ชื่อสมาชิกหรือชื่อจำเลย
    public string? DefendantType { get; set; }             // ประเภทจำเลย (M/C/G/P)
}

// sub 3: ภาระหนี้คงเหลือตามคำพิพากษา (loan_detailstatus — sc_law_prosec_loan) grid
public class LawLoanDetailStatusDto
{
    public string? ProsecNo { get; set; }
    public string? LoanContractNo { get; set; }            // เลขที่สัญญา
    public decimal? ProcPrincipalBalance { get; set; }     // เงินต้น
    public decimal? ProcInterestArrear { get; set; }       // ดอกเบี้ยคำนวณ
    public DateTime? LastCalcintDate { get; set; }         // วันที่ล่าสุด
    public decimal? ProcAllAssetAmount { get; set; }       // รวม (NULL ใน SQL)
    public decimal? InterestArrear { get; set; }           // ดอกเบี้ยค้าง
}

// sub 4: ดำเนินคดี (dum_nern_kadee — sc_law_tad_nenkadee_operate) grid — DEFAULT tab
public class LawDumNernKadeeDto
{
    public string? ProsecNo { get; set; }
    public decimal? SeqNo { get; set; }                    // ลำดับ
    public DateTime? OperateDate { get; set; }             // วันที่ดำเนินการ
    public string? OperateTime { get; set; }
    public string? Description { get; set; }               // คำอธิบายและขบวนการ (static 13 รายการ)
    public string? Remark { get; set; }                    // หมายเหตุ
}

// sub 5 & 7 & 9: หัวเรื่องคดี (sc_law_tad_nenkadee_head) — form single row (ใช้ร่วม 3 แท็บ)
public class LawKadeeHeadDto
{
    public string? ProsecNo { get; set; }
    // pipagsa_detail (คำพิพากษา)
    public string? KadeeResult { get; set; }               // คำพิพากษา(ย่อ)
    public string? KadeeDum { get; set; }                  // เลขที่คดีดำ
    public string? KadeeDang { get; set; }                 // เลขที่คดีแดง
    public DateTime? PipakSaDate { get; set; }             // วันที่พิพากษา
    public DateTime? TumYumDate { get; set; }              // วันที่ทำยอมความ
    public DateTime? TalangKumPipaksaDate { get; set; }    // วันที่แถลงขอคัดคำพิพากษา
    public DateTime? TalangFeeDate { get; set; }           // แถลงขอรับค่าธรรมเนียมศาลคืนเมื่อ
    public DateTime? NutRecTalang { get; set; }            // รับคืนเมื่อ
    public DateTime? TalangDocReturndate { get; set; }     // แถลงขอรับเอกสารคืนเมื่อ
    public DateTime? RecTalangDocReturn { get; set; }      // รับคืนจากศาลเมื่อ
    public DateTime? OutPagKupKadee { get; set; }          // ขอให้ศาลออกบังคับคดี
    public DateTime? NumMuyOutPagKup { get; set; }         // นำหมายบังคับคดี
    public DateTime? NameOfficerKadee { get; set; }        // ตั้งเจ้าพนักงานบังคับคดี
    // numphong_detail (การนำฟ้อง)
    public string? LayerName { get; set; }                 // ชื่อทนาย
    public string? TranName { get; set; }                  // ชื่อผู้รับมอบ
    public string? SalName { get; set; }                   // ชื่อศาล
    public string? LayerNameJumley { get; set; }           // ชื่อทนายจำเลย
    public string? KramType { get; set; }                  // ความ (combo แพ่ง/อายา)
    public string? JodName { get; set; }                   // ชื่อโจทก์
    public DateTime? NumMuySt { get; set; }                // วันที่นำหมายครั้งที่ 1
    public string? ResultNumMuySt { get; set; }            // ผลการนำหมายครั้งที่ 1
    public DateTime? NumMuyNd { get; set; }                // วันที่นำหมายครั้งที่ 2
    public string? ResultNumMuyNd { get; set; }            // ผลการนำหมายครั้งที่ 2
    public string? OperateOther { get; set; }              // ดำเนินการอื่นๆ
    public DateTime? DateDoc { get; set; }                 // วันที่ยื่นบัญชีระบุพยานและส่งเอกสาร
    public DateTime? NutSong { get; set; }                 // นัดชี้สองสถานหรือนัดพร้อม
    public DateTime? CompDocDate { get; set; }             // ครบยื่นคำให้การ
    public string? RemarkSt { get; set; }                  // หมายเหตุ 1
    public string? RemarkNd { get; set; }                  // หมายเหตุ 2
    // bungkub_pipagsa (บังคับคดี)
    public string? LawyerBungKubKadee { get; set; }        // ทนายความที่บังคับคดี
    public DateTime? OfficerKadeeDate { get; set; }        // วันที่ออกหมายตั้งเจ้าพนักงานบังคับคดี
    public DateTime? DefYedZep { get; set; }               // วันที่ตั้งเรื่องยึดทรัพย์
    public string? BungKubKadeeJungwat { get; set; }       // สำนักงานบังคับคดีจังหวัด
    public string? PleaceYed { get; set; }                 // ที่ตั้งสำนักงานบังคับคดี
    public decimal? CostYed { get; set; }                  // ค่าใช้จ่าย
    public string? ItemYed { get; set; }                   // รายการทรัพย์สินที่ยึด
}

// sub 6: หนังสือแจ้งการชำระ (book_alertpay — sc_law_tadnen_kadee_notice) grid
public class LawBookAlertpayDto
{
    public string? ProsecNo { get; set; }
    public decimal? SeqNo { get; set; }                    // ครั้งที่
    public DateTime? LetterDate { get; set; }              // วันที่หนังสือ
    public string? OwnerName { get; set; }                 // ชื่อทนายความ
    public string? ResultBook { get; set; }
    public string? Header { get; set; }
    public decimal? PrinAmount { get; set; }               // เงินที่ค้าง
    public string? DocNo { get; set; }                     // เลขที่หนังสือ
    public DateTime? LoanAtDate { get; set; }
    public string? EntryId { get; set; }                   // ผู้บันทึก
    public DateTime? EntryDate { get; set; }               // วันที่บันทึก
}

// sub 8: จำเลย (jumley_detail — sc_law_prosec_defendants) grid
public class LawJumleyDetailDto
{
    public string? ProsecNo { get; set; }
    public decimal? SeqNo { get; set; }                    // ลำดับ
    public decimal? ItemOrder { get; set; }                // จำเลยที่
    public string? DefendantName { get; set; }             // ชื่อ - นามกุล
    public string? Status { get; set; }                    // สถานะ (0=ปกติ/1=พ้นสภาพ)
    public string? CardId { get; set; }                    // เลขที่บัตร
    public string? Job { get; set; }
    public string? AddressNo { get; set; }
    public string? Moo { get; set; }
    public string? Road { get; set; }
    public string? Soi { get; set; }
    public string? Tambol { get; set; }
    public string? ProvinceCode { get; set; }
    public string? DistinctCode { get; set; }
    public string? PostCode { get; set; }
    public string? Telephone { get; set; }                 // โทรศัพท์
}

// sub 10: ประเมินราคาที่ดิน (land_appraisal — cascade) — head form + detail grid
public class LawLandAppraisalHeadDto
{
    public string? ProsecNo { get; set; }
    public string? ItemCode { get; set; }                  // ครั้งที่
    public string? Tidin { get; set; }                     // เอกสารสิทธิ์ที่ดิน (combo นส.3/นส.3ก/นส.4ก)
    public string? Building { get; set; }                  // สิ่งปลูกสร้าง
}

public class LawLandAppraisalDetailDto
{
    public string? ProsecNo { get; set; }
    public string? ItemTypeCode { get; set; }              // ประเภทการประเมิน (1=สหกรณ์/2=จพง.บังคับคดี/3=กรมที่ดิน)
    public decimal? SeqNo { get; set; }
    public decimal? Area { get; set; }                     // เนื้อที่(ตร.ว.)
    public decimal? Space { get; set; }                    // พื้นที่ใช้สอย(ตร.ม.)
    public decimal? PricePerUnit { get; set; }
    public decimal? PricePerMeter { get; set; }
    public string? ItemCode { get; set; }
    public decimal? LandParcelAmount { get; set; }         // ราคาทั้งแปลง = area * price_per_unit
    public decimal? TotalPriceSpace { get; set; }          // ราคารวม = space * price_per_meter
    public decimal? TidinAndBuildingAmount { get; set; }   // ราคาที่ดินรวมสิ่งปลูกสร้าง
}

// sub 11: ขายทอดตลาด/บังคับคดี (bung_kub_kadee — cascade) — head form + detail grid
public class LawBungKubKadeeHeadDto
{
    public string? ProsecNo { get; set; }
    public string? SeqNoYed { get; set; }                  // ครั้งที่ยึด
    public string? BungKubKadeJungwat { get; set; }        // สำนักงานบังคับคดี
    public string? ResultSale { get; set; }                // ผลการขาย
    public decimal? SaleAmount { get; set; }               // ในราคา
    public string? KadeeStatus { get; set; }               // คดีอยู่ระหว่าง (combo 0/1/2)
    public DateTime? OwnershipDate { get; set; }           // โอนกรรมสิทธิ์เมื่อวันที่
    public DateTime? SaleReceiveDate { get; set; }         // วันที่รับเงินจากการขาย
    public decimal? SaleAmountCoop { get; set; }           // สหกรณ์ประกาศขายในราคา
}

public class LawBungKubKadeeDetailDto
{
    public string? ProsecNo { get; set; }
    public decimal? SeqNo { get; set; }                    // ครั้งที่
    public string? SeqNoYed { get; set; }
    public DateTime? OperateDate { get; set; }             // วันประกาศขายทอดตลาด
    public decimal? SaleAmount { get; set; }               // ราคาขาย
}

// ════════════════════════════════════════════════════════════════════════════
//  G7 "รายการแก้ไข" (14 tabs) — DTOs (ทุก tab = read-only change-log grid)
// ════════════════════════════════════════════════════════════════════════════

// tab 1: ประวัติเปลี่ยนหลักประกัน (chg_coll_history — sc_lon_m_coll_change_head/det)
public class CollChangeHistoryDto
{
    public string? ChangeDocNo { get; set; }               // เลขที่คำขอ (merge)
    public string? MembershipNo { get; set; }
    public DateTime? ApproveDate { get; set; }             // วันที่อนุมัติ
    public string? MemberName { get; set; }
    public string? LoanContractNo { get; set; }            // เลขสัญญา (merge)
    public DateTime? BeginingOfContract { get; set; }
    public decimal? PrincipalBalance { get; set; }
    public string? OldCollateralRefno { get; set; }        // ผู้ค้ำเดิม-ทะเบียน
    public string? OldCollateralDescription { get; set; }  // ผู้ค้ำเดิม-ชื่อ
    public string? NewCollateralRefno { get; set; }        // ผู้ค้ำใหม่-ทะเบียน
    public string? NewCollateralDescription { get; set; }  // ผู้ค้ำใหม่-ชื่อ
    public decimal? NewCollateralAmount { get; set; }
    public string? Remark { get; set; }
    public string? ChangeStatus { get; set; }
    public string? ChangeStatusName { get; set; }
    public string? OperateType { get; set; }               // NC/DL/NW/CG (สี)
    public string? ApproveId { get; set; }                 // ผู้อนุมัติ
    public string? EntryId { get; set; }                   // ผู้ทำรายการ
    public DateTime? EntryDate { get; set; }               // วันที่บันทึก
}

// tab 2: เปลี่ยนรหัสโนติส (chg_debtor_code — sc_mem_edit_debtor_code)
public class DebtorCodeChgDto
{
    public decimal? SeqNo { get; set; }
    public DateTime? OperateDate { get; set; }             // วันที่เปลี่ยน
    public string? PreDebtorDesc { get; set; }             // โนติสเดิม
    public string? DebtorDesc { get; set; }                // โนติสใหม่
    public string? EntryId { get; set; }                   // ผู้ทำรายการ
    public string? Remark { get; set; }                    // หมายเหตุ
}

// tab 3/4: เปลี่ยนยอดชำระเงินกู้/หุ้นรายเดือน (chg_loan/share_send_month — view_tel_det_chg)
public class SendMonthChgDto
{
    public DateTime? ApproveDate { get; set; }             // วันที่
    public string? LoanContractNo { get; set; }            // อ้างอิง
    public decimal? PeriodOld { get; set; }                // ยอดชำระเก่า
    public decimal? PeriodNew { get; set; }                // ยอดชำระใหม่
    public string? ReasonDesc { get; set; }                // หมายเหตุ
}

// tab 5: เปลี่ยนสถานะ/บันทึกช่วยจำ (chg_memo_status — sc_mem_m_member_permit_changed)
public class MemoStatusChgDto
{
    public DateTime? EntryDate { get; set; }               // วันที่เปลี่ยน
    public string? PermitName { get; set; }                // รหัสสถานะ
    public string? PermitDesc { get; set; }                // คำอธิบาย (getcoltext จาก column comment)
    public string? EntryId { get; set; }                   // ผู้ทำรายการ
    public string? RemarkDesc { get; set; }                // หมายเหตุ
}

// tab 6: เปลี่ยนโครงการหุ้น-กู้ (chg_shareloan_code — sc_mem_edit_shareloan_code)
public class ShareloanCodeChgDto
{
    public decimal? SeqNo { get; set; }
    public DateTime? OperateDate { get; set; }             // วันที่เปลี่ยน
    public string? PreShareloanDesc { get; set; }          // โครงการเดิม
    public string? ShareloanDesc { get; set; }             // โครงการใหม่
    public string? EntryId { get; set; }
    public string? Remark { get; set; }
}

// tab 7: ประวัติเปลี่ยนเกรด (chg_grade_history — sc_mem_edit_other_code)
public class GradeHistoryChgDto
{
    public decimal? SeqNo { get; set; }
    public DateTime? OperateDate { get; set; }             // วันที่เปลี่ยน
    public string? PreotherDesc { get; set; }              // เกรดเดิม
    public string? OtherDesc { get; set; }                 // เกรดใหม่
    public string? EntryId { get; set; }
    public string? Remark { get; set; }
}

// tab 8: เปลี่ยนสถานะอื่น (chg_other_status — sc_mem_edit_other_status)
public class OtherStatusChgDto
{
    public decimal? SeqNo { get; set; }
    public DateTime? OperateDate { get; set; }             // วันที่เปลี่ยน
    public string? PreotherStatusDesc { get; set; }        // สถานะเดิม
    public string? OtherStatusDesc { get; set; }           // สถานะใหม่
    public string? EntryId { get; set; }
    public string? Remark { get; set; }
}

// tab 9: เปลี่ยนการออมอื่น (chg_ot_saving_member — sc_mem_edit_other_saving_member)
public class OtSavingMemberChgDto
{
    public decimal? SeqNo { get; set; }
    public DateTime? OperateDate { get; set; }             // วันที่เปลี่ยน
    public string? PreSavingDesc { get; set; }             // การออมเดิม
    public string? SavingDesc { get; set; }                // การออมใหม่
    public string? EntryId { get; set; }
    public string? Remark { get; set; }
}

// tab 10: ประวัติเปลี่ยนที่อยู่ (addresshistory — sc_mem_edit_address)
public class AddressHistoryDto
{
    public DateTime? OperateDate { get; set; }             // วันที่
    public string? AddressType { get; set; }               // 0=ปัจจุบัน/1=ทะเบียนบ้าน/2=ที่ทำงาน
    public string? PreEdit { get; set; }                   // ที่อยู่ก่อนเปลี่ยน
    public string? PostEdit { get; set; }                  // ที่อยู่หลังเปลี่ยน
    public string? EntryId { get; set; }
    public DateTime? EntryDate { get; set; }
}

// tab 11: ประวัติเปลี่ยนชื่อ-สกุล (namehistory — sc_mem_edit_name)
public class NameHistoryDto
{
    public DateTime? OperateDate { get; set; }             // วันที่
    public string? DocEdit { get; set; }                   // เลขอ้างอิง
    public string? CNamePre { get; set; }                  // ชื่อก่อนเปลี่ยน
    public string? CNameEdit { get; set; }                 // ชื่อหลังเปลี่ยน
    public string? EntryId { get; set; }
    public DateTime? EntryDate { get; set; }
}

// tab 12: ประวัติย้ายหน่วยงาน (movejobhistory — sc_mem_edit_group)
public class MoveJobHistoryDto
{
    public DateTime? OperateDate { get; set; }             // วันที่ย้าย
    public string? DocEdit { get; set; }                   // เลขที่คำขอ
    public string? PreMemberGroupNo { get; set; }          // หน่วยงานเดิม
    public string? MemberGroupNo { get; set; }             // หน่วยงานใหม่
    public string? PreMemberGroupName { get; set; }        // ชื่อหน่วยงานเดิม
    public string? MemberGroupName { get; set; }           // ชื่อหน่วยงานใหม่
    public DateTime? EntryDate { get; set; }               // วันเวลาที่บันทึก
    public string? EntryId { get; set; }
}

// tab 13: ประวัติเปลี่ยนเงินเดือน (history_salary — sc_mem_edit_salary)
public class HistorySalaryDto
{
    public DateTime? OperateDate { get; set; }             // วันที่
    public decimal? PreSalaryAmount { get; set; }
    public decimal? SalaryAmount { get; set; }
    public decimal? PreAcademicSalary { get; set; }
    public decimal? AcademicSalary { get; set; }
    public decimal? PreRemunerationAmount { get; set; }
    public decimal? RemunerationAmount { get; set; }
    public decimal? PreSalaryReal { get; set; }
    public decimal? SalaryReal { get; set; }
    public string? EntryId { get; set; }
    public DateTime? EntryDate { get; set; }
    public string? EntryBr { get; set; }                   // สาขา (combo sc_com_m_branch)
}

// tab 14: ประวัติเปลี่ยนสิทธิ์ (permit_changed — sc_mem_m_member_permit_changed)
public class PermitChangedDto
{
    public decimal? SeqNo { get; set; }
    public DateTime? OperateDate { get; set; }             // วันที่
    public string? OldStatus { get; set; }                 // สถานะยกเลิก (check)
    public string? NewStatus { get; set; }                 // สถานะใช้งาน (check)
    public string? PermitName { get; set; }                // สิทธิ์ (→ label ที่ razor)
    public string? EntryId { get; set; }
    public DateTime? EntryDate { get; set; }
    public string? RemarkDesc { get; set; }
}

// ════════════════════════════════════════════════════════════════════════════
//  G8 E-Document — ทะเบียนสมาชิก (legacy u_tabpg_edc_memregis, tab เดียว)
//  grid sc_edoc_mem + ปุ่มเปิดเอกสาร (popup PDF/รูป จาก edoc server)
// ════════════════════════════════════════════════════════════════════════════
// tab: เอกสารทะเบียนสมาชิก (sc_edoc_mem — key: application_form_no;doc_type;page_no)
public class EdocMemDto
{
    public string? ApplicationFormNo { get; set; }         // เลขที่เอกสาร/ใบคำขอ/สัญญา
    public string? DocType { get; set; }                   // ประเภท (code)
    public string? DocTypeName { get; set; }               // ประเภท (desc — sc_edoc_m_ucf_mem)
    public string? Remark { get; set; }                    // หมายเหตุ
    public DateTime? EntryDate { get; set; }               // วันที่
    public string? EntryId { get; set; }                   // ผู้ทำ
    public decimal? PageNo { get; set; }                   // หน้าที่
    public string? Filename { get; set; }                  // ชื่อไฟล์ ("DELETED" = ถูกลบ)
}

// ผลการเปิดเอกสาร (legacy popPDF.popEdocument) — url เอกสาร หรือ ข้อความแจ้งถูกลบ
public class EdocPdfResult
{
    public string? Url { get; set; }                       // src ของ iframe (edoc server) — null=ไม่มีไฟล์
    public bool IsDeleted { get; set; }                    // filename == "DELETED"
    public string? DeletedMessage { get; set; }            // ข้อความแจ้งถูกลบ (พร้อมผู้ลบ+เวลา)
}

// ════════════════════════════════════════════════════════════════════════════
//  popup แสดงรายละเอียดกองทุนผู้ค้ำ (legacy scteldet/pops/popShareCollDetail — 3 sub-tab)
//  key = loan_contract_no (จาก G3 Tab 2 หุ้นค้ำ). เปิดจากปุ่ม 🔍 / dbl-click แถว
// ════════════════════════════════════════════════════════════════════════════

// sub 1: รายละเอียดกองทุน (u_tabpg_share_coll_detail — sc_fund_mem) form single row
public class ShareCollDetailMainDto
{
    public string? LoanContractNo { get; set; }            // เลขที่สัญญา
    public DateTime? OpenDay { get; set; }                 // วันที่เริ่ม
    public decimal? PricipalBalance { get; set; }          // วงเงินกู้ (sic — sc_fund_mem.pricipal_balance)
    public decimal? TotalBalance { get; set; }             // ยอดกองทุน
    public string? CloseStatus { get; set; }               // สถานะ (decode 1→C; combo fund_close_status)
    public string? PaidReturnMethod { get; set; }          // วิธีการคืน (combo sc_fund_ucf_return_method)
    public DateTime? ReturnDate { get; set; }              // วันที่คืน
    public string? FundLoanNo { get; set; }                // ประเภทกองทุน (sic alias) = fund_name (text)
}

// sub 2: รายการเคลื่อนไหว (u_tabpg_share_coll_detail_state — sc_fund_mem_detail) grid
public class ShareCollStateDto
{
    public string? MembershipNo { get; set; }
    public string? LoanContractNo { get; set; }
    public decimal? SeqNo { get; set; }                    // ลำดับ (KeyField)
    public DateTime? OperateDate { get; set; }             // วันที่รายการ
    public string? ItemType { get; set; }                  // รหัส (combo sc_mem_m_ucf_share_item_type2)
    public string? RefDocNo { get; set; }                  // เลขที่อ้างอิง
    public string? LoanType { get; set; }
    public decimal? PrincipalAmountI { get; set; }         // รับ (decode sign_flag=1)
    public decimal? PrincipalAmountP { get; set; }         // จ่าย (decode sign_flag=-1)
    public decimal? Balance { get; set; }                  // คงเหลือ
    public string? UserId { get; set; }                    // ผู้ทำรายการ
}

// sub 3a: จ่ายคืน (u_tabpg_share_coll_fund gvFundRet — sc_lon_m_req_fund_ret) grid
public class ShareCollFundRetDto
{
    public string? LoanRequestmentNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? LoanContractNo { get; set; }            // เลขสัญญา
    public decimal? FundRet { get; set; }                  // คืนกองทุน (sum)
    public decimal? ApproveAmount { get; set; }            // วงเงินทุน
}

// sub 3b: เก็บเพิ่ม (u_tabpg_share_coll_fund gvFundNew — sc_lon_m_req_fund_new) grid
public class ShareCollFundNewDto
{
    public string? LoanRequestmentNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? LoanContractNo { get; set; }            // เลขสัญญา
    public decimal? FundCur { get; set; }                  // กองทุนปัจจุบัน (sum)
    public decimal? FundNew { get; set; }                  // กองทุนใหม่ (sum)
    public decimal? FundAdd { get; set; }                  // เก็บเพิ่ม (sum)
    public decimal? FundExtra { get; set; }                // เพิ่ม 1% (สรุปไว้ — legacy comment ปิด column)
    public decimal? ApproveAmount { get; set; }            // วงเงินทุน
}

// ════════════════════════════════════════════════════════════════════════════
//  popup แสดงรายละเอียดเงินกู้ (legacy scteldet/pops/popLoan_detail — 9 sub-tab)
//  key = loan_contract_no. เปิดจากปุ่ม 🔍 / dbl-click ใน G3 Tab 1 รายละเอียดเงินกู้
// ════════════════════════════════════════════════════════════════════════════

// sub 0: รายละเอียดเงินกู้ (u_tabpg_loan_detail_loan_detail_main) form single row
public class LoanDetailMainDto
{
    public decimal? LoanRequestAmount { get; set; }        // วงเงินขอกู้
    public DateTime? BeginingOfContract { get; set; }      // เริ่มสัญญา (sic — Oracle spelling)
    public decimal? ContractInterestRate { get; set; }     // ด/บ สัญญา
    public string? LoanPaymentTypeCode { get; set; }       // รูปแบบ (combo loan_payment_type)
    public decimal? PeriodPaymentAmount { get; set; }      // ชำระต่องวด
    public DateTime? LastAccessDate { get; set; }          // วันที่ล่าสุด
    public decimal? TotalInterest { get; set; }            // ดอกเบี้ยรวม
    public string? DropPaymentStatus { get; set; }         // สถานะ (combo loan_drop_status2)
    public decimal? FixedPayment { get; set; }             // ยอดคงที่
    public decimal? LastPeriod { get; set; }               // งวดล่าสุด
    public decimal? InterestArrear { get; set; }           // ด/บ ค้าง
    public DateTime? LastCalcintDate { get; set; }         // วันที่คิดดอก
    public decimal? PeriodCompomise { get; set; }          // งวดที่ผ่อนผัน (sic)
    public DateTime? DateCompomise { get; set; }           // วันที่เริ่มผ่อนผัน
    public decimal? AccuCompomise { get; set; }            // ผ่อนผันสะสม
    public DateTime? StartKeepDate { get; set; }           // วันเริ่มเก็บ
    public decimal? InterestRate { get; set; }             // อัตรา ด/บ (%) = pka_lon_intsrv.fp_intrate_conno*100
    public decimal? PrincipalArrAll { get; set; }          // ต้นค้าง
    public decimal? PendingMonthArr { get; set; }          // ต้นค้างเก่า
    public string? Remark { get; set; }                    // หมายเหตุ
    public string? LoanCode { get; set; }                  // สถานะลูกหนี้ (combo sc_lon_m_ucf_loan_code; !=0 → แดง)
    public string? CColldetail { get; set; }               // หลักประกัน (legacy null)
    public string? CloseStatus { get; set; }               // สถานะสัญญา (decode text)
    public string? LoanObjectiveDesc { get; set; }         // วัตถุประสงค์
    public decimal? PaidAble { get; set; }                 // คงเหลือรับเงินงวด (pka_mem_det.fp_cal_loan_paidable)
    public decimal? PendingAmount { get; set; }            // ต้นรอเรียกเก็บ
    public decimal? PendingInterest { get; set; }          // ด/บ รอเรียกเก็บ
    public DateTime? LastProcessDate { get; set; }         // เรียกเก็บล่าสุด
    public decimal? PrincipalBalance { get; set; }         // คงเหลือ
    public string? WelfareStatus { get; set; }             // ผ่านสวัสดิการ (decode; legacy ไม่ bind layout)
    public string? FixedInterest { get; set; }             // 1=ดอกคงที่ (case fixed_interest_rate>0)
}

// sub 1: เคลื่อนไหวสัญญา (u_tabpg_loan_detail_loan_detail) grid
public class LoanDetailMoveDto
{
    public decimal? SeqNo { get; set; }                    // ที่
    public DateTime? LoanPaymentDate { get; set; }         // วันที่ทำรายการ (FPB_GET_LOAN_PAYMENT_DATE)
    public string? RefLoanDocNo { get; set; }              // เลขอ้างอิง
    public string? ItemTypeCode { get; set; }              // รหัส (XL → เขียว)
    public decimal? Period { get; set; }                   // งวด
    public decimal? RecieveReturn { get; set; }            // เงินต้น-รับ/คืน (decode sign_status=-1)
    public decimal? Paid { get; set; }                     // เงินต้น-ชำระ (decode sign_status=-1)
    public decimal? InterestAmout { get; set; }            // ดอกเบี้ย (sic)
    public decimal? TotalAmount { get; set; }              // จำนวนเงิน
    public decimal? PrincipalBalance { get; set; }         // เงินต้นคงเหลือ
    public decimal? InterestArrearBal { get; set; }        // ดบ.ค้าง
    public DateTime? InterestTo { get; set; }              // วันที่คิดดอกเบี้ย
    public string? MembershipNo { get; set; }              // ผู้จ่าย
    public decimal? SignStatus { get; set; }               // สัญลักษณ์ (>0 → แดง)
}

// sub 2: เงินกู้เอทีเอ็ม (u_tabpg_loan_detail_atmdet) grid
public class LoanDetailAtmDto
{
    public string? LoanContractNo { get; set; }
    public decimal? SeqNo { get; set; }                    // ลำดับ
    public decimal? PrinAmount { get; set; }               // ยอดที่กดได้
    public decimal? FeeAmount { get; set; }                // ค่าธ/น.การกด
    public DateTime? OperateDate { get; set; }             // วันที่รายการ
    public string? ItemType { get; set; }                  // รหัส
    public string? ItemDesc { get; set; }                  // คำอธิบายรหัส
    public string? TransactionNo { get; set; }             // เอกสาร
    public DateTime? EntryDate { get; set; }               // เวลาทำ
    public string? EntryId { get; set; }                   // ผู้ทำ
    public decimal? ApproveAmount { get; set; }            // ยอดอนุมัติ
    public decimal? LoanBalance { get; set; }              // จำนวนเงิน
    public string? Remark { get; set; }                    // หมายเหตุ
}

// sub 3: รายการค้ำประกัน (u_tabpg_loan_detail_coll_detail gvLoanColl) grid
public class LoanDetailCollDto
{
    public string? CollateralTypeCode { get; set; }        // หลักประกัน (combo sc_lon_m_ucf_collateral_type2)
    public string? RefOwnNo { get; set; }                  // เลขอ้างอิง
    public string? CollateralDescription { get; set; }     // รายละเอียด (decode + fp_get_member_name)
    public string? KeepCollStatus { get; set; }            // เก็บ ผู้ค้ำ (check)
    public decimal? KeepCollAmount { get; set; }           // เรียกเก็บ ฐานผู้ค้ำฯ
    public string? Remark { get; set; }                    // หมายเหตุ
    public decimal? UsedAmount { get; set; }               // ค้ำประกัน
}

// sub 4: โอนหนี้ให้ผู้ค้ำ (u_tabpg_loan_detail_coll_trans) grid
public class LoanDetailCollTransDto
{
    public string? LoanContractNo { get; set; }            // เลขที่สัญญา
    public string? MembershipNo { get; set; }              // ทะเบียน
    public string? MemberName { get; set; }                // ชื่อผู้ค้ำ (fp_get_member_name)
    public DateTime? BeginingOfContract { get; set; }      // วันที่เริ่มสัญญา (sic)
    public decimal? LoanApproveAmount { get; set; }        // วงเงินอนุมัติ
    public decimal? PeriodPaymentAmount { get; set; }      // ชำระต่องวด
    public DateTime? LastAccessDate { get; set; }
    public decimal? LastPeriod { get; set; }               // งวดล่าสุด
    public decimal? PrincipalBalance { get; set; }         // ยอดเงินคงเหลือ
    public string? EntryId { get; set; }
    public DateTime? EntryDate { get; set; }
}

// sub 5: การจ่ายเงิน (u_tabpg_loan_detail_payment) form single row
public class LoanDetailPaymentDto
{
    public string? TypePayMoney { get; set; }              // ประเภทการจ่าย (combo sc_com_m_ucf_money_type; decode 0→-)
    public string? BankCode { get; set; }                  // ธนาคาร (combo sc_acc_m_ucf_bank2)
    public string? BranchCode { get; set; }                // สาขา
    public string? BankAccNo { get; set; }                 // เลขที่บัญชี
    public string? AccPaidType { get; set; }               // ประเภทบัญชี (sc_lon_m_loan_request.acc_paid_type)
}

// sub 6a: รายการหักกลบ head (u_tabpg_loan_detail_recclear) form single row
public class LoanDetailRecclearHeadDto
{
    public string? ReceiptNo { get; set; }                 // เลขที่ใบเสร็จ
    public DateTime? ReceiptDate { get; set; }             // วันที่ใบเสร็จ
    public DateTime? CalcintDate { get; set; }             // วันที่คิดดอกเบี้ย
    public string? EntryId { get; set; }                   // ผู้บันทึก
}

// sub 6b: รายการหักกลบ item (u_tabpg_loan_detail_recclear grid) grid
public class LoanDetailRecclearItemDto
{
    public string? ReceiptNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? ItemType { get; set; }                  // รหัส
    public string? Description { get; set; }               // รายละเอียด
    public decimal? Period { get; set; }                   // งวด
    public decimal? PrincipalAmount { get; set; }          // เงินต้น
    public decimal? InterestAmount { get; set; }           // ดอกเบี้ย
    public decimal? ItemAmount { get; set; }               // จำนวนเงินรวม (sum)
    public decimal? Balance { get; set; }                  // คงเหลือ
    public decimal? InterestReturn { get; set; }           // ดอกเบี้ยคืน
}

// sub 7: หลายวัตถุประสงค์ (u_tabpg_loan_detail_multiobject) grid
public class LoanDetailMultiobjectDto
{
    public string? LoanContractNo { get; set; }
    public decimal? SeqNo { get; set; }                    // ลำดับ
    public string? LoanObjectCode { get; set; }            // วัตถุประสงค์ (code || ' - ' || desc)
    public decimal? LoanObjectAmount { get; set; }         // จำนวนเงินตามวัตถุประสงค์
    public string? Remark { get; set; }                    // หมายเหตุ
}

// sub 8: ค่างวดรายเดือน (u_tabpg_loan_detail_step_pay) grid
public class LoanDetailStepPayDto
{
    public string? LoanRequestmentNo { get; set; }
    public decimal? PeriodStepBf { get; set; }             // งวดตั้งแต่ (lag+1, default 1)
    public decimal? PeriodStep { get; set; }               // ถึง
    public decimal? PeriodPayment { get; set; }            // ชำระต่องวด
    public DateTime? EffectiveDate { get; set; }           // วันที่เริ่มชำระ
}

// ── G3: ประวัติการกู้ (u_tabpg_mem_detail_loan_detail_history) grid — view_tel_det_lon_zero
public class LoanDetailHistoryDto
{
    public string? MembershipNo { get; set; }
    public string? LoanContractNo { get; set; }            // เลขที่สัญญา
    public DateTime? BeginingOfContract { get; set; }      // วันที่เริ่มสัญญา
    public decimal? LoanApproveAmount { get; set; }        // เงินอนุมัติ
    public decimal? LoanInstallmentAmount { get; set; }    // งวดที่
    public decimal? PeriodPaymentAmount { get; set; }      // ชำระต่องวด
    public DateTime? LastCalcintDate { get; set; }         // คิดดอกเบี้ยล่าสุด
    public decimal? LastPeriod { get; set; }               // งวดล่าสุด
    public decimal? PrincipalBalance { get; set; }         // เงินต้นคงเหลือ
    public decimal? YearTotalInterest { get; set; }        // ดอกเบี้ยสะสม
    public decimal? InterestArrear { get; set; }           // ดอกเบี้ยค้าง
    public string? DropPaymentStatus { get; set; }         // สถานะ (combo loan_drop_status)
    public string? LoanStatus { get; set; }
    public string? LoanGroup { get; set; }                 // '2' → font แดง
    public string? ModifyStatus { get; set; }
}

// ── G3: หลักประกัน (u_tabpg_mem_detail_memcoll_detail) grid
public class MemcollDetailDto
{
    public decimal? ConOrder { get; set; }                 // ลำดับ (# ในสัญญา)
    public string? LoanContractNo { get; set; }            // เลขที่สัญญา (merge)
    public decimal? PrincipalBalance { get; set; }         // ยอดเงินคงเหลือ (merge)
    public string? RefOwnNo { get; set; }                  // เลขที่อ้างอิง
    public string? CollateralDesc { get; set; }            // รายละเอียดหลักทรัพย์
    public decimal? SalaryAmount { get; set; }             // เงินเดือน
    public decimal? UsedAmount { get; set; }               // วงเงินค้ำประกัน
    public string? LoanType { get; set; }
    public string? MemberStatusCode { get; set; }          // '3' → row สีส้ม
    public string? CloseStatus { get; set; }
}

// ── G6: วิธีชำระเงิน สมาคมฌาปนกิจ (u_tabpg_mem_cremation_paid_det) grid
public class CremationPaidDetDto
{
    public string? MembershipNo { get; set; }
    public string? CremType { get; set; }                  // ประเภทสมาคม (combo sc_mem_m_ucf_member_cremation)
    public decimal? SeqNo { get; set; }
    public string? CremNumber { get; set; }                // เลขที่สมาชิกสมาคม
    public string? CremRemark { get; set; }                // หมายเหตุ
    public string? CremMemno { get; set; }                 // เลขสมาชิกอ้างอิง
    public string? CremPaid { get; set; }                  // วิธีชำระ (combo sc_mem_m_ucf_crem_paid2)
    public string? BankAccNo { get; set; }                 // เลขที่บัญชี
    public string? BankName { get; set; }                  // ธนาคาร
    public string? DepositStatus { get; set; }             // '1' → หักบัญชี (checkbox)
    public string? DepositAccountNo { get; set; }          // เลขบัญชีหัก
}

// ── G6: สมาชิกสมทบ (u_tabpg_mem_userefer) grid — สมาชิกที่ผู้นี้เป็นผู้อ้างอิงให้
public class UsereferDto
{
    public string? MembershipNo { get; set; }
    public decimal? SeqNo { get; set; }
    public string? MembershipNoRef { get; set; }           // เลขสมาชิกสมทบ
    public string? MemberName { get; set; }                // ชื่อ
    public string? MemberStatusCode { get; set; }
    public string? ConceernCode { get; set; }              // ความสัมพันธ์ (combo sc_mem_m_ucf_concern)
    public string? EntryId { get; set; }
    public string? CancelId { get; set; }
    public string? ReferStatus { get; set; }
}

// ── G7: ประวัติเปลี่ยนวิธีจ่ายปันผล (u_tabpg_mem_detail_chg_recieve_dividend) grid
public class ChgRecieveDividendDto
{
    public DateTime? OperateDate { get; set; }             // วันที่เปลี่ยน
    public string? PreMethodRecieveDividend { get; set; }  // วิธีเดิม (code)
    public string? PreMethodRecieveDividendName { get; set; } // วิธีเดิม (ชื่อ)
    public string? MethodRecieveDividend { get; set; }     // วิธีใหม่ (code)
    public string? MethodRecieveDividendName { get; set; } // วิธีใหม่ (ชื่อ)
    public string? EntryId { get; set; }                   // ผู้ทำรายการ
}

// ── G8: สัญญาเงินกู้ (u_tabpg_edc_loancontract) grid — เอกสาร e-document สัญญากู้
public class EdocLoanContractDto
{
    public string? LoanContractNo { get; set; }            // เลขที่สัญญา
    public string? DocType { get; set; }
    public string? DocTypeName { get; set; }               // ประเภทเอกสาร
    public string? Remark { get; set; }                    // หมายเหตุ
    public DateTime? EntryDate { get; set; }               // วันที่บันทึก
    public string? EntryId { get; set; }                   // ผู้บันทึก
    public decimal? PageNo { get; set; }                   // หน้า
    public string? Filename { get; set; }                  // 'DELETED' → font แดง
}

// ── G6: สมาคมฌาปนกิจ (u_tabpg_mem_cremation_det) grid
// ⚠️ DEFERRED: view_tel_get_creamation ยังไม่มีใน PG (federation 3 Oracle DB — ยังไม่ตัดสินใจ) → service คืน list ว่าง
public class CremationDetDto
{
    public string? CoopType { get; set; }
    public string? CremCoop { get; set; }
    public string? CremCode { get; set; }
    public string? CremName { get; set; }                  // ชื่อสมาคม
    public string? CremTypeCode { get; set; }
    public string? CremType { get; set; }                  // ประเภท
    public string? MembershipNo { get; set; }
    public decimal? CreamAmount { get; set; }              // จำนวนเงิน
}

// ── G4: เรียกเก็บรายเดือน (u_tabpg_mem_detail_month_detail) — header form (dsReceiptNo)
public class MonthDetailHeadDto
{
    public DateTime? ReceiptDate { get; set; }             // วันที่รับเงิน
    public decimal? KeepingAmount { get; set; }            // เงินเก็บรับ (NET) = pkb_labour.fp_get_keeping_amount(...,'NET')
    public decimal? KepMethodAmount { get; set; }          // รวมได้รับชำระ
    public decimal? TotalKeepNotinput { get; set; }        // เงินรอจ่ายคืน
    public string? ReceiptStatus { get; set; }             // สถานะใบเสร็จ
    public string? ReceiptNo { get; set; }                 // เลขที่ใบเสร็จ
    public decimal? AmountFormFile { get; set; }           // ตัวแทนนำส่ง
    public decimal? AmountForm { get; set; }               // ชำระเอง
    public decimal? AmountFormDep { get; set; }            // หักจากเงินฝาก
    public string? MemberGroupNo { get; set; }             // หน่วย
    public DateTime? ReceiptEffectdate { get; set; }       // วันที่คืนใบเสร็จ
    public decimal? KepLimit { get; set; }                 // ส่งหัก
    public decimal? KepCompute { get; set; }               // ชำระเพิ่ม
    public string? AgentNo { get; set; }                   // กลุ่มส่งหัก
    public string? SalaryGroup { get; set; }               // กลุ่มส่งไฟล์
    public DateTime? PpmDate { get; set; }                 // ตามมาชำระ
}

// ── G4: เรียกเก็บรายเดือน (u_tabpg_mem_detail_month_detail) — grid (dsDetMonthDetail)
public class MonthDetailRowDto
{
    public string? KeepingTypeCode { get; set; }           // รหัส
    public string? KeepingTypeDesc { get; set; }           // คำอธิบาย
    public string? ReceiveDescription { get; set; }        // รายการ
    public decimal? Period { get; set; }                   // งวดที่
    public decimal? PrincipalOfLoan { get; set; }          // เงินต้นเรียกเก็บ (blue)
    public decimal? Interest { get; set; }                 // ดอกเบี้ยเรียกเก็บ (blue)
    public decimal? CMoneyAmount { get; set; }             // รวมเรียกเก็บ (blue)
    public decimal? PrincipalNot { get; set; }             // เงินต้นเก็บได้ (green)
    public decimal? InterestNot { get; set; }              // ดอกเบี้ยเก็บได้ (green)
    public decimal? CMoneyAmountNot { get; set; }          // รวมเก็บได้ (green)
    public decimal? UnkeepPrincipalOfLoan { get; set; }    // เงินต้นเก็บไม่ได้ (red)
    public decimal? UnkeepInterest { get; set; }           // ดอกเบี้ยเก็บไม่ได้ (red)
    public decimal? UnkeepMoneyAmount { get; set; }        // รวมเก็บไม่ได้ (red)
    public decimal? ReturnPrincipal { get; set; }          // ต้นเงินคืน (purple)
    public decimal? ReturnInterest { get; set; }           // ดอกเงินคืน (purple)
    public decimal? MoneyReturn { get; set; }              // รวมเงินคืน (purple)
    public decimal? UkpaidAfterP { get; set; }             // เงินต้นตามมาชำระ (green bold)
    public decimal? UkpaidAfterI { get; set; }             // ดอกเบี้ยตามมาชำระ (green bold)
    public decimal? UkpaidAfterA { get; set; }             // รวมตามมาชำระ (green bold)
    public decimal? CAmount { get; set; }                  // คงเหลือหลังผ่านรายการ
    public decimal? MpostPrincipalOfLoan { get; set; }     // เงินต้นเก็บจริง
    public decimal? MpostInterest { get; set; }            // ดอกเบี้ยเก็บจริง
    public decimal? MpostMoneyAmount { get; set; }         // รวมเก็บจริง
    public decimal? MprocPrincipalArr { get; set; }        // ต้นค้าง (green bold)
    public decimal? IntarrPay { get; set; }                // ดอกค้าง (green bold)
}
