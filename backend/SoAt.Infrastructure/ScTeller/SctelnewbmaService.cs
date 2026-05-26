using Microsoft.EntityFrameworkCore;
using SoAt.Application.ScTeller;
using SoAt.Domain.Entities.Mem;
using SoAt.Infrastructure.Persistence;

namespace SoAt.Infrastructure.ScTeller;

public class SctelnewbmaService(AppDbContext db) : ISctelnewbmaService
{
    // ── Lookups ───────────────────────────────────────────────────────────────

    public async Task<SctelnewbmaLookupsDto> GetLookupsAsync()
    {
        var prenames = await db.ScMemMUcfPrenames
            .OrderBy(x => x.PrenameCode)
            .Select(x => new PrenameDto(x.PrenameCode, x.Prename, x.Sex, x.MarriageStatus))
            .ToListAsync();

        var memberTypes = await db.ScMemMUcfMemberTypes
            .OrderBy(x => x.MemTypeCode)
            .Select(x => new MemberTypeDto(x.MemTypeCode, x.MemTypeDesc, x.MaximunShare, x.NotSalary, x.MprocApart))
            .ToListAsync();

        var memberGroups = await db.ScMemMUcfMemberGroups
            .OrderBy(x => x.MemberGroupNo)
            .Select(x => new MemberGroupDto(x.MemberGroupNo, x.MemberGroupName, x.MemTypeDefault, x.NotSal, x.IngoreDropshrRule))
            .ToListAsync();

        var electionGroups = await db.ScMemMUcfElectionGroups
            .OrderBy(x => x.ElectionGroup)
            .Select(x => new ElectionGroupDto(x.ElectionGroup, x.ElectionGroupName, x.ElectionZone))
            .ToListAsync();

        var nationalities = await db.ScMemMUcfNationalities
            .OrderBy(x => x.NationalityCode)
            .Select(x => new NationalityDto(x.NationalityCode, x.NationalityDescription))
            .ToListAsync();

        var marriageStatuses = await db.ScMemMUcfMarriageStatuses
            .OrderBy(x => x.MarriageStatusCode)
            .Select(x => new MarriageStatusDto(x.MarriageStatusCode, x.MarriageStatusName))
            .ToListAsync();

        var bloods = await db.ScMemMUcfBloods
            .OrderBy(x => x.BloodCode)
            .Select(x => new BloodDto(x.BloodCode, x.BloodDesc))
            .ToListAsync();

        var provinces = await db.ScMemMUcfProvinces
            .OrderBy(x => x.ProvinceCode)
            .Select(x => new ProvinceDto(x.ProvinceCode, x.ProvinceName))
            .ToListAsync();

        var districts = await db.ScMemMUcfDistricts
            .OrderBy(x => x.DistrictCode)
            .Select(x => new DistrictDto(x.DistrictCode, x.DistrictName, x.ProvinceCode, x.PostCode))
            .ToListAsync();

        var subdistricts = await db.ScMemMUcfSubdistricts
            .OrderBy(x => x.SubdistrictCode)
            .Select(x => new SubdistrictDto(x.SubdistrictCode, x.SubdistrictName, x.DistrictCode))
            .ToListAsync();

        // ApplicationType: ยกเว้น code='0' (same rule as Oracle: appl_type_code <> '0')
        var applicationTypes = await db.ScMemMUcfApplicationTypes
            .Where(x => x.ApplTypeCode != "0")
            .OrderBy(x => x.ApplTypeCode)
            .Select(x => new ApplicationTypeDto(x.ApplTypeCode, x.ApplTypeName, x.ApplicationFee, x.MemTypeCode))
            .ToListAsync();

        var concerns = await db.ScMemMUcfConcerns
            .Select(x => new ConcernDto(x.ConcernCode, x.RelatedNa))
            .ToListAsync();

        var groupPositions = await db.ScMemMUcfGroupPositions
            .OrderBy(x => x.SortOrder)
            .Select(x => new GroupPositionDto(x.GroupPosition, x.Description, x.SortOrder))
            .ToListAsync();

        var positions = await db.ScMemMUcfPositions
            .OrderBy(x => x.SortOrder)
            .Select(x => new PositionDto(x.PositionCode, x.PositionName, x.SortOrder))
            .ToListAsync();

        var coop = await db.ScCntMCoops
            .Select(x => new CoopConfigDto(x.CoopNo, x.CountResign, x.AutoApproveNewmem, x.MemTypeOngroup))
            .FirstOrDefaultAsync();

        return new SctelnewbmaLookupsDto
        {
            Prenames         = prenames,
            MemberTypes      = memberTypes,
            MemberGroups     = memberGroups,
            ElectionGroups   = electionGroups,
            Nationalities    = nationalities,
            MarriageStatuses = marriageStatuses,
            Bloods           = bloods,
            Provinces        = provinces,
            Districts        = districts,
            Subdistricts     = subdistricts,
            ApplicationTypes = applicationTypes,
            Concerns         = concerns,
            GroupPositions   = groupPositions,
            Positions        = positions,
            CoopConfig       = coop,
        };
    }

