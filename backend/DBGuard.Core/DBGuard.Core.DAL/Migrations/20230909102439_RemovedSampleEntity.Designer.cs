﻿// <auto-generated />
using System;
using DBGuard.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBGuard.Core.DAL.Migrations
{
    [DbContext(typeof(DbGuardCoreContext))]
    [Migration("20230909102439_RemovedSampleEntity")]
    partial class RemovedSampleEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommentedEntity")
                        .HasColumnType("int");

                    b.Property<int>("CommentedEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Commit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.CommitFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlobId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CommitId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommitId");

                    b.ToTable("CommitFiles");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.CommitParent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommitId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommitId");

                    b.HasIndex("ParentId");

                    b.ToTable("CommitParents");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.JoinEntities.BranchCommit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CommitId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHead")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMerged")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CommitId");

                    b.ToTable("BranchCommits");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.JoinEntities.ProjectTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TagId");

                    b.ToTable("ProjectTags");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.JoinEntities.PullRequestReviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PullRequestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PullRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("PullRequestReviewers");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.JoinEntities.UserProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("DbEngine")
                        .HasColumnType("int");

                    b.Property<int?>("DefaultBranchId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DefaultBranchId")
                        .IsUnique()
                        .HasFilter("[DefaultBranchId] IS NOT NULL");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.PullRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsReviewed")
                        .HasColumnType("bit");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("SourceBranchId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TargetBranchId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SourceBranchId");

                    b.HasIndex("TargetBranchId");

                    b.ToTable("PullRequests");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EmailNotification")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsGoogleAuth")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Salt")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("SquirrelNotification")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Branch", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.Project", "Project")
                        .WithMany("Branches")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Comment", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Commit", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.User", "Author")
                        .WithMany("Commits")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.CommitFile", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.Commit", "Commit")
                        .WithMany("CommitFiles")
                        .HasForeignKey("CommitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Commit");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.CommitParent", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.Commit", "Commit")
                        .WithMany("CommitsAsChild")
                        .HasForeignKey("CommitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.Commit", "ParentCommit")
                        .WithMany("CommitsAsParent")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Commit");

                    b.Navigation("ParentCommit");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.JoinEntities.BranchCommit", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.Branch", "Branch")
                        .WithMany("BranchCommits")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.Commit", "Commit")
                        .WithMany("BranchCommits")
                        .HasForeignKey("CommitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Commit");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.JoinEntities.ProjectTag", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.Project", "Project")
                        .WithMany("ProjectTags")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.Tag", "Tag")
                        .WithMany("ProjectTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.JoinEntities.PullRequestReviewer", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.PullRequest", "PullRequest")
                        .WithMany("PullRequestReviewers")
                        .HasForeignKey("PullRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.User", "User")
                        .WithMany("PullRequestReviewers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PullRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.JoinEntities.UserProject", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.Project", "Project")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Project", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.User", "Author")
                        .WithMany("OwnProjects")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.Branch", "DefaultBranch")
                        .WithOne()
                        .HasForeignKey("DBGuard.Core.DAL.Entities.Project", "DefaultBranchId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Author");

                    b.Navigation("DefaultBranch");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.PullRequest", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.User", "Author")
                        .WithMany("PullRequests")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.Project", "Project")
                        .WithMany("PullRequests")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.Branch", "SourceBranch")
                        .WithMany("PullRequestsFromThisBranch")
                        .HasForeignKey("SourceBranchId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DBGuard.Core.DAL.Entities.Branch", "TargetBranch")
                        .WithMany("PullRequestsIntoThisBranch")
                        .HasForeignKey("TargetBranchId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Project");

                    b.Navigation("SourceBranch");

                    b.Navigation("TargetBranch");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.RefreshToken", b =>
                {
                    b.HasOne("DBGuard.Core.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Branch", b =>
                {
                    b.Navigation("BranchCommits");

                    b.Navigation("PullRequestsFromThisBranch");

                    b.Navigation("PullRequestsIntoThisBranch");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Commit", b =>
                {
                    b.Navigation("BranchCommits");

                    b.Navigation("CommitFiles");

                    b.Navigation("CommitsAsChild");

                    b.Navigation("CommitsAsParent");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Project", b =>
                {
                    b.Navigation("Branches");

                    b.Navigation("ProjectTags");

                    b.Navigation("PullRequests");

                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.PullRequest", b =>
                {
                    b.Navigation("PullRequestReviewers");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.Tag", b =>
                {
                    b.Navigation("ProjectTags");
                });

            modelBuilder.Entity("DBGuard.Core.DAL.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Commits");

                    b.Navigation("OwnProjects");

                    b.Navigation("PullRequestReviewers");

                    b.Navigation("PullRequests");

                    b.Navigation("UserProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
