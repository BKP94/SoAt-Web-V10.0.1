using SoAt.Application.ScTeller;

namespace SoAt.Infrastructure.ScTeller;

public class SctelnewbmaService(sc.dbFactory dbFactory, sc.save save) : ISctelnewbmaService
{
    // ── Lookups ───────────────────────────────────────────────────────────────

    public async Task<SctelnewbmaLookupsDto> GetLookupsAsync()
    {
        await using var scDb = dbFactory.create();

        var prenameItems        = await scDb.getComboAsync(sc.combo.sc_mem_m_ucf_prename);
        var sexItems            = await scDb.getComboAsync(sc.combo.sex);
        var marriageStatusItems = await scDb.getComboAsync(sc.combo.sc_mem_m_ucf_marriage_status);
        // tabs (PanTabs): บัญชีธนาคาร / คู่สมรส / รับโอน
        var bankItems           = await scDb.getComboAsync(sc.combo.sc_acc_m_ucf_bank);
        var occupationItems     = await scDb.getComboAsync(sc.combo.sc_mem_m_ucf_ocupation);
        var otherSavingItems    = await scDb.getComboAsync(sc.combo.sc_mem_m_ucf_othersaving);

        var memberTypes = await scDb.getListAsync<MemberTypeDto>(
            "SELECT mem_type_code AS code, mem_type_desc AS desc, maximun_share, not_salary, mproc_apart FROM sc_mem_m_ucf_member_type ORDER BY mem_type_code");

        var memberGroups = await scDb.getListAsync<MemberGroupDto>(
            "SELECT member_group_no AS no, member_group_name AS name, mem_type_default, not_sal, ingore_dropshr_rule FROM sc_mem_m_ucf_member_group ORDER BY member_group_no");

        var electionGroups = await scDb.getListAsync<ElectionGroupDto>(
            "SELECT election_group AS code, election_group_name AS name, election_zone AS zone FROM sc_mem_m_ucf_election_group ORDER BY election_group");

        var nationalities = await scDb.getListAsync<NationalityDto>(
            "SELECT nationality_code AS code, nationality_description AS description FROM sc_mem_m_ucf_nationality ORDER BY nationality_code");

        var bloods = await scDb.getListAsync<BloodDto>(
            "SELECT blood_code AS code, blood_desc AS desc FROM sc_mem_m_ucf_blood ORDER BY blood_code");

        var provinces = await scDb.getListAsync<ProvinceDto>(
            "SELECT province_code AS code, province_name AS name FROM sc_mem_m_ucf_province ORDER BY province_code");

        var districts = await scDb.getListAsync<DistrictDto>(
            "SELECT district_code AS code, district_name AS name, province_code, post_code FROM sc_mem_m_ucf_district ORDER BY district_code");

        var subdistricts = await scDb.getListAsync<SubdistrictDto>(
            "SELECT subdistrict_code AS code, subdistrict_name AS name, district_code FROM sc_mem_m_ucf_subdistrict ORDER BY subdistrict_code");

        var applicationTypes = await scDb.getListAsync<ApplicationTypeDto>(
            "SELECT appl_type_code AS code, appl_type_name AS name, application_fee AS fee, NULL::varchar AS mem_type_code FROM sc_mem_m_ucf_application_type WHERE appl_type_code <> '0' ORDER BY appl_type_code");

        var concerns = await scDb.getListAsync<ConcernDto>(
            "SELECT conceern_code AS code, related_na FROM sc_mem_m_ucf_concern ORDER BY sort_order");

        var groupPositions = await scDb.getListAsync<GroupPositionDto>(
            "SELECT group_position AS code, description, sort_order FROM sc_mem_m_ucf_group_position ORDER BY sort_order");

        var positions = await scDb.getListAsync<PositionDto>(
            "SELECT position_code AS code, position_name AS name, sort_order FROM sc_mem_m_ucf_position ORDER BY sort_order");

        // ระดับ/ขั้น เงินเดือน (work_info) — โหลดทั้งหมดพร้อม level_code เพื่อ cascade ฝั่ง client (เหมือน Districts ← Province)
        var salaryLevels = await scDb.getListAsync<SalaryLevelDto>(
            "SELECT level_code::int AS code, level_name AS name FROM sc_mem_m_ucf_salary_level ORDER BY level_code");

        var salaryRates = await scDb.getListAsync<SalaryRateDto>(
            @"SELECT salary_rate_code AS code,
                     (CASE WHEN salary_rate_code > 0
                           THEN 'ขั้น '||rpad(salary_rate_code::text,6,' ')||'['||lpad(to_char(salary_amount,'9,999,999.99'),14,' ')||']'
                      END) AS name,
                     level_code::int AS levelcode
              FROM sc_mem_m_ucf_salary_rate ORDER BY level_code, salary_rate_code");

        // สาขาธนาคาร — โหลดทั้งหมดพร้อม bank_id เพื่อ cascade ฝั่ง client (เหมือน Districts ← Province)
        var bankBranches = await scDb.getListAsync<BankBranchDto>(
            "SELECT bank_branch_id AS code, bank_name AS name, bank_id FROM sc_acc_m_ucf_bank_branch ORDER BY bank_id, bank_branch_id");

        var coop = await scDb.getOneAsync<CoopConfigDto>(
            "SELECT coop_registered_no AS coop_no, count_resign, auto_approve_newmem, mem_type_ongroup FROM sc_cnt_m_coop LIMIT 1");

        return new SctelnewbmaLookupsDto
        {
            Prenames         = prenameItems.Select(x => new ComboItemDto(x.Code, x.Name)).ToList(),
            Sexes            = sexItems.Select(x => new ComboItemDto(x.Code, x.Name)).ToList(),
            MemberTypes      = memberTypes,
            MemberGroups     = memberGroups,
            ElectionGroups   = electionGroups,
            Nationalities    = nationalities,
            MarriageStatuses = marriageStatusItems.Select(x => new ComboItemDto(x.Code, x.Name)).ToList(),
            Bloods           = bloods,
            Provinces        = provinces,
            Districts        = districts,
            Subdistricts     = subdistricts,
            ApplicationTypes = applicationTypes,
            Concerns         = concerns,
            GroupPositions   = groupPositions,
            Positions        = positions,
            SalaryLevels     = salaryLevels,
            SalaryRates      = salaryRates,
            CoopConfig       = coop,
            Banks            = bankItems.Select(x => new ComboItemDto(x.Code, x.Name)).ToList(),
            BankBranches     = bankBranches,
            Occupations      = occupationItems.Select(x => new ComboItemDto(x.Code, x.Name)).ToList(),
            OtherSavings     = otherSavingItems.Select(x => new ComboItemDto(x.Code, x.Name)).ToList(),
        };
    }

    // ── Get Application ───────────────────────────────────────────────────────

    public async Task<ApplicationFormDto?> GetApplicationAsync(string applicationFormNo)
    {
        await using var scDb = dbFactory.create();

        var form = await scDb.getOneAsync<ApplicationFormDto>(
            "SELECT * FROM sc_mem_m_application_form WHERE application_form_no = {0}",
            applicationFormNo);

        if (form is null) return null;

        var addresses = await scDb.getListAsync<AppAddressDto>(
            "SELECT * FROM sc_mem_m_app_address WHERE application_form_no = {0}",
            applicationFormNo);

        form.AddressCurrent = addresses.FirstOrDefault(a => a.AddressType == "0");
        form.AddressHome    = addresses.FirstOrDefault(a => a.AddressType == "1");
        form.AddressWork    = addresses.FirstOrDefault(a => a.AddressType == "2");

        form.WorkInfo = await scDb.getOneAsync<AppWorkInfoDto>(
            "SELECT * FROM sc_mem_m_app_work_info WHERE application_form_no = {0}",
            applicationFormNo);

        var shareRow = await scDb.getOneAsync<ShareRow>(
            "SELECT share_monthly FROM sc_mem_m_app_share WHERE application_form_no = {0}",
            applicationFormNo);
        form.ShareMonthly = shareRow?.ShareMonthly;

        form.MemberRefers = await scDb.getListAsync<AppMemberReferDto>(
            "SELECT * FROM sc_mem_m_app_member_refer WHERE application_form_no = {0} ORDER BY seq_no",
            applicationFormNo);

        form.RecrieveGains = await scDb.getListAsync<AppRecrieveGainDto>(
            "SELECT * FROM sc_mem_m_app_recrieve_gain WHERE application_form_no = {0} ORDER BY seq_no",
            applicationFormNo);

        // ── tabs (PanTabs): บัญชีธนาคาร / คู่สมรส / รับโอน ──────────────────────────
        // flag เก็บเป็น char(1) '0'/'1' → map กลับเป็น bool ด้วย sc.value.toBoolean
        // seq_no เป็น double precision → cast ::int ให้ตรงกับ DTO
        var bankRows = await scDb.getListAsync<BankAccnoRow>(
            "SELECT seq_no::int AS seq_no, bank_id, bank_branch_id, bank_acc_no, " +
            "paid_loan, atm_lon, atm_dep, paid_dividen, share_withdraw, keep_monthly, paid_agent, paid_salary " +
            "FROM sc_mem_m_app_bank_accno WHERE application_form_no = {0} ORDER BY seq_no",
            applicationFormNo);
        form.BankAccounts = bankRows.Select(r => new AppBankAccountDto {
            SeqNo         = r.SeqNo,
            BankId        = r.BankId,
            BankBranchId  = r.BankBranchId,
            BankAccNo     = r.BankAccNo,
            PaidLoan      = sc.value.toBoolean(r.PaidLoan),
            AtmLon        = sc.value.toBoolean(r.AtmLon),
            AtmDep        = sc.value.toBoolean(r.AtmDep),
            PaidDividen   = sc.value.toBoolean(r.PaidDividen),
            ShareWithdraw = sc.value.toBoolean(r.ShareWithdraw),
            KeepMonthly   = sc.value.toBoolean(r.KeepMonthly),
            PaidAgent     = sc.value.toBoolean(r.PaidAgent),
            PaidSalary    = sc.value.toBoolean(r.PaidSalary),
        }).ToList();

        // workname (ไม่มี underscore) อ่านได้เพราะ Dapper MatchNamesWithUnderscores → WorkName
        form.SpouseInfo = await scDb.getOneAsync<AppSpouseInfoDto>(
            "SELECT * FROM sc_mem_m_app_spouse_info WHERE application_form_no = {0}",
            applicationFormNo);

        form.OwnInfo = await scDb.getOneAsync<AppOwnInfoDto>(
            "SELECT * FROM sc_mem_m_app_own_info WHERE application_form_no = {0}",
            applicationFormNo);

        var picRow = await scDb.getOneAsync<PictureRow>(
            "SELECT app_picture FROM sc_mem_m_app_picture WHERE application_form_no = {0}",
            applicationFormNo);
        form.PictureBase64 = picRow?.AppPicture is null ? null : Convert.ToBase64String(picRow.AppPicture);

        var sigRow = await scDb.getOneAsync<SignatureRow>(
            "SELECT app_signature FROM sc_mem_m_app_signature WHERE application_form_no = {0}",
            applicationFormNo);
        form.SignatureBase64 = sigRow?.AppSignature is null ? null : Convert.ToBase64String(sigRow.AppSignature);

        return form;
    }

    // ── Create Application ────────────────────────────────────────────────────

    public async Task<ApplicationFormSaveResult> CreateApplicationAsync(
        ApplicationFormDto dto, string userId, string branchId)
    {
        var scDb = dbFactory.create(userId, branchId);
        try
        {
            ValidateMemberType(dto);      // pre-save: สมทบต้องมีสมาชิกอ้างอิง (port legacy ofValidateMemberType)
            NormalizeMaskedFields(dto);   // เลขบัตร → ตัวเลขล้วน (ตัด literal mask กัน varchar ล้น)

            // sc.save: header + ทุก sub-table (annotate ที่ DTO) ในทรานแซกชันเดียว
            var ctx = new sc.SaveContext(userId, branchId)
            {
                Generators = { ["GenApplicationFormNo"] = GenApplicationFormNoAsync },
            };
            var result = await save.ofSaveAsync(dto, scDb, ctx);
            await SavePictureSignatureAsync(scDb, result.Key, dto, isUpdate: false);  // hook: รูป/ลายเซ็น

            await scDb.ofConnectionCloseAsync("CreateApplication");
            return new ApplicationFormSaveResult(result.Key, "บันทึกใบสมัครสำเร็จ");
        }
        catch
        {
            await scDb.ofConnectionCloseAsync("CreateApplication-Error", onError: true);
            throw;
        }
    }

    // ── Update Application ────────────────────────────────────────────────────

    public async Task<ApplicationFormSaveResult> UpdateApplicationAsync(
        string applicationFormNo, ApplicationFormDto dto, string userId)
    {
        var scDb = dbFactory.create(userId);
        try
        {
            var approveStatus = sc.value.toString(await scDb.getValueAsync(
                "SELECT approve_status FROM sc_mem_m_application_form WHERE application_form_no = {0}",
                applicationFormNo));

            if (approveStatus == "")
                throw new KeyNotFoundException(sc.msg.C($"ไม่พบใบสมัครเลขที่ {applicationFormNo}"));
            if (approveStatus == "1")
                throw new InvalidOperationException(sc.msg.C("ไม่สามารถแก้ไขใบสมัครที่อนุมัติแล้ว"));

            ValidateMemberType(dto);      // pre-save: สมทบต้องมีสมาชิกอ้างอิง (port legacy ofValidateMemberType)
            NormalizeMaskedFields(dto);   // เลขบัตร → ตัวเลขล้วน (ตัด literal mask กัน varchar ล้น)

            // key มีค่า → sc.save ทำ UPDATE header + ล้าง+เขียน child ใหม่ทั้งหมด (Replace)
            dto.ApplicationFormNo = applicationFormNo;
            await save.ofSaveAsync(dto, scDb, new sc.SaveContext(userId));
            await SavePictureSignatureAsync(scDb, applicationFormNo, dto, isUpdate: true);  // hook: รูป/ลายเซ็น

            await scDb.ofConnectionCloseAsync("UpdateApplication");
            return new ApplicationFormSaveResult(applicationFormNo, "อัปเดตใบสมัครสำเร็จ");
        }
        catch
        {
            await scDb.ofConnectionCloseAsync("UpdateApplication-Error", onError: true);
            throw;
        }
    }

    // ── Cancel Application (void) ─────────────────────────────────────────────
    // logic (validate สถานะอนุมัติ + set cancel_status='1') อยู่ใน PG เหมือน legacy:
    //   pka_mem_newmem.sp_docno_cancel — ดู sql/migrations/2026-06-10_pka_cancel_mem_appli.sql
    // C# แค่ส่งเข้าไปทำงานใน PL (validation error เด้งกลับเป็น prefix E ของ PG)

    public async Task<ApplicationFormSaveResult> CancelApplicationAsync(
        string applicationFormNo, string cancelReason, string userId, string branchId)
    {
        var scDb = dbFactory.create(userId, branchId);   // SET LOCAL app.login_id/login_br → PG อ่าน cancel_id/branch
        try
        {
            await scDb.pkProcedureAsync("pka_mem_newmem.sp_docno_cancel", applicationFormNo, cancelReason);
            await scDb.ofConnectionCloseAsync("CancelApplication");
            return new ApplicationFormSaveResult(applicationFormNo, "ยกเลิกใบสมัครสมาชิกเรียบร้อยแล้ว");
        }
        catch
        {
            await scDb.ofConnectionCloseAsync("CancelApplication-Error", onError: true);
            throw;
        }
    }

    // ── Search (popOpen) ──────────────────────────────────────────────────────

    public async Task<List<ApplicationSummaryDto>> SearchApplicationsAsync(ApplicationSearchFilter filter)
    {
        await using var scDb = dbFactory.create();

        // คำนำหน้า + ชื่อ + สกุล / เลขหน่วย - ชื่อหน่วย / สถานะ (cancel='1' → '3')
        var sql = new System.Text.StringBuilder(@"
SELECT a.application_form_no AS application_form_no,
       a.apply_date          AS apply_date,
       TRIM(COALESCE(p.prename, '') || ' ' || COALESCE(a.member_name, '') || ' ' || COALESCE(a.member_surname, '')) AS member_name,
       TRIM(COALESCE(a.member_group_no, ''))
         || CASE WHEN g.member_group_name IS NOT NULL THEN ' - ' || TRIM(g.member_group_name) ELSE '' END AS member_group,
       CASE WHEN a.cancel_status = '1' THEN '3' ELSE a.approve_status END AS approve_status
FROM sc_mem_m_application_form a
LEFT JOIN sc_mem_m_ucf_prename      p ON p.prename_code    = a.prename_code
LEFT JOIN sc_mem_m_ucf_member_group g ON g.member_group_no = a.member_group_no
WHERE 1 = 1");

        var args = new List<object?>();
        int i = 0;

        if (!string.IsNullOrWhiteSpace(filter.ApplicationFormNo))
        {
            sql.Append(" AND a.application_form_no LIKE {" + i + "}");
            args.Add("%" + filter.ApplicationFormNo.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.MemberName))
        {
            sql.Append(" AND a.member_name LIKE {" + i + "}");
            args.Add("%" + filter.MemberName.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.MemberSurname))
        {
            sql.Append(" AND a.member_surname LIKE {" + i + "}");
            args.Add("%" + filter.MemberSurname.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.MemberGroup))
        {
            // ใช้ join g ที่มีอยู่แล้ว (ไม่ต้อง EXISTS ตารางเดิมซ้ำ) — match เลขหน่วยของใบสมัครเอง หรือชื่อหน่วยจาก lookup
            sql.Append(" AND (a.member_group_no LIKE {" + i + "} OR g.member_group_name LIKE {" + i + "})");
            args.Add("%" + filter.MemberGroup.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.ApproveStatus))
        {
            if (filter.ApproveStatus == "3")
            {
                sql.Append(" AND a.cancel_status = '1'");
            }
            else
            {
                sql.Append(" AND a.cancel_status = '0' AND a.approve_status = {" + i + "}");
                args.Add(filter.ApproveStatus); i++;
            }
        }

        sql.Append(" ORDER BY a.application_form_no DESC");

        return await scDb.getListAsync<ApplicationSummaryDto>(sql.ToString(), args.ToArray());
    }

    public async Task<List<ComboItemDto>> GetApplicationStatusesAsync()
    {
        await using var scDb = dbFactory.create();
        var items = await scDb.getComboAsync(sc.combo.application_form_status);
        return items.Select(x => new ComboItemDto(x.Code, x.Name)).ToList();
    }

    public async Task<List<ComboItemDto>> GetCancelReasonsAsync()
    {
        await using var scDb = dbFactory.create();
        var items = await scDb.getComboAsync(sc.combo.sc_mem_m_ucf_cancel_newform);
        return items.Select(x => new ComboItemDto(x.Code, x.Name)).ToList();
    }

    // ── value-change lookups (Group B) ─────────────────────────────────────────

    // คำนำหน้า → เพศ + สถานภาพสมรส (legacy change_prename_code: query sc_mem_m_ucf_prename)
    public async Task<PrenameDefaultDto> GetPrenameDefaultAsync(string prenameCode)
    {
        if (string.IsNullOrWhiteSpace(prenameCode)) return new PrenameDefaultDto(null, null);
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<PrenameDefaultDto>(
            "SELECT sex, marriage_status AS marriagestatus FROM sc_mem_m_ucf_prename WHERE prename_code = {0}",
            prenameCode) ?? new PrenameDefaultDto(null, null);
    }

    // กลุ่มสมาชิก → กลุ่มช่วยเลือกตั้ง (legacy change_member_group_no: pka_election.fp_help_election)
    public async Task<string?> GetElectionHelpGroupAsync(string memberGroupNo)
    {
        if (string.IsNullOrWhiteSpace(memberGroupNo)) return null;
        await using var scDb = dbFactory.create();
        return sc.value.toString(await scDb.pkFunctionAsync("pka_election.fp_help_election", memberGroupNo));
    }

    // วันเกิด → ข้อความอายุ (legacy change_date_of_birth: fp_calc_agetext ∘ fp_calc_install_m_live)
    public async Task<string?> CalcAgeTextAsync(DateTime dateOfBirth)
    {
        await using var scDb = dbFactory.create();
        return sc.value.toString(await scDb.getValueAsync(
            "SELECT pka_lon_reqsrv.fp_calc_agetext(pka_lon_reqsrv.fp_calc_install_m_live({0}))", dateOfBirth));
    }

    // ── value-change validation (Group C) ──────────────────────────────────────

    // ตรวจเลขบัตร ปชช. (port legacy ofValidateHumid) — humId = 13 หลัก (ตัด mask แล้ว)
    public async Task<HumIdValidationDto> ValidateHumIdAsync(string humId, DateTime applyDate)
    {
        await using var scDb = dbFactory.create();

        // ตรง ปปง. (AML) → ไม่ให้ใช้เลขนี้ (cpCheckPopAML)
        var amlCount = sc.value.toInteger(await scDb.getValueAsync(
            "SELECT count(*) FROM sc_mem_m_member_aml WHERE aml_id = {0}", humId));
        if (amlCount > 0) return new HumIdValidationDto(null, false, true);

        var resignConfig = sc.value.toInteger(await scDb.getValueAsync(
            "SELECT count_resign FROM sc_cnt_m_coop"));

        // คำขอที่รออนุมัติด้วยเลขบัตรนี้
        var memReq = await scDb.getListAsync<MemReqRow>(
            @"SELECT application_form_no AS applicationformno,
                     (member_name||'  '||member_surname) AS membername
              FROM sc_mem_m_application_form
              WHERE approve_status = '2' AND cancel_status = '0' AND hum_id = {0}", humId);

        // ประวัติการเป็นสมาชิก (เคยเป็น/ลาออก)
        var memReg = await scDb.getListAsync<MemRegRow>(
            @"SELECT membership_no AS membershipno,
                     pka_com_function.fp_get_member_name(membership_no) AS membername,
                     member_status_code AS memberstatuscode,
                     to_tdate(resignation_approve_date) AS resigndatetext,
                     resignation_approve_date AS resigndateraw,
                     to_tdate(approve_date) AS approvedatetext,
                     resign_code AS resigncode
              FROM sc_mem_m_membership_registered
              WHERE id_card = {0}
              ORDER BY approve_date", humId);

        // ใช้เลขบัตรนี้ค้ำประกันอยู่หรือไม่
        var lonCount = sc.value.toInteger(await scDb.getValueAsync(
            @"SELECT count(*) FROM (
                  SELECT c.loan_requestment_no AS loan_contract_no
                  FROM sc_lon_m_req_coll c, sc_lon_m_loan_request r
                  WHERE c.loan_requestment_no = r.loan_requestment_no
                    AND r.cancel_status <> '1' AND c.collateral_type_code = '12' AND c.ref_own_no = {0}
                  UNION ALL
                  SELECT cc.loan_contract_no
                  FROM sc_lon_m_contract_coll cc, sc_lon_m_loan_card lc
                  WHERE cc.loan_contract_no = lc.loan_contract_no
                    AND cc.collateral_type_code = '12' AND cc.status = '0'
                    AND lc.principal_balance > 0 AND cc.ref_own_no = {0}
                  GROUP BY cc.loan_contract_no
              ) tab", humId));

        string msg = "";
        int liCount = 0;
        bool checkStatus;

        if (memReg.Count > 0)   // เคยเป็นสมาชิก
        {
            int countResign = 0, beyondResign = 0;
            bool checkResignDate = true;
            msg += $"ผู้สมัคร เลขที่บัตรประจำตัวประชาชน {humId} เป็นสมาชิกสหกรณ์";
            foreach (var r in memReg)
            {
                liCount++;
                msg += "</br>" + liCount + ".) เลขทะเบียน " + r.MembershipNo + " ชื่อ " + r.MemberName;
                if (r.MemberStatusCode == "0")
                    msg += " สถานะ <a style='color:blue'>เป็นสมาชิก</a> [อนุมัติ : " + r.ApproveDateText + "]";
                else
                {
                    msg += " สถานะ <a style='color:red'>ลาออก</a> [" + r.ResignDateText + "]";
                    countResign++;
                    beyondResign = sc.value.toInteger(await scDb.getValueAsync(
                        "SELECT beyond_resign FROM sc_mem_m_ucf_resign_cause WHERE resign_cause_code = {0}", r.ResignCode));
                    checkResignDate = beyondResign > 0 && r.ResignDateRaw is DateTime rd
                        ? applyDate > rd.AddMonths(beyondResign)
                        : true;
                }
            }

            if (countResign >= resignConfig && resignConfig > 0)
            {
                checkStatus = false;
                msg += "</br></br>มีการลาออกแล้วทั้งหมด " + countResign + " ครั้ง มากกว่าที่กำหนดไว้คือ ห้ามเกิน " + resignConfig + " ครั้ง";
            }
            else if (memReg.Count > countResign)   // ยังเป็นสมาชิกอยู่
            {
                checkStatus = false;
                msg += "</br></br>เป็นสมาชิกสหกรณ์อยู่เเล้วไม่สามารถสมัครสมาชิกใหม่ได้";
            }
            else if (!checkResignDate)
            {
                checkStatus = false;
                msg += "</br></br>ลาออกยังไม่ครบตามเวลาที่กำหนด '" + beyondResign + " เดือน ' ไม่สามารถสมัครสมาชิกใหม่ได้";
            }
            else checkStatus = true;   // user ตัดสินใจเอง (แค่เตือน)
        }
        else if (memReq.Count > 0)   // อยู่ระหว่างขอสมัครใหม่
        {
            msg += $"ผู้สมัคร เลขที่บัตรประจำตัวประชาชน {humId} อยู่ระหว่างขอสมัครใหม่";
            foreach (var r in memReq)
            {
                liCount++;
                msg += "</br>" + liCount + ".) เลขที่คำขอ " + r.ApplicationFormNo + " ชื่อ " + r.MemberName + " สถานะ <a style='color:blue'>รออนุมัติ</a> ";
            }
            msg += "</br></br>ไม่สามารถสมัครอีกได้";
            checkStatus = false;
        }
        else if (lonCount > 0)
        {
            msg = "มีการใช้เลขบัตรประชาชนนี้ในการค้ำประกัน ,กรุณาตรวจสอบ";
            checkStatus = true;
        }
        else checkStatus = true;

        return new HumIdValidationDto(msg, checkStatus, false);
    }

    // ตรวจชื่อ-สกุล ซ้ำ/ตรง ปปง. (port legacy of_validate_name)
    public async Task<NameValidationDto> ValidateNameAsync(string memName, string memSurname)
    {
        await using var scDb = dbFactory.create();

        var amlCount = sc.value.toInteger(await scDb.getValueAsync(
            "SELECT count(*) FROM sc_mem_m_member_aml WHERE aml_name = {0} AND aml_surname = {1}", memName, memSurname));

        var memReg = await scDb.getListAsync<MemRegRow>(
            @"SELECT membership_no AS membershipno,
                     pka_com_function.fp_get_member_name(membership_no) AS membername,
                     member_status_code AS memberstatuscode,
                     to_tdate(resignation_approve_date) AS resigndatetext,
                     resignation_approve_date AS resigndateraw,
                     to_tdate(approve_date) AS approvedatetext,
                     resign_code AS resigncode
              FROM sc_mem_m_membership_registered
              WHERE member_name = {0} AND member_surname = {1}
              ORDER BY membership_no", memName, memSurname);

        var app = await scDb.getListAsync<MemReqRow>(
            @"SELECT application_form_no AS applicationformno,
                     (member_name||'  '||member_surname) AS membername
              FROM sc_mem_m_application_form
              WHERE approve_status = '2' AND cancel_status = '0' AND member_name = {0} AND member_surname = {1}", memName, memSurname);

        string msg = "";
        int liCount = 0;
        if (app.Count > 0 || memReg.Count > 0)
        {
            msg += $"ผู้สมัคร ชื่อ - สกุล  '{memName} {memSurname}' มีอยู่ในระบบ";
            foreach (var r in memReg)
            {
                liCount++;
                msg += "</br>" + liCount + ".) เลขทะเบียน " + r.MembershipNo + " ชื่อ " + r.MemberName;
                if (r.MemberStatusCode == "0")
                    msg += " สถานะ <a style='color:blue'>เป็นสมาชิก</a> [อนุมัติ : " + r.ApproveDateText + "]";
                else
                    msg += " สถานะ <a style='color:red'>ลาออก</a> [" + r.ResignDateText + "]";
            }
            foreach (var r in app)
            {
                liCount++;
                msg += "</br>" + liCount + ".) เลขที่คำขอ " + r.ApplicationFormNo + " ชื่อ " + r.MemberName + " สถานะ <a style='color:blue'>รออนุมัติ</a> ";
            }
        }
        return new NameValidationDto(msg, amlCount > 0);
    }

    // คำนวณหุ้นส่งรายเดือน (port legacy update_share_monthly)
    public async Task<ShareCalcDto> UpdateShareMonthlyAsync(
        string memType, string memberGroupNo, string itemChange, decimal shareMonthly, decimal sumSalary)
    {
        await using var scDb = dbFactory.create();

        var mt = await scDb.getOneAsync<MemTypeShareRow>(
            "SELECT maximun_share AS maximunshare, mproc_apart AS mprocapart FROM sc_mem_m_ucf_member_type WHERE mem_type_code = {0}", memType);
        var mg = await scDb.getOneAsync<MemGroupShareRow>(
            "SELECT ingore_dropshr_rule AS ingoredropshrrule FROM sc_mem_m_ucf_member_group WHERE member_group_no = {0}", memberGroupNo);

        decimal maximumShare = mt?.MaximunShare ?? 0;
        // เริ่มต้น: ถ้าแก้เงินเดือน → คำนวณใหม่ (0), ถ้ากรอกหุ้นเอง → คงค่าที่กรอก
        decimal result = itemChange == "salary_amount" ? 0 : shareMonthly;
        decimal? minShare = null, maxShare = null;

        // หน่วยงาน/ประเภทสมาชิกที่งดส่งหุ้น → ไม่ต้องคำนวณ
        bool skipShare = (mg?.IngoreDropshrRule == "1") || (mt?.MprocApart == "1");
        if (!skipShare)
        {
            if (itemChange == "share_monthly")
            {
                var sysName = sc.value.toString(await scDb.getValueAsync("SELECT sys_name FROM sc_cnt_m_coop")).ToUpper();
                if (sysName == "MWA")
                {
                    minShare = sc.value.toDecimal(await scDb.getValueAsync("SELECT pka_mem_ctl.fp_get_share_sendpermonth_min({0})", sumSalary));
                    maxShare = sc.value.toDecimal(await scDb.getValueAsync("SELECT pka_mem_ctl.fp_get_share_sendpermonth_max({0})", sumSalary));
                }
            }
            else if (itemChange == "salary_amount")   // เงินเดือนเปลี่ยน → set ค่าหุ้นตามสูตร
            {
                result = sc.value.toDecimal(await scDb.getValueAsync("SELECT pka_mem_ctl.fp_get_share_sendpermonth({0})", sumSalary));
                if (result > maximumShare && maximumShare > 0) result = maximumShare;
            }
        }
        return new ShareCalcDto(result, minShare, maxShare);
    }

    private record MemTypeShareRow(decimal? MaximunShare, string? MprocApart);
    private record MemGroupShareRow(string? IngoreDropshrRule);

    // ── value-change lookups (Group E — tabs) ──────────────────────────────────

    // เลขสมาชิก → pad + ชื่อเต็ม (port legacy of_validate_membership_no, ใช้ sc.scCoop)
    public async Task<MemberLookupDto?> LookupMemberAsync(string membershipNo)
    {
        if (string.IsNullOrWhiteSpace(membershipNo)) return null;
        await using var scDb = dbFactory.create();
        var coop = new sc.scCoop(scDb);
        try
        {
            var memNo = coop.ofParse(membershipNo);     // pad zeros + ตรวจว่ามีในระบบ (throw ถ้าไม่พบ)
            if (string.IsNullOrWhiteSpace(memNo)) return null;
            return new MemberLookupDto(memNo, coop.getFullName(memNo));
        }
        catch { return null; }   // ไม่พบทะเบียน → legacy onFail (เคลียร์ช่อง)
    }

    // เลขทะเบียนคู่สมรส → ข้อมูลคู่สมรส (port legacy change_spouse_member_no)
    public async Task<SpouseLookupDto?> LookupSpouseAsync(string membershipNo)
    {
        if (string.IsNullOrWhiteSpace(membershipNo)) return null;
        await using var scDb = dbFactory.create();
        var coop = new sc.scCoop(scDb);
        try
        {
            var spouseNo = coop.ofParse(membershipNo);
            if (string.IsNullOrWhiteSpace(spouseNo)) return null;
            var row = await scDb.getOneAsync<SpouseLookupDto>(
                @"SELECT membership_no AS spousememberno,
                         prename_code   AS prenamecode,
                         member_name    AS spousename,
                         member_surname AS spousesurname,
                         id_card        AS idcard
                  FROM sc_mem_m_membership_registered WHERE membership_no = {0}", spouseNo);
            if (row is null) return null;
            // เก็บ id_card เฉพาะที่ครบ 13 หลัก (legacy เช็ค length == 13)
            return row.IdCard?.Length == 13 ? row : row with { IdCard = "" };
        }
        catch { return null; }
    }

    // รายชื่อ ปปง. ที่ตรง (port legacy popValidateAML.ofLoad)
    public async Task<List<AmlMatchDto>> GetAmlMatchesAsync(string popType, string name, string surname, string humId)
    {
        await using var scDb = dbFactory.create();
        const string baseSql =
            @"SELECT seq_no AS seqno, aml_date AS amldate,
                     aml_prename||' '||aml_name||'  '||aml_surname AS amlfullname,
                     aml_id AS amlid, aml_birth::text AS amlbirth,
                     aml_bookno AS amlbookno, aml_remark AS amlremark
              FROM sc_mem_m_member_aml WHERE 1=1 ";
        return popType == "popName"
            ? await scDb.getListAsync<AmlMatchDto>(baseSql + "AND aml_name = {0} AND aml_surname = {1} ORDER BY seq_no", name, surname)
            : await scDb.getListAsync<AmlMatchDto>(baseSql + "AND aml_id = {0} ORDER BY seq_no", humId);
    }

    // row types สำหรับ validate (Group C)
    private record MemReqRow(string? ApplicationFormNo, string? MemberName);
    private record MemRegRow(string? MembershipNo, string? MemberName, string? MemberStatusCode,
        string? ResignDateText, DateTime? ResignDateRaw, string? ApproveDateText, string? ResignCode);

    // ── Private helpers ───────────────────────────────────────────────────────

    // pre-save validation: สมาชิกประเภท 02 (สมทบ) ต้องมีสมาชิกอ้างอิง (port legacy panHead.ofValidateMemberType)
    // legacy (single head field): mem_type=='02' && concern_code!='00' && ไม่มี membership_no → throw C478
    // ⚠️ เบี่ยง (อธิบาย): model ใหม่ member_refer เป็น list (Form.MemberRefers) ไม่ใช่ field เดี่ยวบน head
    //    → ตีความกฎเป็น "สมทบ ต้องมีสมาชิกอ้างอิง ≥1 ราย ที่ระบุเลขสมาชิก" (คงเจตนา legacy: สมทบต้องมีผู้อ้างอิง)
    //    code '02' = สมทบ legacy hardcode ('fix code 02 ทุก coop')
    static void ValidateMemberType(ApplicationFormDto dto)
    {
        if (dto.MemType == "02" &&
            !dto.MemberRefers.Any(r => !string.IsNullOrWhiteSpace(r.MembershipNo)))
            throw new InvalidOperationException(
                sc.msg.C("สมาชิกประเภท 02 - สมทบ ต้องมีสมาชิกอ้างอิง โปรดตรวจสอบ"));
    }

    // ตัด mask literal (ขีด/ช่องว่าง) ของช่องที่ใช้ text mask ก่อนเก็บลง DB
    // DxMaskedInput เก็บค่ารวมตัวคั่น → เลขบัตร 13 หลักกลายเป็น 17 ตัว ล้น varchar(15)
    static void NormalizeMaskedFields(ApplicationFormDto dto)
    {
        dto.HumId = sc.mask.ofDigits(dto.HumId);                       // hum_id varchar(15)
        if (dto.SpouseInfo is not null)
            dto.SpouseInfo.IdCard = sc.mask.ofDigits(dto.SpouseInfo.IdCard);  // id_card varchar(15)
    }

    // เลขที่ใบสมัคร — เรียกฟังก์ชัน docno ที่ migrate มาจาก Oracle (เลียน legacy ofGetDocno):
    //   sp_gen_application_form_no เก็บผลใน session GUC → fp_gen_application_form_no อ่านกลับ
    //   (2 หลักท้ายปี พ.ศ. + เลขรัน 5 หลัก เช่น 6900001) — running-number ที่ sc_cnt_m_document_no_control
    //   migration: sql/migrations/2026-06-08_pka_docno_mem_appli.sql
    static async Task<string> GenApplicationFormNoAsync(sc.db scDb)
    {
        await scDb.pkProcedureAsync("pka_mem_newmem.sp_gen_application_form_no()");
        return sc.value.toString(await scDb.pkFunctionAsync("pka_mem_newmem.fp_gen_application_form_no()"));
    }

    // hook: รูป/ลายเซ็น — decode base64 → byte[] (logic เฉพาะที่ engine ไม่ครอบ → [SaveIgnore] บน DTO)
    static async Task SavePictureSignatureAsync(sc.db scDb, string appNo, ApplicationFormDto dto, bool isUpdate)
    {
        if (isUpdate)
        {
            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_picture   WHERE application_form_no = {0}", appNo);
            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_signature WHERE application_form_no = {0}", appNo);
        }

        if (dto.PictureBase64 is not null)
            await scDb.dbInsertAsync("sc_mem_m_app_picture", new {
                ApplicationFormNo = appNo,
                AppPicture        = Convert.FromBase64String(dto.PictureBase64),
            });

        if (dto.SignatureBase64 is not null)
            await scDb.dbInsertAsync("sc_mem_m_app_signature", new {
                ApplicationFormNo = appNo,
                AppSignature      = Convert.FromBase64String(dto.SignatureBase64),
            });
    }

    private record ShareRow(decimal? ShareMonthly);
    private class PictureRow   { public byte[]? AppPicture   { get; init; } }
    private class SignatureRow { public byte[]? AppSignature { get; init; } }

    // บัญชีธนาคาร — flag เก็บ char(1) อ่านเป็น string แล้ว map → bool ที่ caller
    private class BankAccnoRow
    {
        public int     SeqNo         { get; init; }
        public string? BankId        { get; init; }
        public string? BankBranchId  { get; init; }
        public string? BankAccNo     { get; init; }
        public string? PaidLoan      { get; init; }
        public string? AtmLon        { get; init; }
        public string? AtmDep        { get; init; }
        public string? PaidDividen   { get; init; }
        public string? ShareWithdraw { get; init; }
        public string? KeepMonthly   { get; init; }
        public string? PaidAgent     { get; init; }
        public string? PaidSalary    { get; init; }
    }
}