    // ── Get Application ───────────────────────────────────────────────────────

    public async Task<ApplicationFormDto?> GetApplicationAsync(string applicationFormNo)
    {
        var form = await db.ScMemMApplicationForms
            .FirstOrDefaultAsync(f => f.ApplicationFormNo == applicationFormNo);
        if (form is null) return null;

        var addresses = await db.ScMemMAppAddresses
            .Where(a => a.ApplicationFormNo == applicationFormNo)
            .ToListAsync();

        var workInfo = await db.ScMemMAppWorkInfos
            .FirstOrDefaultAsync(w => w.ApplicationFormNo == applicationFormNo);

        var share = await db.ScMemMAppShares
            .FirstOrDefaultAsync(s => s.ApplicationFormNo == applicationFormNo);

        var memberRefers = await db.ScMemMAppMemberRefers
            .Where(r => r.ApplicationFormNo == applicationFormNo)
            .OrderBy(r => r.SeqNo)
            .ToListAsync();

        var recrieveGains = await db.ScMemMAppRecrieveGains
            .Where(g => g.ApplicationFormNo == applicationFormNo)
            .OrderBy(g => g.SeqNo)
            .ToListAsync();

        var picture = await db.ScMemMAppPictures
            .FirstOrDefaultAsync(p => p.ApplicationFormNo == applicationFormNo);

        var signature = await db.ScMemMAppSignatures
            .FirstOrDefaultAsync(s => s.ApplicationFormNo == applicationFormNo);

        return MapToDto(form, addresses, workInfo, share, memberRefers, recrieveGains, picture, signature);
    }

    // ── Create Application ────────────────────────────────────────────────────

    public async Task<ApplicationFormSaveResult> CreateApplicationAsync(
        ApplicationFormDto dto, string userId, string branchId)
    {
        var appNo = await GenApplicationFormNoAsync();
        var now   = DateTime.UtcNow;

        // header
        var form = new ScMemMApplicationForm
        {
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
            ApproveStatus     = "2",   // รออนุมัติ
            CancelStatus      = "0",   // ปกติ
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
        };
        db.ScMemMApplicationForms.Add(form);

        // addresses
        SaveAddresses(appNo, dto);

        // work info
        if (dto.WorkInfo is not null)
            db.ScMemMAppWorkInfos.Add(MapWorkInfo(appNo, dto.WorkInfo));

        // share
        if (dto.ShareMonthly.HasValue)
            db.ScMemMAppShares.Add(new ScMemMAppShare
                { ApplicationFormNo = appNo, ShareMonthly = dto.ShareMonthly });

        // member refers
        for (int i = 0; i < dto.MemberRefers.Count; i++)
            db.ScMemMAppMemberRefers.Add(MapMemberRefer(appNo, dto.MemberRefers[i], i + 1));

        // recrieve gains
        for (int i = 0; i < dto.RecrieveGains.Count; i++)
            db.ScMemMAppRecrieveGains.Add(MapRecrieveGain(appNo, dto.RecrieveGains[i], i + 1));

        // picture / signature
        if (dto.PictureBase64 is not null)
            db.ScMemMAppPictures.Add(new ScMemMAppPicture
                { ApplicationFormNo = appNo, AppPicture = Convert.FromBase64String(dto.PictureBase64) });

        if (dto.SignatureBase64 is not null)
            db.ScMemMAppSignatures.Add(new ScMemMAppSignature
                { ApplicationFormNo = appNo, AppSignature = Convert.FromBase64String(dto.SignatureBase64) });

        await db.SaveChangesAsync();
        return new ApplicationFormSaveResult(appNo, "บันทึกใบสมัครสำเร็จ");
    }

    // ── Update Application ────────────────────────────────────────────────────

