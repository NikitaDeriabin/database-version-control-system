using DBGuard.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBGuard.Core.DAL.Context.EntityConfigurations;

public class CommitConfig : IEntityTypeConfiguration<Commit>
{
    public void Configure(EntityTypeBuilder<Commit> builder)
    {
        builder.Property(x => x.Message).IsRequired().HasMaxLength(200);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAdd();

        builder.HasMany(x => x.CommitFiles)
               .WithOne(x => x.Commit)
               .HasForeignKey(x => x.CommitId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}