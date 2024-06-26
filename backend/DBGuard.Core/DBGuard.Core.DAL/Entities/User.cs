﻿using DBGuard.Core.DAL.Entities.Common;
using DBGuard.Core.DAL.Entities.JoinEntities;

namespace DBGuard.Core.DAL.Entities;

public sealed class User : Entity<int>
{
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PasswordHash { get; set; }
    public string? Salt { get; set; }
    public string? AvatarUrl { get; set; }
    public bool DBGuardNotification { get; set; }
    public bool EmailNotification { get; set; }
    public bool IsGoogleAuth { get; set; }

    public ICollection<Commit> Commits { get; set; } = new List<Commit>();
    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<PullRequest> PullRequests { get; set; } = new List<PullRequest>();
    public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<Project> OwnProjects { get; set; } = new List<Project>();
    public ICollection<PullRequest> ReviewedRequests { get; set; } = new List<PullRequest>();
    public ICollection<PullRequestReviewer> PullRequestReviewers { get; set; } = new List<PullRequestReviewer>();
    public ICollection<Script> Scripts { get; set; } = new List<Script>();
    public ICollection<ChangeRecord> ChangeRecords { get; set; } = new List<ChangeRecord>();
}