    public async Task<ApplicationFormSaveResult> UpdateApplicationAsync(
        string applicationFormNo, ApplicationFormDto dto, string userId)
    {
        var form = await db.ScMemMApplicationForms
            .FirstOrDefaultAsync(f => f.ApplicationFormNo == applicationFormNo)
            ?? throw new KeyNotFoundException($"ไม่พบใบสมัครเลขที่ {applicationFormNo}");

        if (form.ApproveStatus == "1")
            throw new InvalidOperationException("ไม่สามารถแก้ไขใบสมัครที่อนุมัติแล้ว");

        var now = DateTime.UtcNow;

        // update header fields
        form.ApplyDate      = dto.ApplyDate ?? form.ApplyDate;
        form.PrenameCode    = dto.PrenameCode;
        form.MemberName     = dto.MemberName;
        form.MemberSurname  = dto.MemberSurname;
        form.MemberGroupNo  = dto.MemberGroupNo;
        form.MemType        = dto.MemType;
        form.DateOfBirth    = dto.DateOfBirth;
        form.Sex            = dto.Sex;
        form.ApplTypeCode   = dto.ApplTypeCode;
        form.HumId          = dto.HumId;
        form.MarriageStatus = dto.MarriageStatus;
        form.NationalityCode= dto.NationalityCode;
        form.BloodCode      = dto.BloodCode;
        form.MobileNumber   = dto.MobileNumber;
        form.Email          = dto.Email;
        form.Remark         = dto.Remark;
        form.PrenameEng     = dto.PrenameEng;
        form.NameEng        = dto.NameEng;
        form.SurnameEng     = dto.SurnameEng;
        form.IdCardDate     = dto.IdCardDate;
        form.IdCardEnddate  = dto.IdCardEnddate;
        form.IdCardNumber   = dto.IdCardNumber;
        form.IdCardOrganize = dto.IdCardOrganize;
        form.ElectionGroup  = dto.ElectionGroup;
        form.UpdatedAt      = now;
        form.UpdatedBy      = userId;

        // replace sub-tables (delete + re-insert)
        var oldAddresses = db.ScMemMAppAddresses.Where(a => a.ApplicationFormNo == applicationFormNo);
        db.ScMemMAppAddresses.RemoveRange(oldAddresses);

        var oldWork = db.ScMemMAppWorkInfos.Where(w => w.ApplicationFormNo == applicationFormNo);
        db.ScMemMAppWorkInfos.RemoveRange(oldWork);

        var oldShare = db.ScMemMAppShares.Where(s => s.ApplicationFormNo == applicationFormNo);
        db.ScMemMAppShares.RemoveRange(oldShare);

        var oldRefers = db.ScMemMAppMemberRefers.Where(r => r.ApplicationFormNo == applicationFormNo);
        db.ScMemMAppMemberRefers.RemoveRange(oldRefers);

        var oldGains = db.ScMemMAppRecrieveGains.Where(g => g.ApplicationFormNo == applicationFormNo);
        db.ScMemMAppRecrieveGains.RemoveRange(oldGains);

        var oldPic = db.ScMemMAppPictures.Where(p => p.ApplicationFormNo == applicationFormNo);
        db.ScMemMAppPictures.RemoveRange(oldPic);

        var oldSig = db.ScMemMAppSignatures.Where(s => s.ApplicationFormNo == applicationFormNo);
        db.ScMemMAppSignatures.RemoveRange(oldSig);

        await db.SaveChangesAsync(); // flush deletes first

        // re-insert sub-tables
        SaveAddresses(applicationFormNo, dto);

        if (dto.WorkInfo is not null)
            db.ScMemMAppWorkInfos.Add(MapWorkInfo(applicationFormNo, dto.WorkInfo));

        if (dto.ShareMonthly.HasValue)
            db.ScMemMAppShares.Add(new ScMemMAppShare
                { ApplicationFormNo = applicationFormNo, ShareMonthly = dto.ShareMonthly });

        for (int i = 0; i < dto.MemberRefers.Count; i++)
            db.ScMemMAppMemberRefers.Add(MapMemberRefer(applicationFormNo, dto.MemberRefers[i], i + 1));

        for (int i = 0; i < dto.RecrieveGains.Count; i++)
            db.ScMemMAppRecrieveGains.Add(MapRecrieveGain(applicationFormNo, dto.RecrieveGains[i], i + 1));

        if (dto.PictureBase64 is not null)
            db.ScMemMAppPictures.Add(new ScMemMAppPicture
                { ApplicationFormNo = applicationFormNo, AppPicture = Convert.FromBase64String(dto.PictureBase64) });

        if (dto.SignatureBase64 is not null)
            db.ScMemMAppSignatures.Add(new ScMemMAppSignature
                { ApplicationFormNo = applicationFormNo, AppSignature = Convert.FromBase64String(dto.SignatureBase64) });

        await db.SaveChangesAsync();
        return new ApplicationFormSaveResult(applicationFormNo, "อัปเดตใบสมัครสำเร็จ");
    }

