using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoAt.Domain.Entities.Mem;

namespace SoAt.Infrastructure.Persistence.Configurations.Mem;

// ── Transaction table configs ─────────────────────────────────────────────────

public class ScMemMApplicationFormConfiguration : IEntityTypeConfiguration<ScMemMApplicationForm>
{
    public void Configure(EntityTypeBuilder<ScMemMApplicationForm> b)
    {
        b.ToTable("sc_mem_m_application_form");
        b.HasKey(e => e.ApplicationFormNo);
        b.Property(e => e.ApplicationFormNo).HasMaxLength(15);
    }
}

public class ScMemMAppAddressConfiguration : IEntityTypeConfiguration<ScMemMAppAddress>
{
    public void Configure(EntityTypeBuilder<ScMemMAppAddress> b)
    {
        b.ToTable("sc_mem_m_app_address");
        b.HasKey(e => new { e.ApplicationFormNo, e.AddressType }); // composite PK
    }
}

public class ScMemMAppWorkInfoConfiguration : IEntityTypeConfiguration<ScMemMAppWorkInfo>
{
    public void Configure(EntityTypeBuilder<ScMemMAppWorkInfo> b)
    {
        b.ToTable("sc_mem_m_app_work_info");
        b.HasKey(e => e.ApplicationFormNo);
    }
}

public class ScMemMAppShareConfiguration : IEntityTypeConfiguration<ScMemMAppShare>
{
    public void Configure(EntityTypeBuilder<ScMemMAppShare> b)
    {
        b.ToTable("sc_mem_m_app_share");
        b.HasKey(e => e.ApplicationFormNo);
    }
}

public class ScMemMAppMemberReferConfiguration : IEntityTypeConfiguration<ScMemMAppMemberRefer>
{
    public void Configure(EntityTypeBuilder<ScMemMAppMemberRefer> b)
    {
        b.ToTable("sc_mem_m_app_member_refer");
        b.HasKey(e => new { e.ApplicationFormNo, e.SeqNo });
    }
}

public class ScMemMAppRecrieveGainConfiguration : IEntityTypeConfiguration<ScMemMAppRecrieveGain>
{
    public void Configure(EntityTypeBuilder<ScMemMAppRecrieveGain> b)
    {
        b.ToTable("sc_mem_m_app_recrieve_gain");
        b.HasKey(e => new { e.ApplicationFormNo, e.SeqNo });
    }
}

public class ScMemMAppPictureConfiguration : IEntityTypeConfiguration<ScMemMAppPicture>
{
    public void Configure(EntityTypeBuilder<ScMemMAppPicture> b)
    {
        b.ToTable("sc_mem_m_app_picture");
        b.HasKey(e => e.ApplicationFormNo);
    }
}

public class ScMemMAppSignatureConfiguration : IEntityTypeConfiguration<ScMemMAppSignature>
{
    public void Configure(EntityTypeBuilder<ScMemMAppSignature> b)
    {
        b.ToTable("sc_mem_m_app_signature");
        b.HasKey(e => e.ApplicationFormNo);
    }
}
