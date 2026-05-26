using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoAt.Domain.Entities.Fin;

namespace SoAt.Infrastructure.Persistence.Configurations.Fin;

public class ScFinMConstantConfiguration : IEntityTypeConfiguration<ScFinMConstant>
{
    public void Configure(EntityTypeBuilder<ScFinMConstant> builder)
    {
        builder.ToTable("sc_fin_m_constant");
        builder.HasKey(e => e.CoopNo);
        builder.Property(e => e.CoopNo).HasColumnName("coop_no").HasMaxLength(15);
        builder.Property(e => e.FinanceDate).HasColumnName("finance_date");
    }
}
