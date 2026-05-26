using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoAt.Domain.Entities.Common;

namespace SoAt.Infrastructure.Persistence.Configurations.Common;

public class ScComMBranchConfiguration : IEntityTypeConfiguration<ScComMBranch>
{
    public void Configure(EntityTypeBuilder<ScComMBranch> builder)
    {
        builder.ToTable("sc_com_m_branch");
        builder.HasKey(e => e.BranchId);
        builder.Property(e => e.BranchId).HasColumnName("branch_id").HasMaxLength(6);
        builder.Property(e => e.BranchName).HasColumnName("branch_name").HasMaxLength(100);
        builder.Property(e => e.BaseStatus).HasColumnName("base_status").HasMaxLength(1).IsFixedLength();
        builder.Property(e => e.PosttoFin).HasColumnName("postto_fin").HasMaxLength(1).IsFixedLength();
        builder.Property(e => e.AccountControl).HasColumnName("account_control").HasMaxLength(8);
        builder.Property(e => e.Picture2file).HasColumnName("picture_2file").HasMaxLength(1).IsFixedLength();
        builder.Property(e => e.FinanceBranch).HasColumnName("finance_branch").HasMaxLength(6);
    }
}
