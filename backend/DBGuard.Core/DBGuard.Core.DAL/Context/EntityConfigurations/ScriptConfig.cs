﻿using DBGuard.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBGuard.Core.DAL.Context.EntityConfigurations;

public sealed class ScriptConfig : IEntityTypeConfiguration<Script>
{
    public void Configure(EntityTypeBuilder<Script> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.FileName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.UpdatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAddOrUpdate();
        builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql(DbGuardCoreContext.SqlGetDateFunction)
               .ValueGeneratedOnAdd();

        builder.HasOne(x => x.LastUpdatedBy)
               .WithMany()
               .HasForeignKey(x => x.LastUpdatedByUserId)
               .IsRequired();

        builder.HasOne(x => x.Author)
               .WithMany(x => x.Scripts)
               .HasForeignKey(x => x.CreatedBy)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Project)
               .WithMany(x => x.Scripts)
               .HasForeignKey(x => x.ProjectId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}