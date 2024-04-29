using DBGuard.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBGuard.Core.DAL.Context.EntityConfigurations;

public sealed class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(x => x.Content).IsRequired().HasMaxLength(500);
        builder.Property(x => x.CommentedEntity).IsRequired();
        builder.Property(x => x.CommentedEntityId).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.UpdatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAddOrUpdate();
        builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAdd();
    }
}