    // ── Private helpers ───────────────────────────────────────────────────────

    /// <summary>
    /// สร้าง application_form_no แบบ YY + 5 digits เช่น "2600001"
    /// (เทียบเท่า pka_mem_newmem.sp_gen_application_form_no ใน Oracle)
    /// </summary>
    async Task<string> GenApplicationFormNoAsync()
    {
        var yearPrefix = DateTime.Now.Year.ToString()[2..]; // "26" for 2026
        var maxNo = await db.ScMemMApplicationForms
            .Where(f => f.ApplicationFormNo.StartsWith(yearPrefix))
            .OrderByDescending(f => f.ApplicationFormNo)
            .Select(f => f.ApplicationFormNo)
            .FirstOrDefaultAsync();

        int nextSeq = 1;
        if (maxNo is not null && maxNo.Length >= 7 &&
            int.TryParse(maxNo[2..], out var prev))
            nextSeq = prev + 1;

        return yearPrefix + nextSeq.ToString("D5");
    }

    void SaveAddresses(string appNo, ApplicationFormDto dto)
    {
        if (dto.AddressCurrent is not null)
            db.ScMemMAppAddresses.Add(MapAddress(appNo, "0", dto.AddressCurrent));
        if (dto.AddressHome is not null)
            db.ScMemMAppAddresses.Add(MapAddress(appNo, "1", dto.AddressHome));
        if (dto.AddressWork is not null)
            db.ScMemMAppAddresses.Add(MapAddress(appNo, "2", dto.AddressWork));
    }

    static ScMemMAppAddress MapAddress(string appNo, string addressType, AppAddressDto dto) =>
        new()
        {
            ApplicationFormNo = appNo,
            AddressType       = addressType,
            AddressNo         = dto.AddressNo,
            Moo               = dto.Moo,
            Mooban            = dto.Mooban,
            Soi               = dto.Soi,
            Road              = dto.Road,
            Tambol            = dto.Tambol,
            DistrictCode      = dto.DistrictCode,
            ProvinceCode      = dto.ProvinceCode,
            Postcode          = dto.Postcode,
            Telephone         = dto.Telephone,
        };

    static ScMemMAppWorkInfo MapWorkInfo(string appNo, AppWorkInfoDto dto) =>
        new()
        {
            ApplicationFormNo   = appNo,
            WorkingDate         = dto.WorkingDate,
            SalaryId            = dto.SalaryId,
            GroupOther          = dto.GroupOther,
            GroupPosition       = dto.GroupPosition,
            PositionLong        = dto.PositionLong,
            LevelCode           = dto.LevelCode,
            SalaryRateCode      = dto.SalaryRateCode,
            SalaryAmount        = dto.SalaryAmount,
            AcademicSalary      = dto.AcademicSalary,
            RemunerationAmount  = dto.RemunerationAmount,
            SalaryReal          = dto.SalaryReal,
            EndingcontractDate  = dto.EndingcontractDate,
        };

    static ScMemMAppMemberRefer MapMemberRefer(string appNo, AppMemberReferDto dto, int seq) =>
        new()
        {
            ApplicationFormNo = appNo,
            SeqNo             = seq,
            MembershipNo      = dto.MembershipNo,
            MemberName        = dto.MemberName,
            ConcernCode       = dto.ConcernCode,
        };

    static ScMemMAppRecrieveGain MapRecrieveGain(string appNo, AppRecrieveGainDto dto, int seq) =>
        new()
        {
            ApplicationFormNo = appNo,
            SeqNo             = seq,
            PrenameCode       = dto.PrenameCode,
            GainName          = dto.GainName,
            GainSurname       = dto.GainSurname,
            ConcernCode       = dto.ConcernCode,
            WefType           = dto.WefType,
            GainPercent       = dto.GainPercent,
            GainIdCard        = dto.GainIdCard,
            BookDate          = dto.BookDate,
            OrderNumber       = dto.OrderNumber,
            GainAddress       = dto.GainAddress,
            GainTelephone     = dto.GainTelephone,
            GainDesc          = dto.GainDesc,
        };

