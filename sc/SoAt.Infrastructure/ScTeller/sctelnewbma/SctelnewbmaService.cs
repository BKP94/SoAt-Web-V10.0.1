using SoAt.Application.ScTeller;

namespace SoAt.Infrastructure.ScTeller;

public class SctelnewbmaService(sc.dbFactory dbFactory) : ISctelnewbmaService
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
            var appNo = await GenApplicationFormNoAsync(scDb);
            var now   = DateTime.UtcNow;

            await scDb.dbInsertAsync("sc_mem_m_application_form", new {
                ApplicationFormNo = appNo,
                ApplyDate         = dto.ApplyDate ?? DateTime.Today,
                PrenameCode       = dto.PrenameCode,
                MemberName        = dto.MemberName,
                MemberSurname     = dto.MemberSurname,
                MemberGroupNo     = dto.MemberGroupNo,
                MemType           = dto.MemType,
                DateOfBirth       = dto.DateOfBirth,
                Sex               = dto.Sex,
                ApplTypeCode      = dto.ApplTypeCode,
                HumId             = dto.HumId,
                MarriageStatus    = dto.MarriageStatus,
                NationalityCode   = dto.NationalityCode,
                BloodCode         = dto.BloodCode,
                MobileNumber      = dto.MobileNumber,
                Email             = dto.Email,
                Remark            = dto.Remark,
                ApproveStatus     = "2",
                CancelStatus      = "0",
                PrenameEng        = dto.PrenameEng,
                NameEng           = dto.NameEng,
                SurnameEng        = dto.SurnameEng,
                IdCardDate        = dto.IdCardDate,
                IdCardEnddate     = dto.IdCardEnddate,
                IdCardNumber      = dto.IdCardNumber,
                IdCardOrganize    = dto.IdCardOrganize,
                ElectionGroup     = dto.ElectionGroup,
                CreatedAt         = now,
                UpdatedAt         = now,
                CreatedBy         = userId,
                UpdatedBy         = userId,
            });

            await InsertAddressesAsync(scDb, appNo, dto);

            if (dto.WorkInfo is not null)
                await InsertWorkInfoAsync(scDb, appNo, dto.WorkInfo);

            if (dto.ShareMonthly.HasValue)
                await scDb.dbInsertAsync("sc_mem_m_app_share", new {
                    ApplicationFormNo = appNo,
                    ShareMonthly      = dto.ShareMonthly,
                });

            for (int i = 0; i < dto.MemberRefers.Count; i++)
                await InsertMemberReferAsync(scDb, appNo, dto.MemberRefers[i], i + 1);

            for (int i = 0; i < dto.RecrieveGains.Count; i++)
                await InsertRecrieveGainAsync(scDb, appNo, dto.RecrieveGains[i], i + 1);

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

            await scDb.ofConnectionCloseAsync("CreateApplication");
            return new ApplicationFormSaveResult(appNo, "บันทึกใบสมัครสำเร็จ");
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

            var now = DateTime.UtcNow;

            await scDb.dbUpdateAsync("sc_mem_m_application_form", new {
                ApplicationFormNo = applicationFormNo,
                ApplyDate         = dto.ApplyDate ?? DateTime.Today,
                PrenameCode       = dto.PrenameCode,
                MemberName        = dto.MemberName,
                MemberSurname     = dto.MemberSurname,
                MemberGroupNo     = dto.MemberGroupNo,
                MemType           = dto.MemType,
                DateOfBirth       = dto.DateOfBirth,
                Sex               = dto.Sex,
                ApplTypeCode      = dto.ApplTypeCode,
                HumId             = dto.HumId,
                MarriageStatus    = dto.MarriageStatus,
                NationalityCode   = dto.NationalityCode,
                BloodCode         = dto.BloodCode,
                MobileNumber      = dto.MobileNumber,
                Email             = dto.Email,
                Remark            = dto.Remark,
                PrenameEng        = dto.PrenameEng,
                NameEng           = dto.NameEng,
                SurnameEng        = dto.SurnameEng,
                IdCardDate        = dto.IdCardDate,
                IdCardEnddate     = dto.IdCardEnddate,
                IdCardNumber      = dto.IdCardNumber,
                IdCardOrganize    = dto.IdCardOrganize,
                ElectionGroup     = dto.ElectionGroup,
                UpdatedAt         = now,
                UpdatedBy         = userId,
            }, "application_form_no");

            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_address       WHERE application_form_no = {0}", applicationFormNo);
            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_work_info      WHERE application_form_no = {0}", applicationFormNo);
            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_share          WHERE application_form_no = {0}", applicationFormNo);
            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_member_refer   WHERE application_form_no = {0}", applicationFormNo);
            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_recrieve_gain  WHERE application_form_no = {0}", applicationFormNo);
            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_picture        WHERE application_form_no = {0}", applicationFormNo);
            await scDb.dbDeleteAsync("DELETE FROM sc_mem_m_app_signature      WHERE application_form_no = {0}", applicationFormNo);

            await InsertAddressesAsync(scDb, applicationFormNo, dto);

            if (dto.WorkInfo is not null)
                await InsertWorkInfoAsync(scDb, applicationFormNo, dto.WorkInfo);

            if (dto.ShareMonthly.HasValue)
                await scDb.dbInsertAsync("sc_mem_m_app_share", new {
                    ApplicationFormNo = applicationFormNo,
                    ShareMonthly      = dto.ShareMonthly,
                });

            for (int i = 0; i < dto.MemberRefers.Count; i++)
                await InsertMemberReferAsync(scDb, applicationFormNo, dto.MemberRefers[i], i + 1);

            for (int i = 0; i < dto.RecrieveGains.Count; i++)
                await InsertRecrieveGainAsync(scDb, applicationFormNo, dto.RecrieveGains[i], i + 1);

            if (dto.PictureBase64 is not null)
                await scDb.dbInsertAsync("sc_mem_m_app_picture", new {
                    ApplicationFormNo = applicationFormNo,
                    AppPicture        = Convert.FromBase64String(dto.PictureBase64),
                });

            if (dto.SignatureBase64 is not null)
                await scDb.dbInsertAsync("sc_mem_m_app_signature", new {
                    ApplicationFormNo = applicationFormNo,
                    AppSignature      = Convert.FromBase64String(dto.SignatureBase64),
                });

            await scDb.ofConnectionCloseAsync("UpdateApplication");
            return new ApplicationFormSaveResult(applicationFormNo, "อัปเดตใบสมัครสำเร็จ");
        }
        catch
        {
            await scDb.ofConnectionCloseAsync("UpdateApplication-Error", onError: true);
            throw;
        }
    }

    // ── Private helpers ───────────────────────────────────────────────────────

    static async Task<string> GenApplicationFormNoAsync(sc.db scDb)
    {
        var yearPrefix = DateTime.Now.Year.ToString()[2..];
        var maxNo = sc.value.toString(await scDb.getValueAsync(
            "SELECT MAX(application_form_no) FROM sc_mem_m_application_form WHERE application_form_no LIKE {0}",
            yearPrefix + "%"));
        int nextSeq = 1;
        if (maxNo.Length >= 7 && int.TryParse(maxNo[2..], out var prev))
            nextSeq = prev + 1;
        return yearPrefix + nextSeq.ToString("D5");
    }

    static async Task InsertAddressesAsync(sc.db scDb, string appNo, ApplicationFormDto dto)
    {
        if (dto.AddressCurrent is not null)
            await InsertAddressAsync(scDb, appNo, "0", dto.AddressCurrent);
        if (dto.AddressHome is not null)
            await InsertAddressAsync(scDb, appNo, "1", dto.AddressHome);
        if (dto.AddressWork is not null)
            await InsertAddressAsync(scDb, appNo, "2", dto.AddressWork);
    }

    static Task InsertAddressAsync(sc.db scDb, string appNo, string addressType, AppAddressDto a) =>
        scDb.dbInsertAsync("sc_mem_m_app_address", new {
            ApplicationFormNo = appNo,
            AddressType       = addressType,
            a.AddressNo,
            a.Moo,
            a.Mooban,
            a.Soi,
            a.Road,
            a.Tambol,
            a.DistrictCode,
            a.ProvinceCode,
            a.Postcode,
            a.Telephone,
        });

    static Task InsertWorkInfoAsync(sc.db scDb, string appNo, AppWorkInfoDto w) =>
        scDb.dbInsertAsync("sc_mem_m_app_work_info", new {
            ApplicationFormNo  = appNo,
            w.WorkingDate,
            w.SalaryId,
            w.GroupOther,
            w.GroupPosition,
            w.PositionLong,
            w.LevelCode,
            w.SalaryRateCode,
            w.SalaryAmount,
            w.AcademicSalary,
            w.RemunerationAmount,
            w.SalaryReal,
            w.EndingcontractDate,
        });

    static Task InsertMemberReferAsync(sc.db scDb, string appNo, AppMemberReferDto m, int seq) =>
        scDb.dbInsertAsync("sc_mem_m_app_member_refer", new {
            ApplicationFormNo = appNo,
            SeqNo             = seq,
            m.MembershipNo,
            m.MemberName,
            m.ConcernCode,
        });

    static Task InsertRecrieveGainAsync(sc.db scDb, string appNo, AppRecrieveGainDto g, int seq) =>
        scDb.dbInsertAsync("sc_mem_m_app_recrieve_gain", new {
            ApplicationFormNo = appNo,
            SeqNo             = seq,
            g.PrenameCode,
            g.GainName,
            g.GainSurname,
            g.ConcernCode,
            g.WefType,
            g.GainPercent,
            g.GainIdCard,
            g.BookDate,
            g.OrderNumber,
            g.GainAddress,
            g.GainTelephone,
            g.GainDesc,
        });

    // TODO(tabs persistence): ยังไม่ load/save 3 sub-table ของ PanTabs —
    //   bankinfo (sc_mem_m_app_bank_accno, หลายแถว), spouse (sc_mem_m_app_spouse_info),
    //   own-info (sc_mem_m_app_own_info) + header Father/Mother. UI bind ครบแล้วใน Components/Pages/sctelnewbma/tabs/
    //   เหลือต่อ Get/Create/Update + delete-reinsert pattern เหมือน sub-table อื่น (รอบหน้า)

    private record ShareRow(decimal? ShareMonthly);
    private class PictureRow   { public byte[]? AppPicture   { get; init; } }
    private class SignatureRow { public byte[]? AppSignature { get; init; } }
}
