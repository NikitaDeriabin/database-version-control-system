﻿using DBGuard.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBGuard.Core.DAL.Context.EntityConfigurations;

public sealed class CommitParentConfig : IEntityTypeConfiguration<CommitParent>
{
    public void Configure(EntityTypeBuilder<CommitParent> builder)
    {
        builder.HasOne(x => x.ParentCommit)
               .WithMany(x => x.CommitsAsParent)
               .HasForeignKey(x => x.ParentId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Commit)
               .WithMany(x => x.CommitsAsChild)
               .HasForeignKey(x => x.CommitId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}