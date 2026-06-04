using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoAt.Domain.Entities.System;

namespace SoAt.Infrastructure.Persistence.Configurations;

public class SiSecurityUserConfiguration : IEntityTypeConfiguration<SiSecurityUser>
{
    public void Configure(EntityTypeBuilder<SiSecurityUser> builder)
    {
        builder.ToTable("si_security_user");
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserId).HasColumnName("user_id").HasMaxLength(16);
        builder.Property(u => u.UserName).HasColumnName("user_name").HasMaxLength(60);
        builder.Property(u => u.BranchId).HasColumnName("branch_id").HasMaxLength(6);
        builder.Property(u => u.Passwords).HasColumnName("passwords").HasMaxLength(100);
        builder.Property(u => u.CloseStatus).HasColumnName("close_status").HasMaxLength(1).HasDefaultValue("0");
        builder.Property(u => u.GroupId).HasColumnName("group_id").HasMaxLength(16);
        builder.Property(u => u.Programmer).HasColumnName("programmer").HasMaxLength(1);
        builder.Property(u => u.AdminMode).HasColumnName("admin_mode").HasMaxLength(1);
        builder.Property(u => u.CounterSplit).HasColumnName("counter_split").HasMaxLength(1).IsFixedLength();
    }
}
