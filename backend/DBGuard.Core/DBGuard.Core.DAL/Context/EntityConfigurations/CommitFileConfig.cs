using DBGuard.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBGuard.Core.DAL.Context.EntityConfigurations;

public sealed class CommitFileConfig : IEntityTypeConfiguration<CommitFile>
{
    public void Configure(EntityTypeBuilder<CommitFile> builder)
    {
        builder.Property(x => x.FileName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.BlobId).IsRequired().HasMaxLength(100);
        builder.Property(x => x.FileType).IsRequired();
        builder.Property(x => x.CommitId).IsRequired();
    }
}