    static ApplicationFormDto MapToDto(
        ScMemMApplicationForm form,
        List<ScMemMAppAddress> addresses,
        ScMemMAppWorkInfo? workInfo,
        ScMemMAppShare? share,
        List<ScMemMAppMemberRefer> memberRefers,
        List<ScMemMAppRecrieveGain> recrieveGains,
        ScMemMAppPicture? picture,
        ScMemMAppSignature? signature)
    {
        return new ApplicationFormDto
        {
            ApplicationFormNo = form.ApplicationFormNo,
            ApplyDate         = form.ApplyDate,
            PrenameCode       = form.PrenameCode,
            MemberName        = form.MemberName,
            MemberSurname     = form.MemberSurname,
            MemberGroupNo     = form.MemberGroupNo,
            MemType           = form.MemType,
            DateOfBirth       = form.DateOfBirth,
            Sex               = form.Sex,
            ApplTypeCode      = form.ApplTypeCode,
            HumId             = form.HumId,
            MarriageStatus    = form.MarriageStatus,
            NationalityCode   = form.NationalityCode,
            BloodCode         = form.BloodCode,
            MobileNumber      = form.MobileNumber,
            Email             = form.Email,
            Remark            = form.Remark,
            ApproveStatus     = form.ApproveStatus,
            CancelStatus      = form.CancelStatus,
            PrenameEng        = form.PrenameEng,
            NameEng           = form.NameEng,
            SurnameEng        = form.SurnameEng,
            IdCardDate        = form.IdCardDate,
            IdCardEnddate     = form.IdCardEnddate,
            IdCardNumber      = form.IdCardNumber,
            IdCardOrganize    = form.IdCardOrganize,
            ElectionGroup     = form.ElectionGroup,
            AddressCurrent    = MapAddressDto(addresses.FirstOrDefault(a => a.AddressType == "0")),
            AddressHome       = MapAddressDto(addresses.FirstOrDefault(a => a.AddressType == "1")),
            AddressWork       = MapAddressDto(addresses.FirstOrDefault(a => a.AddressType == "2")),
            WorkInfo          = workInfo is null ? null : new AppWorkInfoDto
            {
                WorkingDate        = workInfo.WorkingDate,
                SalaryId           = workInfo.SalaryId,
                GroupOther         = workInfo.GroupOther,
                GroupPosition      = workInfo.GroupPosition,
                PositionLong       = workInfo.PositionLong,
                LevelCode          = workInfo.LevelCode,
                SalaryRateCode     = workInfo.SalaryRateCode,
                SalaryAmount       = workInfo.SalaryAmount,
                AcademicSalary     = workInfo.AcademicSalary,
                RemunerationAmount = workInfo.RemunerationAmount,
                SalaryReal         = workInfo.SalaryReal,
                EndingcontractDate = workInfo.EndingcontractDate,
            },
            ShareMonthly  = share?.ShareMonthly,
            MemberRefers  = memberRefers.Select(r => new AppMemberReferDto
            {
                SeqNo       = r.SeqNo,
                MembershipNo = r.MembershipNo,
                MemberName  = r.MemberName,
                ConcernCode = r.ConcernCode,
            }).ToList(),
            RecrieveGains = recrieveGains.Select(g => new AppRecrieveGainDto
            {
                SeqNo         = g.SeqNo,
                PrenameCode   = g.PrenameCode,
                GainName      = g.GainName,
                GainSurname   = g.GainSurname,
                ConcernCode   = g.ConcernCode,
                WefType       = g.WefType,
                GainPercent   = g.GainPercent,
                GainIdCard    = g.GainIdCard,
                BookDate      = g.BookDate,
                OrderNumber   = g.OrderNumber,
                GainAddress   = g.GainAddress,
                GainTelephone = g.GainTelephone,
                GainDesc      = g.GainDesc,
            }).ToList(),
            PictureBase64   = picture?.AppPicture is null ? null : Convert.ToBase64String(picture.AppPicture),
            SignatureBase64 = signature?.AppSignature is null ? null : Convert.ToBase64String(signature.AppSignature),
        };
    }

    static AppAddressDto? MapAddressDto(ScMemMAppAddress? addr)
    {
        if (addr is null) return null;
        return new AppAddressDto
        {
            AddressType  = addr.AddressType,
            AddressNo    = addr.AddressNo,
            Moo          = addr.Moo,
            Mooban       = addr.Mooban,
            Soi          = addr.Soi,
            Road         = addr.Road,
            Tambol       = addr.Tambol,
            DistrictCode = addr.DistrictCode,
            ProvinceCode = addr.ProvinceCode,
            Postcode     = addr.Postcode,
            Telephone    = addr.Telephone,
        };
    }
}
