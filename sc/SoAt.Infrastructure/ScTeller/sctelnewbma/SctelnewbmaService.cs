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
                throw new KeyNotFoundException($"ไม่พบใบสมัครเลขที่ {applicationFormNo}");
            if (approveStatus == "1")
                throw new InvalidOperationException("ไม่สามารถแก้ไขใบสมัครที่อนุมัติแล้ว");

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
            sql.Append(" AND EXISTS (SELECT NULL FROM sc_mem_m_ucf_member_group mg" +
                       " WHERE mg.member_group_no = a.member_group_no" +
                       " AND (mg.member_group_no LIKE {" + i + "} OR mg.member_group_name LIKE {" + i + "}))");
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

    // ── Private helpers ───────────────────────────────────────────────────────

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
