﻿using DBGuard.Core.DAL.Entities;
using DBGuard.Core.DAL.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;

namespace DBGuard.Core.DAL.Context;

public class DbGuardCoreContext : DbContext
{
    public const string SqlGetDateFunction = "getutcdate()";
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Commit> Commits => Set<Commit>();
    public DbSet<CommitFile> CommitFiles => Set<CommitFile>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<PullRequest> PullRequests => Set<PullRequest>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<BranchCommit> BranchCommits => Set<BranchCommit>();
    public DbSet<CommitParent> CommitParents => Set<CommitParent>();
    public DbSet<ProjectTag> ProjectTags => Set<ProjectTag>();
    public DbSet<PullRequestReviewer> PullRequestReviewers => Set<PullRequestReviewer>();
    public DbSet<UserProject> UserProjects => Set<UserProject>();
    public DbSet<Script> Scripts => Set<Script>();
    public DbSet<ProjectDatabase> ProjectDatabases => Set<ProjectDatabase>();
    public DbSet<ChangeRecord> ChangeRecords => Set<ChangeRecord>();

    public DbGuardCoreContext(DbContextOptions<DbGuardCoreContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
    }
}
