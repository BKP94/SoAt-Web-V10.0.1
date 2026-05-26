using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoAt.Domain.Entities.System;

namespace SoAt.Infrastructure.Persistence.Configurations;

public class SiSecurityAppConfiguration : IEntityTypeConfiguration<SiSecurityApp>
{
    public void Configure(EntityTypeBuilder<SiSecurityApp> builder)
    {
        builder.ToTable("si_security_apps");
        builder.HasKey(a => a.IMenuId);
        builder.Property(a => a.IMenuId).HasColumnName("i_menu_id").ValueGeneratedNever();
        builder.Property(a => a.AppName).HasColumnName("app_name").HasMaxLength(15);
        builder.Property(a => a.AppText).HasColumnName("app_text").HasMaxLength(50);
        builder.Property(a => a.AppTextEnglish).HasColumnName("app_text_english").HasMaxLength(100);
        builder.Property(a => a.Active).HasColumnName("active");
        builder.Property(a => a.ILevel).HasColumnName("i_level");
        builder.Property(a => a.ISequence).HasColumnName("i_sequence");
        builder.Property(a => a.OrderNo).HasColumnName("order_no");
        builder.Property(a => a.ShotApp).HasColumnName("shot_app").HasMaxLength(3);
        builder.Property(a => a.IconName).HasColumnName("icon_name").HasMaxLength(40);
        builder.Property(a => a.SUrl).HasColumnName("s_url").HasMaxLength(40);
        builder.Property(a => a.IParentId).HasColumnName("i_parent_id");
        builder.Property(a => a.SubAppName).HasColumnName("sub_app_name").HasMaxLength(15);
        builder.Property(a => a.Remark).HasColumnName("remark").HasMaxLength(100);
    }
}
