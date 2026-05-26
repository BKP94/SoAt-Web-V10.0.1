using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoAt.Domain.Entities.Fin;

namespace SoAt.Infrastructure.Persistence.Configurations.Fin;

public class ScFinJournalHeadConfiguration : IEntityTypeConfiguration<ScFinJournalHead>
{
    public void Configure(EntityTypeBuilder<ScFinJournalHead> builder)
    {
        builder.ToTable("sc_fin_journal_head");

        // Composite PK: (branch_fin, journal_date, entry_fin, open_no, fin_book)
        builder.HasKey(e => new { e.BranchFin, e.JournalDate, e.EntryFin, e.OpenNo, e.FinBook });

        builder.Property(e => e.BranchFin).HasColumnName("branch_fin").HasMaxLength(6);
        builder.Property(e => e.JournalDate).HasColumnName("journal_date");
        builder.Property(e => e.EntryFin).HasColumnName("entry_fin").HasMaxLength(16);
        builder.Property(e => e.OpenNo).HasColumnName("open_no").HasColumnType("numeric(15,0)");
        builder.Property(e => e.FinBook).HasColumnName("fin_book").HasMaxLength(1).IsFixedLength();
        builder.Property(e => e.BalanceBegin).HasColumnName("balance_begin").HasColumnType("numeric(15,2)");
        builder.Property(e => e.TotalReceive).HasColumnName("total_receive").HasColumnType("numeric(15,2)");
        builder.Property(e => e.TotalPayment).HasColumnName("total_payment").HasColumnType("numeric(15,2)");
        builder.Property(e => e.BalanceForward).HasColumnName("balance_forward").HasColumnType("numeric(15,2)");
        builder.Property(e => e.MainCounter).HasColumnName("main_counter").HasMaxLength(1).IsFixedLength();
        builder.Property(e => e.CloseDay).HasColumnName("close_day").HasMaxLength(1).IsFixedLength();
        builder.Property(e => e.CloseId).HasColumnName("close_id").HasMaxLength(16);
        builder.Property(e => e.CloseTime).HasColumnName("close_time");
        builder.Property(e => e.CloseClientId).HasColumnName("close_client_id").HasMaxLength(3);
    }
}
