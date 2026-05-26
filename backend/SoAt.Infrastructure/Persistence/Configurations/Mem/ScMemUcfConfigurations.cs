using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoAt.Domain.Entities.Mem;

namespace SoAt.Infrastructure.Persistence.Configurations.Mem;

// ── ใส่ UCF configs ทั้งหมดในไฟล์เดียวเพื่อความกระชับ ────────────────────────

public class ScMemMUcfPrenameConfiguration : IEntityTypeConfiguration<ScMemMUcfPrename>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfPrename> b)
    {
        b.ToTable("sc_mem_m_ucf_prename");
        b.HasKey(e => e.PrenameCode);
    }
}

public class ScMemMUcfMemberTypeConfiguration : IEntityTypeConfiguration<ScMemMUcfMemberType>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfMemberType> b)
    {
        b.ToTable("sc_mem_m_ucf_member_type");
        b.HasKey(e => e.MemTypeCode);
    }
}

public class ScMemMUcfMemberGroupConfiguration : IEntityTypeConfiguration<ScMemMUcfMemberGroup>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfMemberGroup> b)
    {
        b.ToTable("sc_mem_m_ucf_member_group");
        b.HasKey(e => e.MemberGroupNo);
    }
}

public class ScMemMUcfElectionGroupConfiguration : IEntityTypeConfiguration<ScMemMUcfElectionGroup>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfElectionGroup> b)
    {
        b.ToTable("sc_mem_m_ucf_election_group");
        b.HasKey(e => e.ElectionGroup);
    }
}

public class ScMemMUcfNationalityConfiguration : IEntityTypeConfiguration<ScMemMUcfNationality>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfNationality> b)
    {
        b.ToTable("sc_mem_m_ucf_nationality");
        b.HasKey(e => e.NationalityCode);
    }
}

public class ScMemMUcfMarriageStatusConfiguration : IEntityTypeConfiguration<ScMemMUcfMarriageStatus>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfMarriageStatus> b)
    {
        b.ToTable("sc_mem_m_ucf_marriage_status");
        b.HasKey(e => e.MarriageStatusCode);
        // Oracle column is "marriage_status" (not "marriage_status_name")
        b.Property(e => e.MarriageStatusName).HasColumnName("marriage_status");
    }
}

public class ScMemMUcfBloodConfiguration : IEntityTypeConfiguration<ScMemMUcfBlood>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfBlood> b)
    {
        b.ToTable("sc_mem_m_ucf_blood");
        b.HasKey(e => e.BloodCode);
    }
}

public class ScMemMUcfProvinceConfiguration : IEntityTypeConfiguration<ScMemMUcfProvince>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfProvince> b)
    {
        b.ToTable("sc_mem_m_ucf_province");
        b.HasKey(e => e.ProvinceCode);
    }
}

public class ScMemMUcfDistrictConfiguration : IEntityTypeConfiguration<ScMemMUcfDistrict>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfDistrict> b)
    {
        b.ToTable("sc_mem_m_ucf_district");
        b.HasKey(e => e.DistrictCode);
    }
}

public class ScMemMUcfSubdistrictConfiguration : IEntityTypeConfiguration<ScMemMUcfSubdistrict>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfSubdistrict> b)
    {
        b.ToTable("sc_mem_m_ucf_subdistrict");
        b.HasKey(e => e.SubdistrictCode);
    }
}

public class ScMemMUcfApplicationTypeConfiguration : IEntityTypeConfiguration<ScMemMUcfApplicationType>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfApplicationType> b)
    {
        b.ToTable("sc_mem_m_ucf_application_type");
        b.HasKey(e => e.ApplTypeCode);
    }
}

public class ScMemMUcfConcernConfiguration : IEntityTypeConfiguration<ScMemMUcfConcern>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfConcern> b)
    {
        b.ToTable("sc_mem_m_ucf_concern");
        b.HasKey(e => e.ConcernCode);
        // Oracle typo: conceern_code → PostgreSQL: concern_code (auto-converted from C# ConcernCode)
        b.Property(e => e.RelatedNa).HasColumnName("related_na");
    }
}

public class ScMemMUcfGroupPositionConfiguration : IEntityTypeConfiguration<ScMemMUcfGroupPosition>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfGroupPosition> b)
    {
        b.ToTable("sc_mem_m_ucf_group_position");
        b.HasKey(e => e.GroupPosition);
    }
}

public class ScMemMUcfPositionConfiguration : IEntityTypeConfiguration<ScMemMUcfPosition>
{
    public void Configure(EntityTypeBuilder<ScMemMUcfPosition> b)
    {
        b.ToTable("sc_mem_m_ucf_position");
        b.HasKey(e => e.PositionCode);
    }
}

public class ScCntMCoopConfiguration : IEntityTypeConfiguration<ScCntMCoop>
{
    public void Configure(EntityTypeBuilder<ScCntMCoop> b)
    {
        b.ToTable("sc_cnt_m_coop");
        b.HasKey(e => e.CoopNo);
    }
}
