using DBGuard.Core.DAL.Entities;
using DBGuard.Core.DAL.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBGuard.Core.DAL.Context.EntityConfigurations;

public sealed class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(1000);
        builder.Property(x => x.DbEngine).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAddOrUpdate();

        builder.HasOne(x => x.DefaultBranch)
               .WithOne()
               .HasForeignKey<Project>(x => x.DefaultBranchId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Branches)
               .WithOne(x => x.Project)
               .HasForeignKey(x => x.ProjectId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(x => x.PullRequests)
               .WithOne(x => x.Project)
               .HasForeignKey(x => x.ProjectId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Tags)
               .WithMany(x => x.Projects)
               .UsingEntity<ProjectTag>(
                   l => l.HasOne(x => x.Tag)
                         .WithMany(x => x.ProjectTags)
                         .HasForeignKey(x => x.TagId),
                   r => r.HasOne(x => x.Project)
                         .WithMany(x => x.ProjectTags)
                         .HasForeignKey(x => x.ProjectId));
    }
}