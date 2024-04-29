using DBGuard.Core.DAL.Entities;
using DBGuard.Core.DAL.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBGuard.Core.DAL.Context.EntityConfigurations;

public sealed class BranchConfig : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.ProjectId).IsRequired();

        builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.CreatedBy)
                .IsRequired(false);

        builder.HasOne(x => x.ParentBranch)
               .WithMany()
               .HasForeignKey(x => x.ParentBranchId)
               .IsRequired(false);

        builder.HasMany(x => x.PullRequestsFromThisBranch)
               .WithOne(x => x.SourceBranch)
               .HasForeignKey(x => x.SourceBranchId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.PullRequestsIntoThisBranch)
               .WithOne(x => x.TargetBranch)
               .HasForeignKey(x => x.TargetBranchId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Commits)
               .WithMany(x => x.Branches)
               .UsingEntity<BranchCommit>(
                   l => l.HasOne(x => x.Commit)
                         .WithMany(x => x.BranchCommits)
                         .HasForeignKey(x => x.CommitId),
                   r => r.HasOne(x => x.Branch)
                         .WithMany(x => x.BranchCommits)
                         .HasForeignKey(x => x.BranchId));
    }
}