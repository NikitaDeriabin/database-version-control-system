using DBGuard.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBGuard.Core.DAL.Context.EntityConfigurations;

public class ChangeRecordConfig : IEntityTypeConfiguration<ChangeRecord>
{
    public void Configure(EntityTypeBuilder<ChangeRecord> builder)
    {
        builder.Property(x => x.UniqueChangeId).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAdd();

        builder.HasOne(x => x.User)
               .WithMany(x => x.ChangeRecords)
               .HasForeignKey(x => x.CreatedBy)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}
